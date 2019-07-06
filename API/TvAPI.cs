/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay.API
*文件名：  TvAPI
*版本号：  V1.0.0.0
*唯一标识：09b3112e-5978-4d95-bb33-346a34c21534
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/7/1 13:04:59
*描述：
*
*=====================================================================
*修改标记
*修改时间：2019/7/1 13:04:59
*修改人： Administrator
*版本号： V1.0.0.0
*描述： 
*
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DeclineAplay.Utils;
using System.Web.Script.Serialization;

namespace DeclineAplay.API
{
    public class TvAPI
    {
        HttpWebRequest req = null;
        string ApiHost = "aaJrqLtOVStQMOYkm3CnqR+90OyUPkxQ";
        string hostStr = "BDK+58HuR7km7TgGPjgLXg==";
        string uStr = "2c+15Z1Q894=";
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns>{"ver":"","message":""}</returns>
        public Entity.AppVerEntity getAppVer()
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/VerInfo?PostKey=" + getThisKey("VerInfo", new Entity.UserEntity());
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.AppVerEntity it = jss.Deserialize<Entity.AppVerEntity>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取版本号失败,原因为：", ex);
                throw ex;
            }

        }
        /// <summary>
        /// 获取程序配置
        /// </summary>
        /// <param name="IMEI">4a46fa50b289ff3c</param>
        /// <returns></returns>
        public Entity.ConfigEntity.Root getAppConfig(string IMEI)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/AppConfig?IMEI=" + IMEI + "&postkey=" + getThisKey("AppConfig", new Entity.UserEntity());
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.ConfigEntity.Root it = jss.Deserialize<Entity.ConfigEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取程序配置失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取销售信息
        /// </summary>
        /// <param name="sellid">28825252</param>
        /// <returns>{"data":{"LogoURL":"","Title":""},"message":""}</returns>
        public Entity.SellInfoEntity.Root getSellInfo(string sellid)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/getSellInfo?sellid=" + sellid;
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.SellInfoEntity.Root it = jss.Deserialize<Entity.SellInfoEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取销售信息失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public Entity.UserInfoEntity MemberLogin(Entity.UserEntity userEntity)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/MemberLogin?mail=" + userEntity.email + "&psw=" + userEntity.psw + "&IMEI=" + userEntity.imei + "&postkey=" + getThisKey("MemberLogin", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.UserInfoEntity it = jss.Deserialize<Entity.UserInfoEntity>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取销售信息失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.CategoryEntity.Root getCategory(string IMEI)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/Category?IMEI=" + IMEI + "&postkey=" + getThisKey("Category", new Entity.UserEntity());
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.CategoryEntity.Root it = jss.Deserialize<Entity.CategoryEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取分类信息失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取首页行的菜单分类信息
        /// </summary>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MenuEntity.Root getScrollMenu(string IMEI)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/ScrollMenu?IMEI=" + IMEI + "&postkey=" + getThisKey("ScrollMenu", new Entity.UserEntity());
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MenuEntity.Root it = jss.Deserialize<Entity.MenuEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取滚动菜单失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取免费视频
        /// </summary>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MovieListEntity.Root getFreeVideo(string IMEI)
        {
            try
            {
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/FreeVideo?IMEI=" + IMEI + "&postkey=" + getThisKey("FreeVideo", new Entity.UserEntity());
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovieListEntity.Root it = jss.Deserialize<Entity.MovieListEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取免费视频失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取最新视频
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MovieListEntity.Root getNewVideo(string page, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.page = page;
                userEntity.imei = IMEI;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/NewVideo?Page=" + page + "&IMEI=" + IMEI + "&postkey=" + getThisKey("NewVideo", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovieListEntity.Root it = jss.Deserialize<Entity.MovieListEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取最新视频失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 根据分类ID获取视频
        /// </summary>
        /// <param name="page">分页</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <param name="categoryId">分类ID</param>
        /// <returns></returns>
        public Entity.MovieListEntity.Root getCategoryVideo(string page, string IMEI, string categoryId)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.page = page;
                userEntity.imei = IMEI;
                userEntity.category = categoryId;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/CategoryVideo?Page=" + page + "&Category=" + categoryId + "&IMEI=" + IMEI + "&postkey=" + getThisKey("CategoryVideo", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovieListEntity.Root it = jss.Deserialize<Entity.MovieListEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取分类视频失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取情报列表信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public string getArticleList(string page, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.page = page;
                userEntity.imei = IMEI;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/ArticleList?Page=" + page + "&IMEI=" + IMEI + "&postkey=" + getThisKey("ArticleList", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                return Reader;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取情报列表失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取详细AV情报信息
        /// </summary>
        /// <param name="id">情报ID</param>
        /// <returns></returns>
        public string getAvNews(string id)
        {
            try
            {
                string verUrl = "http://avnews.qr383.com/" + Utils.SecurityHelper.Decode(uStr) + "/AvNews?id=" + id;
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", "avnews.qr383.com");
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                return Reader;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取详细情报信息失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取热门标签（索引）
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.TagsEntity.Root getHotTags(string type, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.type = type;
                userEntity.imei = IMEI;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/SearchIndex?type=" + type + "&IMEI=" + IMEI + "&postkey=" + getThisKey("SearchIndex", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.TagsEntity.Root it = jss.Deserialize<Entity.TagsEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取热门标签失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 通过索引或标签进行视频搜索
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="tag">搜索内容</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MovieListEntity.Root searchVideoByTag(string page, string tag, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.search = tag;
                userEntity.imei = IMEI;
                userEntity.page = page;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/SearchVideo?Page=" + page + "&Search=" + SecurityHelper.EncodeUrl(tag) + "&IMEI=" + IMEI + "&postkey=" + getThisKey("SearchVideo", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovieListEntity.Root it = jss.Deserialize<Entity.MovieListEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("通过标签搜索视频失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取视频详情
        /// </summary>
        /// <param name="vid">视频ID</param>
        /// <param name="uid">用户ID</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MovieEntity.Root getVideoDetail(string vid, string uid, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.vid = vid;
                userEntity.imei = IMEI;
                userEntity.uid = uid;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/VideoDetail?vid=" + vid + "&uid=" + uid + "&IMEI=" + IMEI + "&postkey=" + getThisKey("VideoDetail", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovieEntity.Root it = jss.Deserialize<Entity.MovieEntity.Root>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取视频详情失败,原因为：", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取视频地址
        /// </summary>
        /// <param name="email">用户邮箱</param>
        /// <param name="pwd">用户密码</param>
        /// <param name="vid">视频ID</param>
        /// <param name="type">类型</param>
        /// <param name="IMEI">手机IMEI码</param>
        /// <returns></returns>
        public Entity.MovePlayEntity getVideoUrl(string email, string pwd, string vid, string type, string IMEI)
        {
            try
            {
                Entity.UserEntity userEntity = new Entity.UserEntity();
                userEntity.vid = vid;
                userEntity.imei = IMEI;
                userEntity.email = email;
                userEntity.psw = pwd;
                userEntity.type = type;
                string verUrl = Utils.SecurityHelper.Decode(ApiHost) + Utils.SecurityHelper.Decode(uStr) + "/PlayVideo?mail=" + email + "&psw=" + pwd + "&vid=" + vid + "&Type=" + type + "&IMEI=" + IMEI + "&postkey=" + getThisKey("PlayVideo", userEntity);
                req = (HttpWebRequest)HttpWebRequest.Create(verUrl);
                //设置它提交数据的方式GET
                req.Method = "GET";
                SecurityHelper.SetHeaderValue(req.Headers, "Host", Utils.SecurityHelper.Decode(hostStr));
                StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
                //获取返回的数据
                string Reader = sr.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Entity.MovePlayEntity it = jss.Deserialize<Entity.MovePlayEntity>(Reader);
                return it;
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error("获取视频播放地址失败,原因为：", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 获取请求key
        /// </summary>
        /// <param name="postType">请求类型</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public string getThisKey(string postType, Entity.UserEntity userEntity)
        {
            string encryptStr = "";
            string tempuStr = Utils.SecurityHelper.Decode(uStr);
            switch (postType)
            {
                case "MemberLogin"://用户登录
                    encryptStr = userEntity.email + userEntity.psw + userEntity.imei + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "MemberReg"://用户注册
                    encryptStr = userEntity.psw + userEntity.email + userEntity.imei + userEntity.sellid + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "UpPSW"://更新密码
                    encryptStr = userEntity.email + userEntity.psw + userEntity.imei + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "UpNick"://更新用户信息
                    encryptStr = userEntity.email + userEntity.psw + userEntity.nick + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "ForgetPSW"://忘记密码
                    encryptStr = userEntity.email + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "AppMonth"://
                    encryptStr = userEntity.email + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "ViewLog":
                case "OrderLog":
                    encryptStr = userEntity.uid + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "NewVideo"://最新视频
                case "ArticleList"://情报列表
                    encryptStr = userEntity.page + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "VideoDetail"://视频详情
                    encryptStr = userEntity.vid + userEntity.uid + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "LikeEDIT"://喜欢修改
                case "NiceVideo"://好视频
                    encryptStr = userEntity.uid + userEntity.vid + userEntity.type + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "LikeLIST"://喜欢列表
                    encryptStr = userEntity.uid + userEntity.page + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "CategoryVideo"://类别视频
                    encryptStr = userEntity.category + userEntity.page + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "SearchVideo"://搜索视频
                    encryptStr = userEntity.search + userEntity.page + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "SearchIndex"://搜索索引
                    encryptStr = userEntity.type + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "PlayVideo"://播放视频
                    encryptStr = userEntity.email + userEntity.psw + userEntity.imei + userEntity.vid + userEntity.type + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "ArticleContent"://文章内容
                    encryptStr = userEntity.id + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "MemberLogout"://用户退出
                    encryptStr = userEntity.email + userEntity.psw + userEntity.imei + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "PushList"://推送列表
                    encryptStr = userEntity.page + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "VerInfo"://获取版本号
                case "AppConfig"://获取系统配置
                case "DomainList"://域名列表
                    encryptStr = DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                case "DomainBad"://域名错误
                    encryptStr = userEntity.id + DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
                default:
                    encryptStr = DateTime.Now.ToString("yyyyMMddHH") + tempuStr;
                    break;
            }
            encryptStr = SecurityHelper.MD5Encrypt(encryptStr, true);
            return encryptStr;
        }
    }
}
