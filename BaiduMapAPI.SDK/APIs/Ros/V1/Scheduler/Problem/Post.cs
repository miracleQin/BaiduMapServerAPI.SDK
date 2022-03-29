using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 排单排线计算
    /// </summary>
    public class Post : Models.JsonPostWithoutSN<PostResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v1/scheduler/problem";

        /// <summary>
        /// 算法需要使用的场景类型(必填)
        /// <para>场景维度包含网点规模及排单结果路线交叉程度</para>
        /// <para>大规模场景要求网点数在600点以上，小规模场景网点数600点以下。聚集性为路线不交叉，但是成本不一定最低，通用性为路线可能交叉，但是成本最低</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("scenesType")]
        public ScenesType? ScenesType { get; set; }

        /// <summary>
        /// 路网矩阵ID(必填)
        /// <para>路网矩阵唯一标识码</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixId")]
        public string MatrixId { get; set; }

        /// <summary>
        /// 路网矩阵类型(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("路网矩阵类型")]
        public Models.Enums.LbsType? LbsType { get; set; }

        /// <summary>
        /// 路网矩阵版本ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("commitId")]
        public string CommitId { get; set; }


        /// <summary>
        /// 距离计算方式(必填)
        /// <para>直线距离计算场景必须设置车辆的平均行驶速度</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distanceType")]
        public Models.Enums.DistanceType? DistanceType { get; set; }

        /// <summary>
        /// 仓库信息列表(必填)
        /// <para>一期支持单仓</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depots")]
        public List<PostDepot> Depots { get; set; }

        /// <summary>
        /// 车辆型号信息(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModels")]
        public List<VehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// 网点信息列表(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobs")]
        public List<ServiceJob> ServiceJobs { get; set; }
    }

    /// <summary>
    /// 场景类型
    /// </summary>
    public enum ScenesType
    {
        /// <summary>
        /// 大规模聚集性场景
        /// </summary>
        [Description("大规模聚集性场景")]
        LARGE_SCALE_CLUSTER = 0,

        /// <summary>
        /// 小规模聚集性场景
        /// </summary>
        [Description("小规模聚集性场景")]
        SMALL_SCALE_CLUSTER = 1,

        /// <summary>
        /// 大规模通用场景
        /// </summary>
        [Description("大规模通用场景")]
        LARGE_SCALE_GENERAL=2,

        /// <summary>
        /// 小规模通用场景
        /// </summary>
        [Description("小规模通用场景")]
        SMALL_SCALE_GENERAL=3,
    }

    public class PostDepot 
    {
        /// <summary>
        /// 仓库ID(必填)
        /// <para>用户仓库自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 时间窗信息，时间约束条件，车辆最早出仓时间和最晚回仓时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotTimeWindow")]
        public TimeWindow DepotTimeWindow { get; set; }

        /// <summary>
        /// 该仓库的车辆组信息(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleGroups")]
        public List<VehicleGroup> VehicleGroups { get; set; }
    }

    /// <summary>
    /// 时间窗信息
    /// </summary>
    public class TimeWindow 
    {
        /// <summary>
        /// 起始时间
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(TimeSpanMinConverter))]
        [Newtonsoft.Json.JsonProperty("startTime")]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(TimeSpanMinConverter))]
        [Newtonsoft.Json.JsonProperty("startTime")]
        public TimeSpan EndTime { get; set; }
    }

    /// <summary>
    /// 车辆组信息
    /// </summary>
    public class VehicleGroup
    {

        /// <summary>
        /// 车辆类型ID(必填)
        /// <para>GB01（默认车辆长6000mm，宽2100mm，高3000mm）</para>
        /// <para>SMALL(小轿车，车辆长4000mm，宽2000mm，高2000mm)</para>
        /// <para>两种车辆类型的轴重轴数均为2。该信息用于道路货车限行规避，一个车辆类型会对应一个或多个型号的货车，由用户自行决定车辆型号与车辆类型的映射关系</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleTypeId")]
        public Models.Enums.RosMatrixVehicleType? VehicleTypeID { get; set; }

        /// <summary>
        /// 车辆型号ID(必填)
        /// <para>用户自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModelId")]
        public string VehicleModelID { get; set; }

        /// <summary>
        /// 该型号车数量(必填)
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleCount")]
        public int? VehicleCount { get; set; }

        /// <summary>
        /// 车辆允许运送的最小订单数量
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("minVisited")]
        public int? MinVisited { get; set; }

        /// <summary>
        /// 车辆允许运送的最大订单数量
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxVisited")]
        public int? MaxVisited { get; set; }


        /// <summary>
        /// 车辆最大行驶距离
        /// <para>单位:米</para>
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxRunDistance")]
        public int? MaxRunDistance { get; set; }

        /// <summary>
        /// 车辆最大行驶时间
        /// <para>单位:分钟</para>
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxRunTime")]
        public int? MaxRunTime { get; set; }

        /// <summary>
        /// 车辆可运输的货物类型列表
        /// <para>车辆具备某种运输能力，如冷冻功能、运输危化品能力等</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleSkills")]
        public List<string> VehicleSkills { get; set; }

        /// <summary>
        /// 是否回仓
        /// <para>默认回仓</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("returnToDepot")]
        public bool? ReturnToDepot { get; set; }
    }

    /// <summary>
    /// 车辆型号信息
    /// </summary>
    public class VehicleModel 
    {
        /// <summary>
        /// 车辆型号ID(必填)
        /// <para>车辆型号ID</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModelId")]
        public string VehicleModelID { get; set; }

        /// <summary>
        /// 车辆额定承载(必填)
        /// <para>重量、体积、数量三个维度至少填写一个，车和货的维度保持一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("capacity")]
        public Capacity Capacity { get; set; }

        /// <summary>
        /// 车辆每公里行驶成本(必填)
        /// <para>单位：元/公里</para>
        /// <para>取值必须大于0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("perDistanceUnitPrice")]
        public double? PerDistanceUnitPrice { get; set; }

        /// <summary>
        /// 车辆每单位时间行驶成本
        /// <para>单位：元/分钟</para>
        /// <para>取值必须大于0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("perTimeUnitPrice")]
        public double? PerTimeUnitPrice { get; set; }

        /// <summary>
        /// 车辆固定损耗成本
        /// <para>单位：元/天</para>
        /// <para>默认值为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fixedCost")]
        public double? FixedCost { get; set; }

        /// <summary>
        /// 车辆等待成本
        /// <para>单位：元/分钟</para>
        /// <para>默认值为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("waitingCost")]
        public double? WaitingCost { get; set; }

        /// <summary>
        /// 平均车速
        /// <para>单位：千米/小时</para>
        /// <para>取值必须在0到120之间</para>
        /// <para>DistanceType为STRAIGHT时，该参数必填</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("averageVelocity")]
        public double? AverageVelocity { get; set; }

        /// <summary>
        /// 最大行驶速度
        /// <para>单位：千米/小时</para>
        /// <para>取值必须在0到120之间，且必须大于平均车速</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxVelocity")]
        public double? MaxVelocity { get; set; }
    }


    /// <summary>
    /// 车辆额定承载
    /// </summary>
    public class Capacity 
    {
        /// <summary>
        /// 装载重量
        /// <para>单位：千克</para>
        /// <para>精度：保留小数点后四位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// 装载体积
        /// <para>单位：立方米</para>
        /// <para>精度：保留小数点后四位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("volume")]
        public double? Volume { get; set; }

        /// <summary>
        /// 装载数量
        /// <para>精度：保留小数点后四位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("count")]
        public double? Count { get; set; }
    }

    /// <summary>
    /// 网点信息
    /// </summary>
    public class ServiceJob 
    {
        /// <summary>
        /// 网点ID(必填)
        /// <para> 用户自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobId")]
        public string ServiceJobID { get; set; }

        /// <summary>
        /// 网点停留时间
        /// <para>单位：分钟</para>
        /// <para>取值必须大于0</para>
        /// <para>默认值为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceStayDuration")]
        public double? ServiceStayDuration { get; set; }

        /// <summary>
        /// 网点待配送货物的量(必填)
        /// <para>重量、体积、数量三个维度至少填写一个，车和货的维度保持一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("demand")]
        public Capacity Demand { get; set; }

        /// <summary>
        /// 网点可配送的时间段列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceTimeWindows")]
        public List<TimeWindow> ServiceTimeWindows { get; set; }

        /// <summary>
        /// 需要运输的货物类型列表
        /// <para>车辆需要具备某种运输能力，如冷冻功能、运输危化品能力等</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("skills")]
        public List<string> Skills { get; set; }

        /// <summary>
        /// 订单优先级
        /// <para>取值范围必须为不小于1，不大于10</para>
        /// <para>数字越大代表优先级越高</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("priority")]
        public int? Priority { get; set; }
    }
}
