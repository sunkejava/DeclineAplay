using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeclineAplay
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            //Entity.UserEntity userEntity = new Entity.UserEntity();
            //userEntity.imei = "4a46fa50b289ff3c";
            //userEntity.sellid = "28825252";
            //API.TvAPI tvApi = new API.TvAPI();
            //textBox_resoult.Text = "版本号：" + "\r\n" + tvApi.getAppVer() + "\r\n";
            //textBox_resoult.Text += "配置：" + "\r\n" + tvApi.getAppConfig(userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "购买信息：" + "\r\n" + tvApi.getSellInfo(userEntity.sellid) + "\r\n";
            //textBox_resoult.Text += "用户登录：" + "\r\n" + tvApi.MemberLogin(userEntity) + "\r\n";
            //textBox_resoult.Text += "获取分类：" + "\r\n" + tvApi.getCategory(userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "获取首页菜单分类：" + "\r\n" + tvApi.getScrollMenu(userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "热门标签：" + "\r\n" + tvApi.getHotTags("all", userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "免费视频：" + "\r\n" + tvApi.getFreeVideo(userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "最新视频：" + "\r\n" + tvApi.getNewVideo("1", userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "根据类型获取视频：" + "\r\n" + tvApi.getCategoryVideo("1", userEntity.imei, "11") + "\r\n";
            //textBox_resoult.Text += "搜索视频：" + "\r\n" + tvApi.searchVideoByTag("1", "", userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "视频详情：" + "\r\n" + tvApi.getVideoDetail("46446", "44777", userEntity.imei) + "\r\n";
            //textBox_resoult.Text += "视频地址：" + "\r\n" + tvApi.getVideoUrl("", "", "46446", "all", userEntity.imei) + "\r\n";
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }
    }
}
