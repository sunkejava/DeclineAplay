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
*描述：
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
    }
}
