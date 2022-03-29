using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 
    /// </summary>
    public class GetResultRoad
    {
        /// <summary>
        /// 周边道路名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 传入的坐标点距离道路的大概距离
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public string Distance { get; set; }
    }
}
