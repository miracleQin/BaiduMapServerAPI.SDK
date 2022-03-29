using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.Problem
{
    /// <summary>
    /// 线内优化结果查询
    /// </summary>
    public class Optimization : Models.GetWithoutSNRequest<OptimizationResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v3/scheduler/problem/optimization";

        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Display(Name = "optimizationProblemId")]
        public string OptimizationProblemId { get; set; }
    }

}
