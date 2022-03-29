using BaiduMapAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 行政区划区域检索
    /// </summary>
    public class SearchResult : Models.ResponseOld
    {
        /// <summary>
        /// POI检索总数
        /// <para>开发者请求中设置了page_num字段才会出现total字段。出于数据保护目的，单次请求total最多为150。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        

        /// <summary>
        /// 结果类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result_type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SearchResultType? ResultType { get; set; }

        /// <summary>
        /// 查询到的结果集
        /// </summary>
        [Newtonsoft.Json.JsonProperty("results")]
        public List<SearchResultItem> Results { get; set; }
    }
}
