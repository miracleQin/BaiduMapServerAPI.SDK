using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.Problem
{
    /// <summary>
    /// 多点有序排单查询
    /// </summary>
    public class Ordered : Models.GetWithoutSNRequest<OrderedResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v3/scheduler/problem/ordered";

        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Display(Name = "orderedProblemId")]
        public string OrderedProblemID { get; set; }
    }
}
