using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;
using DeclineAplay.Controls;
using DeclineAplay.Utils;
using System.Collections;
using Microsoft.Win32;

namespace DeclineAplay
{
    public partial class MainForm : LayeredForm
    {
        #region 模拟窗体移动变量
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;
        #endregion

        /// <summary>
        /// 滚轮用参数
        /// </summary>
        private bool scorlling = false;
        private int mousetop = 0;
        API.TvAPI bimg = new API.TvAPI();
        Entity.UserEntity userEntity = new Entity.UserEntity();
        DuiBaseControl typeControl = new DuiBaseControl();
        string startNo = "0";//开始序号
        string pageCount = "12";//每页或每次调用获取图片的总数
        string SumPage = "N";//总页数
        bool isSearch = false;//是否搜索
        bool isEnd = false;//是否为页尾
        bool isLoadData = false;//是否正在加载数据
        ArrayList imgList = new ArrayList();
        string nCount = "0";//当前类型可获取的图片总数
        public Color defaultColor = Color.FromArgb(255, 92, 138);
        delegate void AsynUpdateUI(bool isLoad);//委托更新加载控件显示
        delegate void AsynUpdateloadPageText(string nowPage, string countPage);
        delegate void AsynScrollUI(object sender, EventArgs e);//委托ListBox刷新事件
        delegate void AsynScrollUpdateUI(object sender, EventArgs e);//委托ListBoxValue更新事件
        public Image BackImg = null;
        int x, y;//记录鼠标进入控件时的位置
        #region 窗体控件事件
        public MainForm()
        {
            InitializeComponent();
            setSkinStyle();
        }
        public void setSkinStyle()
        {
            this.BackColor = Color.FromArgb(125, defaultColor.R, defaultColor.G, defaultColor.B);
            layeredPanel_top.BackColor = defaultColor;
            scorllbar.BackColor = defaultColor;
            Panel_Bottom.BackColor = defaultColor;
            Panel_load.BackColor = Color.FromArgb(125, defaultColor.R, defaultColor.G, defaultColor.B);
            List_Main.RefreshList();
        }
        private void BackForm_Load(object sender, EventArgs e)
        {
            foreach (var item in BaseControl_Search.DUIControls)
            {
                if (item is DuiButton)
                {
                    DuiButton btn_search = item as DuiButton;
                    if (btn_search.Name == "btn_search")
                    {
                        btn_search.MouseClick += Btn_search_MouseClick;
                    }
                    if (btn_search.Name == "btn_searchtext")
                    {
                        foreach (var citem in btn_search.Controls)
                        {
                            if (citem is DuiTextBox)
                            {
                                DuiTextBox searchText = citem as DuiTextBox;
                                searchText.FocusedChanged += SearchText_FocusedChanged;
                            }
                        }
                    }
                }
            }
            userEntity.email = "";
            userEntity.psw = "";
            userEntity.imei = "4a46fa50b289ff3c";
            userEntity.sellid = "28825252";
            bimg.MemberLogin(userEntity);
            //添加默认字段
            userEntity.menuName = "0";
            startNo = "1";
            nCount = "0";
            isSearch = false;
            Thread thread = new Thread(() => addBackImg());
            thread.Start();
        }
        /// <summary>
        /// 搜索框获取焦点后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchText_FocusedChanged(object sender, EventArgs e)
        {
            DuiTextBox searchText = sender as DuiTextBox;
            if (searchText != null)
            {
                if (searchText.Text == "输入关键字进行搜索")
                {
                    searchText.Text = "";
                    searchText.ForeColor = Color.White;
                }
                else
                {
                    if (string.IsNullOrEmpty(searchText.Text))
                    {
                        searchText.Text = "输入关键字进行搜索";
                        searchText.ForeColor = Color.FromArgb(255, 171, 171, 171);
                    }
                }
            }
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_search_MouseClick(object sender, DuiMouseEventArgs e)
        {
            foreach (var item in BaseControl_Search.DUIControls)
            {
                if (item is DuiButton)
                {
                    DuiButton btn_search = item as DuiButton;
                    foreach (var citem in btn_search.Controls)
                    {
                        if (citem is DuiTextBox)
                        {
                            DuiTextBox searchText = citem as DuiTextBox;
                            if (!string.IsNullOrEmpty(searchText.Text) && searchText.Text != "输入关键字进行搜索")
                            {
                                isSearch = true;
                                startNo = "1";
                                userEntity.menuName = searchText.Text;
                                Thread thread = new Thread(() => updateImgList(searchText.Text, startNo));
                                thread.Start();
                            }
                            else
                            {
                                MessageForm mf = new MessageForm("请输入关键字进行搜索");
                                mf.ShowDialog();
                            }
                        }
                    }

                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.Visible = false;
        }


        private void btn_set_Click(object sender, EventArgs e)
        {

        }

        private void btn_min_MouseHover(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            switch (thisButton.Name)
            {
                case "layeredPanel_close":
                    thisButton.BackColor = Color.FromArgb(255, 88, 88);
                    break;
                default:
                    thisButton.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
            }
        }
        private void btn_skin_MouseEnter(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            switch (thisButton.Name)
            {
                case "btn_set":
                    layeredPanel_Set.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                case "btn_min":
                    layeredPanel_min.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                default:
                    layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
                    break;
            }
        }

        private void btn_skin_MouseLeave(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.Transparent;
        }
        private void btn_min_MouseLeave(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            thisButton.BackColor = Color.Transparent;
            layeredPanel_min.BackColor = thisButton.BackColor;
            layeredPanel_close.BackColor = thisButton.BackColor;
            layeredPanel_Set.BackColor = thisButton.BackColor;
        }

        private void Dlbe_MouseEnter(object sender, DuiMouseEventArgs e)
        {
            skinLine_Update();
            DuiBaseControl lbbtn = sender as DuiBaseControl;
            string vtag = "";
            foreach (var vitem in lbbtn.Controls)
            {
                DuiLabel lb = vitem as DuiLabel;
                vtag = lb.Tag.ToString();
                if (lb.Name.Contains("ImageTypeName_"))
                {
                    lb.ForeColor = defaultColor;
                }
                else
                {
                    lb.BackColor = defaultColor;
                }
            }
            DuiBaseControl bControl = lbbtn.Parent as DuiBaseControl;
            foreach (var item in bControl.FindControl("ImageTypeGrid_" + vtag))
            {
                if (item is DuiBaseControl && item.Controls.Count > 0 && Panel_TypeMess.DUIControls.Count <= 0)
                {
                    DuiBaseControl newpm = new DuiBaseControl();
                    newpm.Size = item.Size;
                    newpm.Visible = true;
                    newpm.Location = new Point(0, 0);
                    newpm.BackColor = item.BackColor;
                    newpm.Borders = item.Borders;
                    newpm.ShowBorder = item.ShowBorder;
                    foreach (var vitem in item.Controls)
                    {
                        if (vitem is DuiLabel)
                        {
                            DuiLabel dl = vitem as DuiLabel;
                            dl.Cursor = Cursors.Hand;
                            dl.MouseEnter += dlTag_MouseEnter;
                            dl.MouseLeave += dlTag_MouseLeave;
                            newpm.Controls.Add(dl);
                        }
                    }
                    newpm.Dock = DockStyle.Fill;
                    Panel_TypeMess.DUIControls.Add(newpm);
                    Panel_TypeMess.Size = item.Size;
                    Panel_TypeMess.Location = new Point(item.Location.X, layeredPanel_top.Height + Panel_Type.Height - 5);
                    Utils.AnimationControl.ShowControl(Panel_TypeMess, true, AnchorStyles.Right);
                }
            }
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
            //NowNum = int.Parse(btn.Tag.ToString());
            //LoadSliderImg(NowNum);
            Panel_Type.Refresh();
        }

        private void Dlbe_MouseMove(object sender, DuiMouseEventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
        }

        /// <summary>
        /// 图片类型点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlbe_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlbe = sender as DuiLabel;
            if (dlbe.Tag != null)
            {
                Entity.MenuEntity.DataItem dt = (Entity.MenuEntity.DataItem)dlbe.Tag;
                if (dt.MenuName != userEntity.menuName)
                {
                    userEntity.menuName = dt.MenuVal.Replace("categoryID=", "");
                    startNo = "1";
                    nCount = "0";
                    SumPage = "N";
                    isSearch = false;
                    Thread thread = new Thread(() => updateImgList(dt.MenuVal.Replace("categoryID=", ""), startNo));
                    thread.Start();
                }
            }
        }
        private void Dlbe_MouseLeave(object sender, EventArgs e)
        {
            Point ms = Control.MousePosition;
            if ((ms.Y < y || (ms.Y >= y && ms.X != x)) && Panel_TypeMess.DUIControls.Count > 0)
            {
                skinLine_Update();
                Panel_TypeMess.DUIControls.Clear();
                Utils.AnimationControl.ShowControl(Panel_TypeMess, false, AnchorStyles.Left);
            }
            List_Main.Refresh();
        }

        private void dlTag_MouseEnter(object sender, EventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            dlb.ForeColor = defaultColor;
        }

        private void dlTag_MouseLeave(object sender, EventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            dlb.ForeColor = System.Drawing.Color.Black;
        }

        private void dlTag_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            string tidsStr = dlb.Tag.ToString();
            if (!String.IsNullOrEmpty(tidsStr))
            {
                if (tidsStr.Contains("-"))
                {
                    userEntity.menuName = dlb.Tag.ToString().Split('-')[1];
                    startNo = "1";
                    SumPage = "N";
                    isSearch = false;
                    Thread thread = new Thread(() => updateImgList(dlb.Tag.ToString().Split('-')[1], startNo));
                    thread.Start();
                }
                else
                {
                    userEntity.menuName = dlb.Tag.ToString();
                    startNo = "1";
                    SumPage = "N";
                    isSearch = false;
                    Thread thread = new Thread(() => updateImgList(dlb.Tag.ToString().Split('-')[1], startNo));
                    thread.Start();
                }
            }
        }

        /// <summary>
        /// 热门标签底层控件离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeControl_MouseLeave(object sender, EventArgs e)
        {
            if (Panel_TypeMess.DUIControls.Count > 0)
            {
                skinLine_Update();
                Panel_TypeMess.DUIControls.Clear();
                Panel_TypeMess.Visible = false;
                Panel_TypeMess.Size = new Size(0, 0);
                Panel_TypeMess.Refresh();
            }
        }
        /// <summary>
        /// 热门标签底层控件进入事件
        /// </summary>
        private void TypeControl_MouseEnter(object sender, EventArgs e)
        {
            //Panel_TypeMess.Visible = true;
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 设置应用程序开机自动运行
        /// </summary>
        /// <param name="fileName">应用程序的文件名</param>
        /// <param name="isAutoRun">是否自动运行，为false时，取消自动运行</param>
        /// <exception cref="System.Exception">设置不成功时抛出异常</exception>
        public static void SetAutoRun(string fileName, bool isAutoRun)
        {
            RegistryKey reg = null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                    throw new Exception(fileName + "文件不存在!");
                String name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (isAutoRun)
                    reg.SetValue(name, fileName);
                else
                    reg.SetValue(name, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }

        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="tagId">类型ID或搜索关键字</param>
        /// <param name="startNos">开始数</param>
        /// <returns></returns>
        private bool updateImgList(string tagId, string startNos)
        {
            return updateImgList(tagId, startNo, "");
        }

        private bool updateImgList(string tagId, string startNos, string tagName)
        {
            try
            {
                LoadingControl(true);
                startNos = (string.IsNullOrEmpty(startNos) ? "1" : startNos);
                List<DuiBaseControl> cItems = new List<DuiBaseControl>();
                foreach (var item in List_Main.Items)
                {
                    if (item is DuiBaseControl)
                    {
                        if ((item as DuiBaseControl).Name.Contains("imgListBaseControl_"))
                        {
                            cItems.Add((item as DuiBaseControl));
                        }
                    }
                }
                foreach (var item in cItems)
                {
                    List_Main.Items.Remove(item);
                }
                cItems.Clear();
                var result = new Utils.Response<Entity.MovieListEntity.Root>();
                List<Entity.MovieListEntity.DataItem> imgInfos = new List<Entity.MovieListEntity.DataItem>();
                if (isSearch)
                {
                    result.Result = bimg.searchVideoByTag(startNos, tagId, userEntity.imei);
                }
                else
                {
                    if (string.IsNullOrEmpty(tagId) || tagId == "新片")
                    {
                        result.Result = bimg.getNewVideo(startNos, userEntity.imei);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tagName))
                        {
                            result.Result = bimg.getCategoryVideo(startNos, userEntity.imei, tagId);
                        }
                    }

                }
                if (result.Result == null || result.Result.data == null || result.Result.data.Count == 0)
                {
                    SumPage = startNo;
                    LoadingControl(false);
                    return false;
                }
                nCount = result.Result.data.Count.ToString();
                loadPageTextUpdate(startNos, "");
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0 || zi == result.Result.data.Count)
                    {
                        //Thread imgThread = new Thread(() => addImgListThread(imgInfos));
                        //imgThread.Start();
                        List_Main.AddImgList(imgInfos);
                        List_Main.RefreshList();
                        imgInfos.Clear();
                    }
                }
                if (result.Result.data.Count <= 0)
                {
                    List_Main.addIsNull();
                    imgInfos.Clear();
                    List_Main.RefreshList();
                }
                LoadingControl(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("加载图片失败,原因为：" + ex.Message);
            }

        }

