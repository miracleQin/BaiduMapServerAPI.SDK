using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.FastOrder
{
    /// <summary>
    /// 快速排单查询
    /// </summary>
    public class Get:Models.GetWithoutSNRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v3/scheduler/fastorder";

        /// <summary>
        /// 快速排单单号
        /// </summary>
        [Display(Name= "problemId")]
        public string ProblemID { get; set; }

        
    }
}
