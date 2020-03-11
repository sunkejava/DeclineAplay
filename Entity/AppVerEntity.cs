/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Entity
*文件名：  AppVerEntity
*版本号：  V1.0.0.0
*唯一标识：07779aeb-4128-4bd4-8314-7826afd75160
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/6 10:08:16
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/6 10:08:16
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclineAplay.Entity
{
    public class AppVerEntity
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string ver { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns>返回需要的实体信息</returns>
        public override string ToString()
        {
            return "ver:"+ver.ToString()+"---message:"+message;
        }
        /// <summary>
        /// 转为json字符串
        /// </summary>
        /// <returns></returns>
        public string toJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
