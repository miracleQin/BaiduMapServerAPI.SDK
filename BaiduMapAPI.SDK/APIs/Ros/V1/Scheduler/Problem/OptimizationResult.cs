using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 线内优化排单计算 结果
    /// </summary>
    public class OptimizationResult : Models.ResponseNew
    {
        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }
    }
}
