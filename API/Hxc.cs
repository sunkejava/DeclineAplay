﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace DeclineAplay.API
{
    public class Hxc
    {
        HttpWebRequest req = null;
        public Utils.EDate.Root getSearchData(string searchText)
        {
            try
            {
                string curl = @"http://api1.aajpa.cn:8688/Video/GetListByTag";
                string jsons = "{\"length\":60,\"start\":0,\"searchtext\":\"" + searchText + "\",\"UserID\":0}";
                //创建一个HttpWebRequest对象
                req = (HttpWebRequest)HttpWebRequest.Create(curl);
                //设置它提交数据的方式GET  
                req.Method = "POST";
                req.ContentType = "application/json;charset=UTF-8";
                SetHeaderValue(req.Headers, "Charset", "UTF-8");
                SetHeaderValue(req.Headers, "User-Agent", "Mozilla/5.0 (Linux; Android 4.4.2; SM-G955F Build/JLS36C) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36 Html5Plus/1.0");
                SetHeaderValue(req.Headers, "Token", "dasdas");
                SetHeaderValue(req.Headers, "Content-Length", jsons.Length.ToString());
                SetHeaderValue(req.Headers, "Host", "api1.aajpa.cn:8688");
                SetHeaderValue(req.Headers, "Connection", "Keep-Alive");
                //SetHeaderValue(req.Headers, "Expect", "100-continue");//远程服务器返回错误: (417) EXPECTATION_FAILED。Http1.1根据该头信息判断是否直接发送body
                byte[] payload;
                payload = System.Text.Encoding.UTF8.GetBytes(jsons);
                Stream writer = req.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取登录后返回的用户Token数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Utils.EDate.Root it = jss.Deserialize<Utils.EDate.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

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
