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
            Entity.UserEntity userEntity = new Entity.UserEntity();
            userEntity.imei = "4a46fa50b289ff3c";
            userEntity.sellid = "28825252";
            API.TvAPI tvApi = new API.TvAPI();
            textBox_resoult.Text = tvApi.getAppVer() + "\r\n";
            textBox_resoult.Text += tvApi.getAppConfig(userEntity.imei) + "\r\n";
            textBox_resoult.Text += tvApi.getSellInfo(userEntity.sellid) + "\r\n";
            textBox_resoult.Text += tvApi.MemberLogin(userEntity) + "\r\n";
            textBox_resoult.Text += tvApi.getCategory(userEntity.imei) + "\r\n";
            textBox_resoult.Text += tvApi.getScrollMenu(userEntity.imei) + "\r\n";
            textBox_resoult.Text += tvApi.getFreeVideo(userEntity.imei) + "\r\n";
            textBox_resoult.Text += tvApi.getNewVideo("1", userEntity.imei) + "\r\n";
        }
    }
}
