/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  ConfigEntity
*版本号：  V1.0.0.0
*唯一标识：c0911e50-11b5-4a1e-a18c-fb6e4a6f00ca
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:10:25
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:10:25
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
    public class ConfigEntity
    {
        public class DomainItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Domain { get; set; }
        }

        public class VerItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string ios_ver { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ios_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string android_ver { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string android_url { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<DomainItem> domain { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<VerItem> ver { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
        }
    }
}
