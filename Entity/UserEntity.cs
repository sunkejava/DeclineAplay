/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  UserEntity
*版本号：  V1.0.0.0
*唯一标识：baf26eaf-9ecc-44a8-9718-ae819a502d9a
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/1 13:47:06
*描述：用户实体
*
*=====================================================================
*修改标记
*修改时间：2019/7/1 13:47:06
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
    public class UserEntity
    {
        public string email { get; set; }
        public string psw { get; set; }
        public string imei { get; set; }
        public string sellid { get; set; }
        public string uid { get; set; }
        public string page { get; set; }
        public string type { get; set; }
        public string vid { get; set; }
        public string category { get; set; }
        public string search { get; set; }
        public string id { get; set; }
        public string nick { get; set; }
        public string menuName { get; set; }
    }
}
