/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  AnimationControl
*版本号：  V1.0.0.0
*唯一标识：96093d85-5214-46e9-b1fc-fa061a41d062
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/5/28 12:53:05
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/5/28 12:53:05
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LayeredSkin.DirectUI;
using System.Windows.Forms;

namespace DeclineAplay.Utils
{
    public static class AnimationControl
    {
        private static readonly int MoveStep = 25;
        private static Timer tmrAnim = null;
        private static Control control = null;
        private static AnchorStyles direction = AnchorStyles.None;
        private static Size destSize;

        private static void InitTimer()
        {
            if (tmrAnim == null)
            {
                tmrAnim = new Timer();
                tmrAnim.Interval = 25;
                tmrAnim.Tick += new System.EventHandler(tmrAnim_Tick);
            }
        }

        private static void tmrAnim_Tick(object sender, System.EventArgs e)
        {
            int newValue = 0;
            int offSet = 0;
            switch (direction)
            {
                case AnchorStyles.Left:
                case AnchorStyles.Right:
                    newValue = control.Width + MoveStep;
                    if (newValue > destSize.Width)
                    {
                        tmrAnim.Stop();
                        newValue = destSize.Width;
                    }

                    offSet = newValue - control.Width;
                    control.Width += offSet;
                    if (direction == AnchorStyles.Left)
                        control.Left -= offSet;
                    break;
                case AnchorStyles.Top:
                case AnchorStyles.Bottom:
                    newValue = control.Height + MoveStep;
                    if (newValue > destSize.Height)
                    {
                        tmrAnim.Stop();
                        newValue = destSize.Height;
                    }

                    offSet = newValue - control.Height;
                    control.Height += offSet;
                    if (direction == AnchorStyles.Top)
                        control.Top -= offSet;
                    break;
            }
        }
        /// <summary>
        /// 显示控件带动画
        /// </summary>
        /// <param name="control">控件对象</param>
        /// <param name="visible">是否显示</param>
        /// <param name="direction">动画方向</param>
        public static void ShowControl(Control control, bool visible, AnchorStyles direction = AnchorStyles.None)
        {
            if (direction == AnchorStyles.None)
            {
                control.Visible = visible;
                return;
            }

            if (!visible)
            {
                if (tmrAnim != null)
                    tmrAnim.Stop();
                control.Hide();
            }
            else
            {
                InitTimer();

                if (AnimationControl.control != control && destSize.IsEmpty)
                {
                    destSize = new Size(control.Width, control.Height);
                }
                AnimationControl.control = control;
                AnimationControl.direction = direction;
                switch (direction)
                {
                    case AnchorStyles.Left:
                    case AnchorStyles.Right:
                        if (direction == AnchorStyles.Left)
                            control.Left += control.Width;
                        control.Width = 0;
                        break;
                    case AnchorStyles.Top:
                    case AnchorStyles.Bottom:
                        if (direction == AnchorStyles.Top)
                            control.Top += control.Height;
                        control.Height = 0;
                        break;
                }
                control.Show();
                tmrAnim.Start();
            }
        }
    }
}

