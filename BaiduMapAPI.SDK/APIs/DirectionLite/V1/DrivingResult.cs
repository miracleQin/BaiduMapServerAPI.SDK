using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.DirectionLite.V1
{
    /// <summary>
    /// 驾车规划返回参数
    /// </summary>
    public class DrivingResult : Models.ResponseOld
    {
        /// <summary>
        /// 结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public DrivingResultResult Result { get; set; }
    }



    /// <summary>
    /// 驾车规划返回结果
    /// </summary>
    public class DrivingResultResult {
        /// <summary>
        /// 起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public Models.Location Destination { get; set; }

        /// <summary>
        /// 返回的方案集
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<DrivingResultRoute> Routes { get; set; }

    }

    /// <summary>
    /// 驾车规划返回方案
    /// </summary>
    public class DrivingResultRoute 
    {
        /// <summary>
        /// 方案距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 线路耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        /// 路线的过路费预估
        /// <para>单位：元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public double? Toll { get; set; }

        /// <summary>
        /// 路线的整体路况评价
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public Models.Enums.TrafficCondition? TrafficCondition { get; set; }

        /// <summary>
        /// 路线分段
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<DrivingResultStep> Steps { get; set; }
    }

    /// <summary>
    /// 路线分段
    /// </summary>
    public class DrivingResultStep 
    {
        /// <summary>
        /// 途径点序号
        /// <para>途径点序号为从0开始的整数，用于标识step所属的途径点路段</para>
        /// <para>如：若该step属于起点至第一个途径中的路段，则其leg_index为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("leg_index")]
        public int? LegIndex { get; set; }

        /// <summary>
        /// 进入道路的角度
        /// <para>角度为与正北方向顺时针夹角</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public Models.Enums.DirectionType? Direction { get; set; }

        /// <summary>
        /// 机动转向点
        /// <para>包括基准八个方向、环岛、分歧等</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("turn")]
        public Models.Enums.TurnType? Turn { get; set; }

        /// <summary>
        /// 路段距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 路段耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        /// 分段的道路类型
        /// <para>该字段后续将废弃，由road_types代替</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_type")]
        public Models.Enums.RoadType? RoadType { get; set; }

        /// <summary>
        /// 路段途径的道路类型列表
        /// <para>若途经多个路段类别，将用英文逗号","分隔</para>
        /// <para>如：- 该路段依次途经国道和省道两种道路类型，则road_types:"2,3"</para>
        /// <para>该路段仅途经高速，则road_types:"0"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_types")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.EnumListConverter))]
        public List<Models.Enums.RoadType> RoadTypes { get; set; }


        /// <summary>
        /// 路段描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("instruction")]
        public string Instruction { get; set; }

        /// <summary>
        /// 分段起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_location")]
        public Models.Location StartLocation { get; set; }

        /// <summary>
        /// 分段终点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_location")]
        public Models.Location EndLocation { get; set; }

        /// <summary>
        /// 分段坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Paths { get; set; }

        /// <summary>
        /// 分段路况详情
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public List<DrivingResultTrafficCondition> TrafficCondition { get; set; }
    }

    /// <summary>
    /// 分段路况详情
    /// </summary>
    public class DrivingResultTrafficCondition 
    {
        /// <summary>
        /// 路况指数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public Models.Enums.TrafficCondition? Status { get; set; }

        /// <summary>
        /// 路况相同的坐标点个数
        /// <para>从当前坐标点开始，path中路况相同的坐标点个数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("geo_cnt")]
        public int? GeoCount { get; set; }
    }
}