        private bool addImgListItem(string tagId, string startNos)
        {
            LoadingControl(true);
            //准备加载下一页图片
            startNos = (string.IsNullOrEmpty(startNos) ? "1" : startNos);
            List<DuiBaseControl> cItems = new List<DuiBaseControl>();
            var result = new Utils.Response<Entity.MovieListEntity.Root>();
            List<Entity.MovieListEntity.DataItem> imgInfos = new List<Entity.MovieListEntity.DataItem>();
            if (isSearch)
            {
                result.Result = bimg.searchVideoByTag(startNos, tagId, userEntity.imei);
            }
            else
            {
                if (string.IsNullOrEmpty(tagId) || tagId == "0")
                {
                    result.Result = bimg.getNewVideo(startNos, userEntity.imei);
                }
                else
                {
                    result.Result = bimg.getCategoryVideo(startNos, userEntity.imei, tagId);
                }
            }
            nCount = result.Result.data.Count.ToString();
            loadPageTextUpdate(startNos, "");
            for (int i = 0; i < result.Result.data.Count; i++)
            {
                int zi = i + 1;
                imgInfos.Add(result.Result.data[i]);
                if (zi % 3 == 0 || zi == result.Result.data.Count)
                {
                    List_Main.AddImgList(imgInfos);
                    List_Main.RefreshList();
                    imgInfos.Clear();
                }
            }
            LoadingControl(false);
            isLoadData = false;
            return true;
        }
        private void LoadingControl(bool isLoad)
        {
            if (this.Panel_load.InvokeRequired)
            {
                AsynUpdateUI au = new AsynUpdateUI(LoadingControl);
                this.Invoke(au, new object[] { isLoad });
            }
            else
            {
                Panel_load.Visible = isLoad;
                if (isLoad)
                {
                    DuiPictureBox dp = Panel_load.DUIControls[0] as DuiPictureBox;
                    dp.Images = new Image[] { Properties.Resources.video_loading_01, Properties.Resources.video_loading_02, Properties.Resources.video_loading_03, Properties.Resources.video_loading_04, Properties.Resources.video_loading_05, Properties.Resources.video_loading_06, Properties.Resources.video_loading_07, Properties.Resources.video_loading_08 };
                    Panel_load.BringToFront();
                }
                else
                {
                    Panel_load.SendToBack();
                }
            }
        }

