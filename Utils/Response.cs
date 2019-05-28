/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  Response
*版本号：  V1.0.0.0
*唯一标识：68f5a5b1-a3cc-49d4-9fea-40015963b0e0
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/5/28 13:06:42
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/5/28 13:06:42
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
    public class Response
    {
        /// <summary>
        /// 操作消息【当Status不为 200时，显示详细的错误信息】
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 操作状态码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Response()
        {
            Code = 200;
            Message = "操作成功";
        }
    }

    /// <summary>
    /// WEBAPI通用返回泛型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// 回传的结果
        /// </summary>
        public T Result { get; set; }
    }
}
