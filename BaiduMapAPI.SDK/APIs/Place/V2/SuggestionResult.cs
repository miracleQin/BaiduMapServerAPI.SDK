using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点输入提示服务
    /// </summary>
    public class SuggestionResult : Models.ResponseOld
    {
        /// <summary>
        /// 结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public List<SuggestionResultItem> Result { get; set; }
    }
}
