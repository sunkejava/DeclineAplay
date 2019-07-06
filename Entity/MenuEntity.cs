/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  MenuEntity
*版本号：  V1.0.0.0
*唯一标识：6cfa6db5-1d81-4b30-b853-ac1458657f5d
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:16:21
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:16:21
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclineAplay.Entity
{
    public class MenuEntity
    {
        public class DataItem
        {
            /// <summary>
            /// 菜单名称
            /// </summary>
            public string MenuName { get; set; }
            /// <summary>
            /// 菜单值
            /// </summary>
            public string MenuVal { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<DataItem> data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
        }
    }
}
