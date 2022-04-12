using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 空间搜索通用结果
    /// </summary>
    public class SearchResult : ListResult
    {
        /// <summary>
        /// 关键字匹配的行政区划列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district_list")]
        public List<string> DistrictList { get; set; }
    }
}
