using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 多点有序排单计算
    /// </summary>
    public class OrderedResult : Models.ResponseNew
    {
        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }
    }
}
