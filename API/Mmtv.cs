/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.API
*文件名：  Mmtv
*版本号：  V1.0.0.0
*唯一标识：cec67d72-9ebb-41cd-8bb1-2e8fcdbf1500
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/6/18 09:52:12
*描述：mmtvAPI
*
*=====================================================================
*修改标记
*修改时间：2019/6/18 09:52:12
*修改人： Administrator
*版本号： V1.0.0.0
*描述：mml接口
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DeclineAplay.API
{
    public class Mmtv
    {

        /// <summary>
        /// 网站地址，永久发布地址:http://sdith.23n.im/kuldep.html?/
        /// </summary>
        private string mmHost = "http://m7.22c.im";
        HttpWebRequest req = null;


        /// <summary>
        /// 获取视频地址
        /// </summary>
        /// <param name="tvName"></param>
        /// <returns></returns>
        public string getMmUrl(string tvType, string tvName)
        {
            string tvUrl, hostTvUrl, k1, k2, k3, k4, k6, k7 = "";
            if (tvType == "rv" || !tvType.Contains("v"))
            {
                hostTvUrl = "http://k.syasn.com/";
            }
            else
            {
                hostTvUrl = "http://9.syasn.com/";
            }
            k2 = "cs" + getRandomStr(8);
            string leftUrl = hostTvUrl + tvType + "/" + tvName + ".mp4";
            tvUrl = "http://h.syasn.com/?n=" + tvName;
            req = (HttpWebRequest)HttpWebRequest.Create(tvUrl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            SetHeaderValue(req.Headers, "Referer", mmHost + "/" + tvName);
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的数据
            string Reader = sr.ReadToEnd();
            string[] returnStrs = Reader.Split(',');
            if (returnStrs.Length > 0)
            {
                k1 = returnStrs[0].Replace("mip", "").Replace(",", "").Replace("=", "").Replace("'", "").Replace(";", "").Trim();
                k3 = returnStrs[1].Replace("mik", "").Replace(",", "").Replace("=", "").Replace("'", "").Replace(";", "").Trim();
                k4 = returnStrs[2].Replace("min", "").Replace(",", "").Replace("=", "").Replace("'", "").Replace(";", "").Trim();
                k6 = returnStrs[3].Replace("mis", "").Replace(",", "").Replace("=", "").Replace("'", "").Replace(";", "").Trim();
                k7 = returnStrs[4].Replace("mid", "").Replace(",", "").Replace("=", "").Replace("'", "").Replace(";", "").Trim();
                tvUrl = leftUrl + "?k1=" + k1 + "&k2=" + k2 + "&k3=" + k3 + "&k4=" + k4 + "&k5=" + tvName + "&k6=" + k6 + "&k7=" + k7;
            }
            else
            {
                throw new Exception("解析地址失败，原因为返回数据为空，请确认地址是否正确！");
            }
            return tvUrl;
        }

        /// <summary>
        /// 获取指定长度的随机字符串
        /// </summary>
        /// <param name="strLength"></param>
        /// <returns></returns>
        private string getRandomStr(int strLength)
        {
            string astr = "";
            Random rdm = new Random();
            for (int i = 0; i < strLength; i++)
            {
                astr += "abcdefghijklmnpqrstuvwxyz1234567890".Substring((int)(Math.Floor(35 * rdm.NextDouble())), 1);
            }
            return astr;
        }

        private void SetHeaderValue(WebHeaderCollection header, string name, string value)
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
