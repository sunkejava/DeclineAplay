/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  UserInfoEntity
*版本号：  V1.0.0.0
*唯一标识：a7efddd5-cb67-4520-bbd2-8677103c7299
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:12:31
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:12:31
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
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public int SellID { get; set; }
    }
}
