using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace DeclineAplay.Utils
{
    public class IEVersion
    {
        private static uint GeoEmulationModee(int browserVersion)
        {
            uint num = (uint)browserVersion;
            //uint num = 0x2af8;
            switch (browserVersion)
            {
                case 7:
                    num = 0x1b58;
                    break;

                case 8:
                    num = 0x1f40;
                    break;

                case 9:
                    num = 0x2328;
                    break;

                case 10:
                    num = 0x2710;
                    break;

                case 11:
                    num = 0x2af8;
                    break;

                default:
                    break;
            }
            return num;
        }

        private static int GetBrowserVersion()
        {
            int result = 0;
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer", RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.QueryValues))
            {
                object obj2 = key.GetValue("svcVersion");
                if (obj2 == null)
                {
                    obj2 = key.GetValue("Version");
                    if (obj2 == null)
                    {
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                }
                char[] separator = new char[] { '.' };
                int.TryParse(obj2.ToString().Split(separator)[0], out result);
            }
            if (result < 7)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return result;
        }

        public static void SetWebBrowserFeatures(int ieVersion)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                string fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
                string str2 = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
                Registry.SetValue(str2 + "FEATURE_BROWSER_EMULATION", fileName, GeoEmulationModee(ieVersion), RegistryValueKind.DWord);
                Registry.SetValue(str2 + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1, RegistryValueKind.DWord);
            }
        }
    }

}
