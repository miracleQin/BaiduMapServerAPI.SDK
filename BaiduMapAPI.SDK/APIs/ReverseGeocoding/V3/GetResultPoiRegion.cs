using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 
    /// </summary>
    public class GetResultPoiRegion
    {
        /// <summary>
        /// 请求中的坐标与所归属区域面的相对位置关系
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction_desc")]
        public string DirectionDescription { get; set; }

        /// <summary>
        /// 归属区域面名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 归属区域面类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
