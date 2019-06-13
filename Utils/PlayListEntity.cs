/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  PlayListEntity
*版本号：  V1.0.0.0
*唯一标识：71cc4663-1405-473c-b02d-15a62f9f0e60
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/6/13 17:15:52
*描述：播放器列表实体
*
*=====================================================================
*修改标记
*修改时间：2019/6/13 17:15:52
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
    public class PlayListEntity
    {

        public string tvUrl { get; set; }
        public string tvName { get; set; }
        public string tvTimeLength { get; set; }
        public string tvImgUrl { get; set; }
    }
}
