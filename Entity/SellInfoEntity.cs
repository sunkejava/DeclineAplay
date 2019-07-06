/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  SellInfoEntity
*版本号：  V1.0.0.0
*唯一标识：35564062-5aa4-4892-9086-385d372bfa13
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:11:29
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:11:29
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
    public class SellInfoEntity
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string LogoURL { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Title { get; set; }
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
        }
    }
}
