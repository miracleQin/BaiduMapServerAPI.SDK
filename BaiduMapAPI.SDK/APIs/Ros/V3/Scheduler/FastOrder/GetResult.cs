using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.FastOrder
{
    /// <summary>
    /// 快速排单查询
    /// </summary>
    public class GetResult : Models.ResponseNew
    {
        /// <summary>
        /// 快速排单计算任务ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 快速排单结果方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("solution")]
        public FastSolution Solution { get; set; }
    }

    /// <summary>
    /// 结果方案
    /// </summary>
    public class FastSolution 
    {
        /// <summary>
        /// 该方案车辆总行驶距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("totalTravelDistance")]
        public double? TotalTravelDistance { get; set; }

        /// <summary>
        /// 该方案车辆总行驶时间
        /// <para>单位：分钟</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("totalTravelTime")]
        public double? TotalTravelTime { get; set; }

        /// <summary>
        /// 最大装载率
        /// <para>最多分为三个维度（重量、体积、数量），与创建任务输入的车辆和网点维度一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxCapacityRate")]
        public List<double> MaxCapacityRate { get; set; }

        /// <summary>
        /// 平均装载率
        /// <para>最多分为三个维度（重量、体积、数量），与创建任务输入的车辆和网点维度一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("avgCapacityRate")]
        public List<double> AvgCapacityRate { get; set; }

        /// <summary>
        /// 车辆分配线路方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<FastOrderRoute> Routes { get; set; }
    }

    /// <summary>
    /// 车辆分配线路方案
    /// </summary>
    public class FastOrderRoute : Problem.Route
    {
        /// <summary>
        /// 该路线车辆装载率
        /// </summary>
        [Newtonsoft.Json.JsonProperty("capacityRate")]
        public List<double> CapacityRate { get; set; }
    }
}
