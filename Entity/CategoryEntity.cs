/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  CategoryEntity
*版本号：  V1.0.0.0
*唯一标识：a4704e4b-3f09-4e21-abb2-4719c5a538a7
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:13:39
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:13:39
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
    public class CategoryEntity
    {
        public class DataItem
        {
            /// <summary>
            /// 类型ID
            /// </summary>
            public int categoryID { get; set; }
            /// <summary>
            /// 类型名称
            /// </summary>
            public string categoryName { get; set; }
            /// <summary>
            /// 数量
            /// </summary>
            public int VideoCnt { get; set; }
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
