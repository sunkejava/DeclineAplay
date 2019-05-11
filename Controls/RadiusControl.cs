using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeclineAplay.Controls
{
    [Description("圆角控件")]
    public partial class RadiusControl : UserControl
    {
        public RadiusControl()
        {
            InitializeComponent();
        }
        [Description("圆角度数"), Category("自定义属性")]
        public int Radius
        {
            get { return layeredButton1.Radius; }
            set
            {
                layeredButton1.Radius = value;
            }
        }
        [Description("背景颜色设置"), Category("自定义属性")]
        public Color SetBackColor
        {
            get { return layeredButton1.BaseColor; }
            set
            {
                layeredButton1.BaseColor = value;
            }
        }

        [Description("是否显示边框"), Category("自定义属性")]
        public bool IsShowBorder
        {
            get { return layeredButton1.ShowBorder; }
            set { layeredButton1.ShowBorder = value; }
        }

        [Description("设置背景图片"), Category("自定义属性")]
        public Image SetBackgroundImage
        {
            get { return layeredButton1.BackgroundImage; }
            set { layeredButton1.BackgroundImage = value; }
        }
        [Description("设置背景图片布局"), Category("自定义属性")]
        public ImageLayout SetBackgroundImageLayout
        {
            get { return layeredButton1.BackgroundImageLayout; }
            set { layeredButton1.BackgroundImageLayout = value; }
        }
    }
}
