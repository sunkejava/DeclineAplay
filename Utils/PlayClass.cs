/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  PlayClass
*版本号：  V1.0.0.0
*唯一标识：6839d01d-cf0e-454a-ac4a-1cf56380e0a0
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/4/30 13:14:24
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/4/30 13:14:24
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
    public class PlayClass
    {
        public PlayClass()
        {
            position = new Position();
        }
        /// <summary>
        /// 是否在全屏
        /// </summary>
        public bool isScreen;
        /// <summary>
        /// 是否最大化
        /// </summary>
        public bool isMaximization;
        /// <summary>
        /// 是否静音
        /// </summary>
        public bool isMute;
        /// <summary>
        /// 移动窗口时临时记录当前X
        /// </summary>
        public int VM_X;
        /// <summary>
        /// 移动窗口时临时记录当前Y
        /// </summary>
        public int VM_Y;
        public Position position;

        /// <summary>
        /// 播放状态
        /// </summary>
        public enum PLAY_STATE
        {
            /// <summary>
            /// 正在加载
            /// </summary>
            PS_READY = 0,
            /// <summary>
            /// 正在打开
            /// </summary>
            PS_OPENING = 1,
            /// <summary>
            /// 正在暂停
            /// </summary>
            PS_PAUSING = 2,
            /// <summary>
            /// 暂停
            /// </summary>
            PS_PAUSED = 3,
            /// <summary>
            /// 正在播放
            /// </summary>
            PS_PLAYING = 4,
            /// <summary>
            /// 播放
            /// </summary>
            PS_PLAY = 5,
            /// <summary>
            /// 正在关闭
            /// </summary>
            PS_CLOSING = 6,
        }

        public enum Scrol_State
        {
            /// <summary>
            /// 静止
            /// </summary>
            None = 0,
            /// <summary>
            /// 正常移动
            /// </summary>
            NormalMove = 1,
            /// <summary>
            /// 手动移动
            /// </summary>
            ManualMove = 2,
            /// <summary>
            /// 手动移动开始
            /// </summary>
            MoveBegin = 3,
            /// <summary>
            /// 手动移动结束
            /// </summary>
            MoveEnd = 4
        }

        public enum MouseStaue
        {
            /// <summary>
            /// 正常
            /// </summary>
            normal = 1,
            /// <summary>
            /// 进入
            /// </summary>
            enter = 2,
            /// <summary>
            /// 离开
            /// </summary>
            level = 1,
            /// <summary>
            /// 按下
            /// </summary>
            down = 3,
            /// <summary>
            /// 禁用
            /// </summary>
            en = 4,


        }
    }


    public class Position
    {
        public int Top;
        public int Left;
        public int Width;
        public int Height;
    }

    class Functions
    {
        // ---移动窗口ByHandle
        public static void moveForm(IntPtr formHandle)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(formHandle, 0x0112, 0xF012, 0);
        }
    }
}
