using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.FastOrder
{
    /// <summary>
    /// 快速排单计算
    /// </summary>
    public class Post : Models.JsonPostWithoutSN<PostResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v1/scheduler/fastorder";

        /// <summary>
        /// 排单类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("orderType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public OrderType? OrderType { get; set; }

        /// <summary>
        /// 仓库信息
        /// <para>目前只支持单仓模式</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depots")]
        public List<FastOrderDepot> Depots { get; set; }
    }

    public class FastOrderDepot
    {
        /// <summary>
        /// 仓库ID
        /// <para>用户自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 仓库坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.LocationDetail Location { get; set; }

        /// <summary>
        /// 时间窗信息
        /// <para>精准排单场景按照仓库出发时间startTime的预测路况进行排单计算，建议设置实际的出仓时间来提升预估行驶里程及时间的准确度</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotTimeWindow")]
        public Problem.TimeWindow DepotTimeWindow { get; set; }

        /// <summary>
        /// 该仓库的车辆组信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleGroups")]
        public List<FastOrderVehicleGroup> VehicleGroups { get; set; }

        /// <summary>
        /// 车辆型号信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModels")]
        public List<Problem.VehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// 网点信息列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobs")]
        public List<FastOrderServiceJob> ServiceJobs { get; set; }
    }

    public class FastOrderVehicleGroup
    {
        /// <summary>
        /// 车辆类型ID(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleTypeId")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        /// 车辆允许运送的最大订单数量
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxVisited")]
        public int? MaxVisited { get; set; }

        /// <summary>
        /// 一次配送任务中，车辆的最大行驶距离
        /// <para>单位:米</para>
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxRunDistance")]
        public int? MaxRunDistance { get; set; }

        /// <summary>
        /// 一次配送任务中，车辆的最大行驶时间
        /// <para>单位:分钟</para>
        /// <para>不小于0，0代表没有限制</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxRunTime")]
        public int? MaxRunTime { get; set; }

        /// <summary>
        /// 是否回仓
        /// <para>默认回仓</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("returnToDepot")]
        public ReturnToDepot? ReturnToDepot { get; set; }

        /// <summary>
        /// 车辆起始坐标对应key(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departureLocationKey")]
        public string DepartureLocationKey { get; set; }


        /// <summary>
        /// 车辆起始坐标
        /// <para>不填默认为仓库坐标</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departureLocation")]
        public Models.LocationDetail DepartureLocation { get; set; }

        /// <summary>
        /// 车辆起始时间
        /// <para>单位:分钟</para>
        /// <para>取值范围大于0</para>
        /// <para>出发点为仓库时建议与出仓时间保持一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("startTime")]
        public int? StartTime { get; set; }

        /// <summary>
        /// 车辆结束时间
        /// <para>单位:分钟</para>
        /// <para>取值范围大于1</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("endTime")]
        public int? EndTime { get; set; }
    }


    public class FastOrderServiceJob : Problem.ServiceJob
    {

        /// <summary>
        /// 网点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.LocationDetail Location { get; set; }
    }
    /// <summary>
    /// 排单类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 极速排单
        /// <para>支持不高于1000个待配送网点的排单计算，采用直线距离的方式进行预估，计算速度快</para>
        /// </summary>
        [Description("极速排单")]
        FAST_ORDER = 0,

        /// <summary>
        /// 精准排单
        /// <para>支持不高于200个待配送网点的排单计算，采用真实的导航距离的方式进行计算，计算结果精准，速度相对于极速排单略慢</para>
        /// </summary>
        [Description("精准排单")]
        ACCURATE_ORDER = 1,
    }

    /// <summary>
    /// 是否回仓
    /// </summary>
    public enum ReturnToDepot
    {
        /// <summary>
        /// 回仓
        /// </summary>
        [Description("回仓")]
        Return = 1,

        /// <summary>
        /// 不回仓
        /// <para>不回仓的时候，默认车辆停留在配送的最后一个点</para>
        /// </summary>
        [Description("不回仓")]
        Unreturn = 2,
    }
}
