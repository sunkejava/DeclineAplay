using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclineAplay.Utils
{
    public class EDate
    {
        //如果好用，请收藏地址，帮忙分享。
        public class DataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string No { get; set; }
            /// <summary>
            /// 萬元作品 勁爆精品 秀人網嫩模拍 兔兔透視內褲現穴 豪乳嫩模無內露乳嫵媚寫真 完整版
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int IsVip { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int IsNeedLogin { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int Disabled { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int TypeID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string CoverImgUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int SeeCount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int CollectionCount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public decimal Point { get; set; }
            /// <summary>
            /// 时长 /60
            /// </summary>
            public int Length { get; set; }
            /// <summary>
            /// 精选系列,女神,酒店,自拍,制服诱惑,洗浴
            /// </summary>
            public string Tags { get; set; }
            /// <summary>
            /// 精选系列
            /// </summary>
            public string TypeName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int IsHot { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int IsRecomend { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string AddTime { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<DataItem> data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int recordsTotal { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int recordsFiltered { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int drow { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public decimal recordsSum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public decimal recordsSum2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
        }
    }
}
