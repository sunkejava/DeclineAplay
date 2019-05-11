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
    [Description("圆角带图标的控件")]
    public partial class RadiusControlButton : UserControl
    {
        private bool _isBdtb = false;//是否变动图标，如果是，在鼠标点击之后图标变动为选择后的图标，再次点击恢复默认图标
        private bool _isSelect = false;//是否选择，如果是，默认图标为选择后的图标，否则为默认图标
        private Image _SelectImage = null;//选择后的图标
        private Image _DefaultImage = null;//默认图标

        public RadiusControlButton()
        {
            InitializeComponent();
        }

        [Description("圆角度数"), Category("自定义属性")]
        public int Radius
        {
            get { return radiusControl1.Radius; }
            set
            {
                radiusControl1.Radius = value;
                radiusControl1.Size = new Size(value, value);
            }
        }
        /// <summary>
        /// 背景颜色设置
        /// </summary>
        [Description("背景颜色设置"), Category("自定义属性")]
        public Color SetBackColor
        {
            get { return radiusControl1.SetBackColor; }
            set
            {
                radiusControl1.SetBackColor = value;
                skinButton_play.BackColor = value;
            }
        }
        /// <summary>
        /// 设置图标大小
        /// </summary>
        [Description("设置图标大小"), Category("自定义属性")]
        public int SetIconSize
        {
            get { return skinButton_play.Width; }
            set
            {
                skinButton_play.Size = new Size(value, value);
                skinButton_play.Location = new Point((radiusControl1.Width - value) / 2, (radiusControl1.Width - value) / 2);
            }
        }
        /// <summary>
        /// 设置默认图标
        /// </summary>
        [Description("设置默认图标"), Category("自定义属性")]
        public Image SetDefaultIcon
        {
            get { return _DefaultImage; }
            set
            {
                skinButton_play.BackgroundImage = value;
                _DefaultImage = value;
            }
        }
        [Description("设置默认图片布局"), Category("自定义属性")]
        public ImageLayout SetDefaultImageLayout
        {
            get { return skinButton_play.BackgroundImageLayout; }
            set { skinButton_play.BackgroundImageLayout = value; }
        }
        /// <summary>
        /// 是否变动图标，如果是变动图标，默认选择之后图标会更改为选择后的图标，否则一直为默认图标
        /// </summary>
        [Description("是否变动图标，如果是变动图标，默认选择之后图标会更改为选择后的图标，否则一直为默认图标"), Category("自定义属性")]
        public bool IsBdtb
        {
            get { return _isBdtb; }
            set { _isBdtb = value; }
        }
        /// <summary>
        /// 是否已选择，配合是否变动图标使用，只有是变动图标时有效。
        /// </summary>
        [Description("是否已选择，配合是否变动图标使用，只有是变动图标时有效。"), Category("自定义属性")]
        public bool IsSelect
        {
            get { return _isSelect; }
            set
            {
                _isSelect = value;
                if (_isBdtb && _isSelect)
                {
                    skinButton_play.BackgroundImage = _SelectImage;
                }
                else
                {
                    skinButton_play.BackgroundImage = _DefaultImage;
                }
            }
        }
        /// <summary>
        /// 选择后的图标，配合是否变动图标使用，只有是变动图标时有效
        /// </summary>
        [Description("选择后的图标，配合是否变动图标使用，只有是变动图标时有效。"), Category("自定义属性")]
        public Image SetSelectIcon
        {
            get { return _SelectImage; }
            set { _SelectImage = value; }
        }

        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Description("是否显示边框"), Category("自定义属性")]
        public bool IsShowBorder
        {
            get { return radiusControl1.IsShowBorder; }
            set { radiusControl1.IsShowBorder = value; }
        }

    }
}
