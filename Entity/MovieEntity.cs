/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  MovieEntity
*版本号：  V1.0.0.0
*唯一标识：0bbad016-9bcf-4db3-be67-1d64da813aa0
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:24:45
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:24:45
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
    public class MovieEntity
    {
        //如果好用，请收藏地址，帮忙分享。
        public class Data
        {
            /// <summary>
            /// 视频ID
            /// </summary>
            public int videoID { get; set; }
            /// <summary>
            /// 图片
            /// </summary>
            public string photo { get; set; }
            /// <summary>
            /// 预览图集合
            /// </summary>
            public List<string> preview { get; set; }
            /// <summary>
            /// 视频名称
            /// </summary>
            public string videoName { get; set; }
            /// <summary>
            /// 上架时间
            /// </summary>
            public string onDate { get; set; }
            /// <summary>
            /// 类型名称
            /// </summary>
            public string videoType { get; set; }
            /// <summary>
            /// 类型ID
            /// </summary>
            public int videoTypeID { get; set; }
            /// <summary>
            /// 演员
            /// </summary>
            public string actorName { get; set; }
            /// <summary>
            /// 时长
            /// </summary>
            public string videoTime { get; set; }
            /// <summary>
            /// 播放量
            /// </summary>
            public int playCnt { get; set; }
            /// <summary>
            /// 视频简介
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 系列
            /// </summary>
            public int series { get; set; }
            /// <summary>
            /// 系列集合
            /// </summary>
            public List<string> videoSeries { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isLike { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isNice { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isFreeView { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string VIPsatrt { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string VIPend { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string VIPsatrtLong { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string VIPendLong { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string VIPtime { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isVIP { get; set; }
        }
    }
}
