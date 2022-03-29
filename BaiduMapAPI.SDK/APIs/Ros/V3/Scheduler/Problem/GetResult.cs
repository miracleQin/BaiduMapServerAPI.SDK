using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V3.Scheduler.Problem
{
    /// <summary>
    /// 排单排线查询 结果
    /// </summary>
    public class GetResult : Models.ResponseNew
    {
        /// <summary>
        /// 排单排线计算任务ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 排单排线结果方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("solution")]
        public Solution Solution { get; set; }

    }

    /// <summary>
    /// 结果方案
    /// </summary>
    public class Solution 
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
        /// 车辆分配线路方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }

    /// <summary>
    /// 车辆分配线路方案
    /// </summary>
    public class Route 
    {
        /// <summary>
        /// 路线唯一标识符
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 该路线使用的车辆型号ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModelId")]
        public string VehicleModelID { get; set; }

        /// <summary>
        /// 该路线车辆行驶里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("travelDistance")]
        public double? TravelDistance { get; set; }

        /// <summary>
        /// 该路线车辆行驶时间
        /// <para>单位：分钟</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("travelTime")]
        public double? TravelTime { get; set; }

        /// <summary>
        /// 车辆起始点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("startLocation")]
        public StartLocation StartLocation { get; set; }

        /// <summary>
        /// 配送路线规划
        /// </summary>
        [Newtonsoft.Json.JsonProperty("roadPlans")]
        public List<RoadPlan> RoadPlans { get; set; }


        /// <summary>
        /// 路线信息说明
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routeMessage")]
        public RouteMessage RouteMessage { get; set; }
    }

    /// <summary>
    /// 车辆起始点信息
    /// </summary>
    public class StartLocation 
    {
        /// <summary>
        /// 仓点ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locationId")]
        public string LocationID { get; set; }

        /// <summary>
        /// 起始点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// 出发时间
        /// <para>单位：分钟</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departureTime")]
        public double? DepartureTime { get; set; }
    }

    /// <summary>
    /// 起始点坐标
    /// </summary>
    public class Coordinate : Models.LocationDetail 
    {
        /// <summary>
        /// 地址
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }
    }

    /// <summary>
    /// 配送路线规划
    /// </summary>
    public class RoadPlan 
    {
        /// <summary>
        /// 网点ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobId")]
        public string ServiceJobID { get; set; }

        /// <summary>
        /// 网点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }


        /// <summary>
        /// 到达网点时间
        /// <para>单位：分钟</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arrivalTime")]
        public double? ArrivalTime { get; set; }

        /// <summary>
        /// 离开网点时间
        /// <para>单位：分钟</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departureTime")]
        public double? DepartureTime { get; set; }

        /// <summary>
        /// 行驶路线坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routeCoordinates")]
        public List<Coordinate> RouteCoordinates { get; set; }
    }

    /// <summary>
    /// 路线信息说明
    /// </summary>
    public class RouteMessage 
    {

        /// <summary>
        /// 路线信息码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 路线信息描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }
    }
}
