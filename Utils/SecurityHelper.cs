/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.Utils
*文件名：  SecurityHelper
*版本号：  V1.0.0.0
*唯一标识：97fc70bf-7533-41b4-bf2e-1e694e67f8b6
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/1 13:16:02
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/1 13:16:02
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DeclineAplay.Utils
{
    public class SecurityHelper
    {

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="strText">要加密字符串</param>
        /// <param name="IsLower">是否以小写方式返回</param>
        /// <returns></returns>
        public static string MD5Encrypt(string strText, bool IsLower)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strText);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }

        /// <summary>
        /// 解码得到URL值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DecodeUrl(string text)
        {
            return HttpContext.Current.Server.UrlDecode(text);
        }

        /// <summary>
        /// 编码传入url值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EncodeUrl(string text)
        {
            return HttpContext.Current.Server.UrlEncode(text);
        }

        /// <summary>
        /// 设置web请求头
        /// </summary>
        /// <param name="header">请求头</param>
        /// <param name="name">节点名称</param>
        /// <param name="value">节点值</param>
        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
    }
}
