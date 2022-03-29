using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点详情检索服务
    /// </summary>
    public class DetailResult : Models.ResponseOld
    {
        /// <summary>
        /// 详情结果集
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public List<SearchResultItem> Result { get; set; }
    }
}
