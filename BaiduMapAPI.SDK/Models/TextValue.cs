using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 数值结果信息
    /// </summary>
    public class TextValue
    {
        /// <summary>
        /// 文本描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 数值
        /// </summary>
        [Newtonsoft.Json.JsonProperty("value")]
        public double? Value { get; set; }
    }
}
