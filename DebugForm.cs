using DeclineAplay.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DeclineAplay
{
    public partial class DebugForm : Form
    {
        Entity.UserEntity userEntity = new Entity.UserEntity();
        API.TvAPI tvApi = null;
        Entity.MovieEntity.Root avDetail = null;
        Entity.MovePlayEntity avPlayer = null;
        int pageNumber = 0;
        delegate void AsynUpdateUI(string text);//委托更新
        public DebugForm()
        {
            InitializeComponent();
        }
        private void getResoult(int pageNo,string strType)
        {
            switch (strType)
            {
                case "版本号":
                    updateText("版本号：" + "\r\n" + tvApi.getAppVer().toJsonString() + "\r\n");
                    break;
                case "配置":
                    updateText("配置：" + "\r\n" + tvApi.getAppConfig(userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "购买信息":
                    updateText("购买信息：" + "\r\n" + tvApi.getSellInfo(userEntity.sellid).toJsonString() + "\r\n");
                    break;
                case "用户登录":
                    updateText("用户登录：" + "\r\n" + tvApi.MemberLogin(userEntity).toJsonString() + "\r\n");
                    break;
                case "获取分类":
                    updateText("获取分类：" + "\r\n" + tvApi.getCategory(userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "获取首页菜单分类":
                    updateText("获取首页菜单分类：" + "\r\n" + tvApi.getScrollMenu(userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "热门标签":
                    updateText("热门标签：" + "\r\n" + tvApi.getHotTags("all", userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "免费视频":
                    updateText("免费视频：" + "\r\n" + tvApi.getFreeVideo(userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "最新视频":
                    updateText("最新视频：" + "\r\n" + tvApi.getNewVideo(pageNo.ToString(), userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "根据类型获取视频":
                    updateText("根据类型获取视频：" + "\r\n" + tvApi.getCategoryVideo(pageNo.ToString(), userEntity.imei, text_typeid.Text ?? "11").toJsonString() + "\r\n");
                    break;
                case "搜索视频":
                    updateText( "搜索视频：" + "\r\n" + tvApi.searchVideoByTag(pageNo.ToString(), text_search.Text ?? "", userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "视频详情":
                    updateText("视频详情：" + "\r\n" + tvApi.getVideoDetail(text_tvid.Text ?? "46446", "44777", userEntity.imei).toJsonString() + "\r\n");
                    break;
                case "视频地址":
                    avDetail =  tvApi.getVideoDetail(text_tvid.Text ?? "46446", "44777", userEntity.imei);
                    avPlayer = tvApi.getVideoUrl("", "", text_tvid.Text ?? "46446", "all", userEntity.imei);
                    updateText("视频详情：" + "\r\n" + avDetail.toJsonString() + "\r\n");
                    updateText("视频地址：" + "\r\n" + avPlayer.toJsonString() + "\r\n");
                    break;
                default:
                    textBox_resoult.Text = "";
                    break;
            }
        }

        private void updateText(string text)
        {
            if (this.textBox_resoult.InvokeRequired)
            {
                AsynUpdateUI au = new AsynUpdateUI(updateText);
                this.Invoke(au, new object[] { text });
            }
            else
            {
                textBox_resoult.Text += text;
            }
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            pageNumber = int.Parse(page_text.Text);
            string strS = comB_Type.Text;
            Thread thread = new Thread(() => getResoult(pageNumber, strS));
            thread.Start();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            userEntity.imei = "4a46fa50b289ff3c";
            userEntity.sellid = "28825252";
            tvApi = new API.TvAPI();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (avDetail == null)
            {
                return;
            }
            try
            {
                PlayerForm plF = new PlayerForm();
                string url = avPlayer.data;
                plF.tvUrl = url;
                plF.tvName = avDetail.data.videoName;
                plF.Show();
                plF.AxPlayer_PlayOrPause(url);
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("name:" + avDetail.data.videoName + "---地址:" + avPlayer.data, ex);
                throw;
            }
        }
    }
}
