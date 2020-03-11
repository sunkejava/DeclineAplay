using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclineAplay.Utils
{
    public static class StaticUtils
    {
        /// <summary>
        /// 静态扩展转为json字符串
        /// </summary>
        /// <returns></returns>
        public static string toJsonString(this Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
