/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  TagsEntity
*版本号：  V1.0.0.0
*唯一标识：2ab3ef94-1230-47ab-accd-2553b52f84cd
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:40:21
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:40:21
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
    public class TagsEntity
    {
        //如果好用，请收藏地址，帮忙分享。
        public class DataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int TopicId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Topic { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Item { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int TopicOrder { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int ItemOrder { get; set; }
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
