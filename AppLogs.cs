/****************************************************************************
*Copyright (c) 2019  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：KDT-8
*命名空间：DeclineAplay
*文件名：  AppLogs
*版本号：  V1.0.0.0
*唯一标识：1c1d3efe-ba45-469a-b37e-3d01ec2cfc22
*当前的用户域：KDT-8
*创建人：  sunkejava
*电子邮箱：declineaberdeen@foxmail.com
*创建时间：2019/4/15 17:47:09
*描述：日志管理类
*
*=====================================================================
*修改标记
*修改时间：2019/4/15 17:47:09
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeclineAplay
{
    /// <summary>
    /// 使用Log4net插件的log日志对象
    /// </summary>
    public static class AppLogs
    {
        private static ILog log;

        static AppLogs()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            log = LogManager.GetLogger(typeof(AppLogs));
        }
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(object message)
        {
            log.Debug(message);
        }
        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void DebugFormatted(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }
        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            log.Info(message);
        }
        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void InfoFormatted(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(object message)
        {
            log.Warn(message);
        }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WarnFormatted(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }
        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            log.Error(message);
        }
        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }
        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void ErrorFormatted(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(object message)
        {
            log.Fatal(message);
        }
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void FatalFormatted(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }
    }
}
