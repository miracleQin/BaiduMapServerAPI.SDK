using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 线内优化排单计算
    /// </summary>
    public class Optimization : Models.JsonPostWithoutSN<OptimizationResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v1/scheduler/problem/optimization";
    }
}
