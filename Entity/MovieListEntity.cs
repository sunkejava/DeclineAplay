/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  MovieListEntity
*版本号：  V1.0.0.0
*唯一标识：2c5cc8e9-07ff-43f7-9479-9170287303d9
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:21:53
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:21:53
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
    public class MovieListEntity
    {
        public class DataItem
        {
            /// <summary>
            /// 序号
            /// </summary>
            public int Number { get; set; }
            /// <summary>
            /// 视频ID
            /// </summary>
            public int videoID { get; set; }
            /// <summary>
            /// 视频名称
            /// </summary>
            public string videoName { get; set; }
            /// <summary>
            /// 类型ID
            /// </summary>
            public int videoTypeID { get; set; }
            /// <summary>
            /// 类型名称
            /// </summary>
            public string videoType { get; set; }
            /// <summary>
            /// 上架时间
            /// </summary>
            public string onDate { get; set; }
            /// <summary>
            /// 演员
            /// </summary>
            public string actorName { get; set; }
            /// <summary>
            /// 图片
            /// </summary>
            public string photo { get; set; }
            /// <summary>
            /// 简介
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 是否免费
            /// </summary>
            public string isFreeView { get; set; }
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
