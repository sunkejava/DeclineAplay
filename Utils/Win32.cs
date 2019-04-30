/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  Win32
*版本号：  V1.0.0.0
*唯一标识：b45a4859-6fef-4ee4-a093-1e2d75533649
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/4/30 13:17:27
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/4/30 13:17:27
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DeclineAplay.Utils
{
    class Win32
    {
        // ---函数功能：该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // ---发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        // ---查找窗口句柄
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        // ---获取窗口句柄,hwnd为源窗口句柄
        [DllImport("User32.dll", EntryPoint = "GetWindow")]
        public static extern int GetWindow(int hwnd, int wCmd);

        // ---设置父窗体
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        // ---创建圆角矩形区域
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

        // ---设置多种边界剪切域
        [DllImport("user32.dll", EntryPoint = "SetWindowRgn")]
        public static extern int SetWindowRgn(int hwnd, int hRgn, bool bRedraw);

        // ---删除对象资源
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern int DeleteObject(int hdc);
    }
}
