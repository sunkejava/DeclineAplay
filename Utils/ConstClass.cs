/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  ConstClass
*版本号：  V1.0.0.0
*唯一标识：394065fc-6d9c-498a-a6d7-43601550fe3c
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/4/30 13:19:12
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/4/30 13:19:12
*修改人： Administrator
*版本号： V1.0.0.0
*描述：鼠标键盘常量，参考MSDNhttps://docs.microsoft.com/en-us/windows/desktop/inputdev/virtual-key-codes
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclineAplay.Utils
{
    class ConstClass
    {
        /// <summary>
        /// 左键点击
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201; //定义了鼠标的左键点击消息 
        /// <summary>
        /// 左键弹起
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;  //定义了鼠标左键弹起消息
        /// <summary>
        /// 左键双击
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x203; //定义了鼠标的左键双击消息 
        /// <summary>
        /// 右键按下
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x0204;//定义了鼠标的右键按下消息
        /// <summary>
        /// 鼠标移动
        /// </summary>
        public const int WM_MOUSEMOVE = 0x0200;//定义了鼠标移动消息
        /// <summary>
        /// 鼠标离开
        /// </summary>
        public const int WM_MOUSELEAVE = 0x02A3;//定义了鼠标离开消息
        /// <summary>
        /// 光标悬停
        /// </summary>
        public const int WM_MOUSEHOVER = 0x02A1;//定义了光标悬停一会的消息
        /// <summary>
        /// 左箭头键
        /// </summary>
        public const int VK_LEFT = 0x25;//左箭头键
        /// <summary>
        /// 向上箭头键
        /// </summary>
        public const int VK_UP = 0x26;//向上箭头键
        /// <summary>
        /// 右箭头键
        /// </summary>
        public const int VK_RIGHT = 0x27;//右箭头键
        /// <summary>
        /// 向下箭头键
        /// </summary>
        public const int VK_DOWN = 0x28;//向下箭头键
        /// <summary>
        /// 空格键
        /// </summary>
        public const int VK_SPACE = 0x20;//空格键
        /// <summary>
        /// ESC键
        /// </summary>
        public const int VK_ESCAPE = 0x1B;//ESC键
    }
}
