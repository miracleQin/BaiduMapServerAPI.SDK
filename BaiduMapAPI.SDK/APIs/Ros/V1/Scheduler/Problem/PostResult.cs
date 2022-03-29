using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 排单排线计算 结果
    /// </summary>
    public class PostResult : Models.ResponseNew
    {
        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }
    }
}