        private void loadPageTextUpdate(string nowPage, string countPage)
        {
            if (string.IsNullOrEmpty(countPage)) countPage = "N";
            if (this.Panel_load.InvokeRequired)
            {
                AsynUpdateloadPageText au = new AsynUpdateloadPageText(loadPageTextUpdate);
                this.Invoke(au, new object[] { nowPage, countPage });
            }
            else
            {
                DuiLabel dpText = Panel_load.DUIControls[1] as DuiLabel;
                dpText.Text = "正在加载第 " + nowPage + "/" + countPage + ", 请稍后......";
            }
        }
        private void skinLine_Update()
        {
            foreach (var itemControl in typeControl.Controls)
            {
                if (itemControl is DuiBaseControl)
                {
                    foreach (var vitem in (itemControl as DuiBaseControl).Controls)
                    {
                        if (vitem is DuiLabel)
                        {
                            if ((vitem as DuiLabel).Name.Contains("ImageTypeLine_") && (vitem as DuiLabel).Tag.ToString() != userEntity.menuName)
                            {
                                (vitem as DuiLabel).BackColor = System.Drawing.Color.Silver;
                            }
                            if ((vitem as DuiLabel).Name.Contains("ImageTypeName_") && (vitem as DuiLabel).Tag.ToString() != userEntity.menuName)
                            {
                                (vitem as DuiLabel).ForeColor = System.Drawing.Color.Black;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="imgJsons"></param>
        /// <returns></returns>
        public bool addImgType(Entity.MenuEntity.Root menus)
        {
            //获取热门标签
            typeControl.Name = "typeControl";
            //循环增加分类
            for (int i = 0; i < menus.data.Count; i++)
            {
                //含热门标签的分类
                addTypeLable(menus.data[i]);
            }
            typeControl.Controls.Add(addHotTagControl(bimg.getHotTags("all", userEntity.imei)));
            typeControl.Size = new Size(this.Width, 35);
            typeControl.Dock = DockStyle.Fill;
            Panel_Type.BackColor = Color.White;
            Panel_TypeMess.BringToFront();
            Panel_Type.DUIControls.Add(typeControl);
            return true;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="imgType">类型</param>
        /// <returns></returns>
        private Boolean addTypeLable(Entity.MenuEntity.DataItem imgType)
        {
            int i = (typeControl.Controls.Count / 1);
            DuiLabel dlbe = new DuiLabel();
            dlbe.Size = new Size(60, 20);
            dlbe.Text = imgType.MenuName;
            dlbe.Name = "ImageTypeName_" + imgType.MenuName;
            dlbe.Location = new Point(0, 5);
            dlbe.Cursor = System.Windows.Forms.Cursors.Hand;
            dlbe.MouseMove += Dlbe_MouseMove;
            dlbe.TextAlign = ContentAlignment.MiddleCenter;
            dlbe.Tag = imgType;
            dlbe.MouseClick += Dlbe_MouseClick;

            DuiLabel dLabel1 = new DuiLabel();
            dLabel1.Name = "ImageTypeLine_" + imgType.MenuName;
            dLabel1.Cursor = dlbe.Cursor;
            dLabel1.Size = new Size(60, 2);
            dLabel1.BackColor = System.Drawing.Color.Silver;
            dLabel1.Height = 2;
            dLabel1.Tag = imgType;
            dLabel1.Location = new Point(0, 30);
            dLabel1.MouseClick += Dlbe_MouseClick;

            DuiBaseControl dlbControl = new DuiBaseControl();
            dlbControl.Size = new Size(60, 35);
            dlbControl.Location = new Point(61 * i, 0);
            dlbControl.MouseMove += Dlbe_MouseEnter;
            //dlbControl.MouseEnter += Dlbe_MouseEnter;
            dlbControl.MouseLeave += Dlbe_MouseLeave;
            dlbControl.Controls.AddRange(new DuiBaseControl[] { dlbe, dLabel1 });
            typeControl.Controls.Add(dlbControl);
            return true;
        }

        /// <summary>
        /// 添加热门标签
        /// </summary>
        /// <param name="tagsList">标签数组List</param>
        /// <param name="typeId">分类ID</param>
        /// <param name="index">当前顺序</param>
        /// <returns></returns>
        private DuiBaseControl addHotTagControl(Entity.TagsEntity.Root tagsList)
        {
            int index = ((typeControl.Controls.Count - 1) / 2);
            DuiBaseControl ltypeControl = new DuiBaseControl();
            if (tagsList.data.Count > 0)
            {
                ltypeControl.Size = new Size(154, 15 + tagsList.data.Count * 27 / 2);
            }
            else
            {
                ltypeControl.Size = new Size(154, 0);
            }

            ltypeControl.Name = "ImageTypeGrid_0";
            ltypeControl.Location = new Point(60 * index, 25);
            ltypeControl.Visible = false;
            ltypeControl.BackColor = Color.White;//Color.FromArgb(defaultColor.R,defaultColor.G,defaultColor.B);
            int rowi = 1;
            int coli = 1;
            int ti = 1;
            foreach (Entity.TagsEntity.DataItem citem in tagsList.data)
            {
                coli = (ti % 2 == 0 ? 2 : 1);
                rowi = (int)Math.Ceiling(((double)ti / 2));
                DuiLabel dlbea = new DuiLabel();
                dlbea.Size = new Size(60, 20);
                dlbea.Text = citem.Item;
                dlbea.Name = "ImageTypeNameOther_" + citem.TopicId + citem.ItemOrder;
                dlbea.Location = new Point(70 * (coli - 1), 10 + 24 * (rowi - 1));
                dlbea.Cursor = System.Windows.Forms.Cursors.Hand;
                dlbea.TextAlign = ContentAlignment.MiddleCenter;
                dlbea.Tag = "0-" + citem.Item;
                dlbea.MouseClick += dlTag_MouseClick;
                ltypeControl.Controls.Add(dlbea);
                ti++;
            }
            return ltypeControl;
        }
        private void addBackImg()
        {
            LoadingControl(true);
            var result = new Utils.Response<Entity.MovieListEntity.Root>();
            var rType = new Utils.Response<Entity.MenuEntity.Root>();
            try
            {
                rType.Result = bimg.getScrollMenu(userEntity.imei);
                //添加分类控件
                addImgType(rType.Result);
                //添加详细信息
                List<Entity.MovieListEntity.DataItem> imgInfos = new List<Entity.MovieListEntity.DataItem>();
                result.Result = bimg.getNewVideo(startNo, userEntity.imei);
                if (result.Result == null)
                {
                    LoadingControl(false);
                    return;
                }
                nCount = result.Result.data.Count.ToString();
                loadPageTextUpdate(startNo, "");
                List_Main.userEntity = userEntity;
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0 || zi == result.Result.data.Count)
                    {
                        List_Main.AddImgList(imgInfos);
                        List_Main.RefreshList();
                        imgInfos.Clear();
                    }
                }
                LoadingControl(false);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region 滚动条事件
        private void layeredPanel_top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void scorllbar_Move(object sender, EventArgs e)
        {
            if (scorlling)
            {
                List_Main.Value = (double)(scorllbar.Top - List_Main.Top) / (double)(List_Main.Height - scorllbar.Height);
            }
        }

        private void scorllbar_MouseDown(object sender, MouseEventArgs e)
        {
            mousetop = scorllbar.PointToClient(MousePosition).Y;
            scorlling = true;
            scorllbar.BackColor = defaultColor;
        }

        private void scorllbar_MouseEnter(object sender, EventArgs e)
        {
            if (scorllbar.Top < List_Main.Top)
                scorllbar.Top = List_Main.Top + 2;
            if (scorllbar.Top > (List_Main.Top + List_Main.Height - scorllbar.Height))
                scorllbar.Top = (List_Main.Top + List_Main.Height - scorllbar.Height);
            scorllbar.BackColor = defaultColor;
        }

        private void scorllbar_MouseLeave(object sender, EventArgs e)
        {
            scorllbar.BackColor = defaultColor;
        }

        private void scorllbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (scorlling)
            {
                if (scorllbar.Top >= List_Main.Top && scorllbar.Top <= (List_Main.Top + List_Main.Height - scorllbar.Height))
                    scorllbar.Top = PointToClient(MousePosition).Y - mousetop;
            }
        }

        private void scorllbar_MouseUp(object sender, MouseEventArgs e)
        {
            mousetop = e.Y; scorlling = false;
            scorllbar.BackColor = defaultColor;
        }

        private void List_Main_RefreshListed(object sender, EventArgs e)
        {
            if (this.List_Main.InvokeRequired)
            {
                AsynScrollUI au = new AsynScrollUI(List_Main_RefreshListed);
                this.Invoke(au, new object[] { sender, e });
            }
            else
            {
                int allheight = 0;
                for (int i = 0; i < List_Main.Items.Count; i++)
                {
                    if (List_Main.Items[i].Visible)
                        allheight = allheight + List_Main.Items[i].Height;
                }
                double pre = (double)List_Main.Height / (double)allheight;
                if (pre < 1)
                {
                    if (List_Main.Visible)
                        scorllbar.Show();

                    scorllbar.Height = (int)(pre * (double)List_Main.Height);
                    scorllbar.Top = (int)(List_Main.Value * (List_Main.Height - scorllbar.Height)) + List_Main.Top;
                }
                else
                {
                    scorllbar.Hide();
                }

            }
        }
        /// <summary>
        /// 鼠标滚轮滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_Main_ValueChanged(object sender, EventArgs e)
        {
            if (this.List_Main.InvokeRequired)
            {
                AsynScrollUpdateUI au = new AsynScrollUpdateUI(List_Main_ValueChanged);
                this.Invoke(au, new object[] { sender, e });
            }
            else
            {
                if (!scorlling)
                {
                    scorllbar.Top = (int)(List_Main.Value * (List_Main.Height - scorllbar.Height)) + List_Main.Top;
                }
                if (List_Main.Value == 1 && !isLoadData)
                {
                    //如果为尾页则显示加载完毕
                    //if ((int.Parse(startNo) + int.Parse(pageCount)) >= int.Parse(nCount) && nCount != "0" && startNo != "0" && !isLoadData)
                    //{
                    //    if (!isEnd)
                    //    {

                    //    }
                    //}
                    //else
                    if(!startNo.Equals(SumPage))
                    {
                        isLoadData = true;
                        startNo = (int.Parse(startNo) + 1).ToString(); //int.Parse(pageCount)).ToString();
                        isEnd = false;
                        Thread thread = new Thread(() => addImgListItem(userEntity.menuName, startNo));
                        thread.Start();
                    }
                }
            }
        }
        #endregion


    }
}
