using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Multidepot
{
    /// <summary>
    /// 多仓排单排线计算
    /// </summary>
    public class Post : Models.JsonPostWithoutSN<PostResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v1/scheduler/multidepot";

        /// <summary>
        /// 算法需要使用的场景类型(必填)
        /// <para>大规模场景要求网点数在600点以上，小规模场景网点数600点以下。聚集性为路线不交叉，但是成本不一定最低，通用性为路线可能交叉，但是成本最低</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("scenesType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Problem.ScenesType? ScenesType { get; set; }

        /// <summary>
        /// 路网矩阵ID(必填)
        /// <para>路网矩阵唯一标识码</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixId")]
        public string MatrixID { get; set; }

        /// <summary>
        /// 路网矩阵类型(必填)
        /// <para>一期仅提供 LEAST_TIME：时间优先</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lbsType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.LbsType? LbsType { get; set; }

        /// <summary>
        /// 路网矩阵版本ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("commitId")]
        public string CommitID { get; set; }

        /// <summary>
        /// 距离计算方式(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distanceType")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.DistanceType? DistanceType { get; set; }

        /// <summary>
        /// 仓库信息列表
        /// <para>一期支持单仓</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depots")]
        public List<MultiDepotExternalDepot> Depots { get; set; }

        /// <summary>
        /// 车辆型号信息(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModels")]
        public List<ExternalVehicleModel> VehicleModels { get; set; }

        /// <summary>
        /// 网点信息列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobs")]
        public List<MultiDepotExternalServiceJob> ServiceJobs { get; set; }

        /// <summary>
        /// 车辆信息列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleGroups")]
        public List<MultiDepotExternalVehicleGroup> VehicleGroups { get; set; }
    }
    /// <summary>
    /// 仓库信息
    /// </summary>
    public class MultiDepotExternalDepot
    {
        /// <summary>
        /// 仓库ID
        /// <para>用户仓库自定义编码</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 时间窗信息
        /// <para>时间约束条件，车最早出仓时间和最晚回仓时间。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotTimeWindow")]
        public Problem.TimeWindow DepotTimeWindow { get; set; }


    }
    /// <summary>
    /// 车辆型号信息
    /// </summary>
    public class ExternalVehicleModel : Problem.VehicleModel
    {

    }
    /// <summary>
    /// 网点信息
    /// </summary>
    public class MultiDepotExternalServiceJob
    {
        /// <summary>
        /// 网点ID(必填)
        /// <para>用户自定义</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locationId")]
        public string LocationID { get; set; }

        /// <summary>
        /// 订单所属的父订单ID
        /// <para>用户自定义</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("parentId")]
        public string ParentID { get; set; }

        /// <summary>
        /// 订单所属的仓库ID
        /// <para>多仓使用，单仓可以为空</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 网点停留时间
        /// <para>单位：分钟</para>
        /// <para>默认值为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceStayDuration")]
        public double? ServiceStayDuration { get; set; }

        /// <summary>
        /// 网点待配送货物的量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("demand")]
        public Problem.Capacity Demand { get; set; }

        /// <summary>
        /// 网点时间窗列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceTimeWindows")]
        public List<Problem.TimeWindow> ServiceTimeWindows { get; set; }

        /// <summary>
        /// 仓库可存储的货物类型列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("skills")]
        public List<string> Skills { get; set; }

        /// <summary>
        /// 价格
        /// <para>取值不可小于0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price")]
        public double? Price { get; set; }

        /// <summary>
        /// 订单优先级
        /// <para>取值范围必须为不小于1，不大于10</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("priority")]
        public int? Priority { get; set; }
    }
    /// <summary>
    /// 车辆信息
    /// </summary>
    public class MultiDepotExternalVehicleGroup : Problem.VehicleGroup
    {

        /// <summary>
        /// 车辆所属仓库ID
        /// <para>用户仓库自定义编码</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 车辆可运输的时间窗
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceTimeWindow")]
        public Problem.TimeWindow ServiceTimeWindow { get; set; }
    }
}
