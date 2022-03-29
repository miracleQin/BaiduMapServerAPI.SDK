using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.FastOrder
{
    /// <summary>
    /// 快速排单计算
    /// </summary>
    public class PostResult : Models.ResponseNew
    {
        /// <summary>
        /// 快速排单计算ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }
    }
}
