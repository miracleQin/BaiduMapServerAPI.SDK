using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.Problem
{
    /// <summary>
    /// 线内优化结果查询
    /// </summary>
    public class OptimizationResult : Models.ResponseNew
    {
        /// <summary>
        /// 车辆线路方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("route")]
        public Route Route { get; set; }
    }

}
