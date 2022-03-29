using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Scheduler.Problem
{
    /// <summary>
    /// 多点有序排单计算
    /// </summary>
    public class Ordered : Models.JsonPostWithoutSN<OrderedResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v1/scheduler/problem/ordered";

        /// <summary>
        /// 路网矩阵ID(必填)
        /// <para>路网矩阵唯一标识码</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixId")]
        public string MatrixID { get; set; }

        /// <summary>
        /// 路网矩阵类型(必填)
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
        /// 仓库ID(必填)
        /// <para>用户仓库自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotId")]
        public string DepotID { get; set; }

        /// <summary>
        /// 出仓时间
        /// <para>单位：分钟</para>
        /// <para>取值范围[0,1439]，默认为0</para>
        /// <para>例如，上午10点30分的取值为630</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("depotDepartureTime")]
        public int? DepotDepartureTime { get; set; }

        /// <summary>
        /// 车辆类型ID(必填)
        /// <para>目前支持GB01（默认车辆长6000mm，宽2100mm，高3000mm）以及SMALL(小轿车，车辆长4000mm，宽2000mm，高2000mm)，两种车辆类型的轴重轴数均为2。该信息用于道路货车限行规避，一个车辆类型会对应一个或多个型号的货车，由用户自行决定车辆型号与车辆类型的映射关系</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleTypeId")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.RosMatrixVehicleType? VehicleTypeID { get; set; }

        /// <summary>
        /// 车辆型号ID (必填)
        /// <para>用户自定义参数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicleModelId")]
        public string VehicleModelID { get; set; }

        /// <summary>
        /// 是否回仓
        /// <para>默认回仓</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("returnToDepot")]
        public bool? ReturnToDepot { get; set; }

        /// <summary>
        /// 车辆行驶的平均速度
        /// <para>单位：千米/小时</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("averageVelocity")]
        public double? AverageVelocity { get; set; }

        /// <summary>
        /// 最大行驶速度
        /// <para>单位：千米/小时</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("averageVelocity")]
        public double? MaxVelocity { get; set; }

        /// <summary>
        /// 网点信息列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("serviceJobs")]
        public List<ServiceJob> ServiceJobs { get; set; }
    }
}
