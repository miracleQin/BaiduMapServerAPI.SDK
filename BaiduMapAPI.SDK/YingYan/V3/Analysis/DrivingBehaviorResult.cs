using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Analysis
{
    /// <summary>
    /// 驾驶行为分析 结果
    /// </summary>
    public class DrivingBehaviorResult : Models.ResponseOld
    {

        /// <summary>
        /// 行程里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }


        /// <summary>
        /// 行程耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 平均时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("average_speed")]
        public double? AverageSpeed { get; set; }

        /// <summary>
        /// 最高时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("max_speed")]
        public double? MaxSpeed { get; set; }

        /// <summary>
        /// 超速次数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speeding_num")]
        public int? SpeedingNumber { get; set; }

        /// <summary>
        /// 急加速次数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_acceleration_num")]
        public int? HarshAccelerationNumber { get; set; }

        /// <summary>
        /// 急刹车次数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_breaking_num")]
        public int? HarshBreakingNumber { get; set; }

        /// <summary>
        /// 急转弯次数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_steering_num")]
        public int? HarshSteeringNumber { get; set; }

        /// <summary>
        /// 起点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_point")]
        public PointBase StartPoint { get; set; }

        /// <summary>
        /// 终点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_point")]
        public PointBase EndPoint { get; set; }

        /// <summary>
        /// 超速记录集合
        /// <para>超速记录集合是一个数组，数组中的每一项代表一次超速记录</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speeding")]
        public List<Speeding> Speedings { get; set; }

        /// <summary>
        /// 急加速记录集合
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_acceleration")]
        public List<HarshAcceleration> HarshAccelerations { get; set; }

        /// <summary>
        /// 急刹车记录集合
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_breaking")]
        public List<HarshAcceleration> HarshBreakings { get; set; }

        /// <summary>
        /// 急转弯记录集合
        /// </summary>
        [Newtonsoft.Json.JsonProperty("harsh_steering")]
        public List<HarshSteering> HarshSteerings { get; set; }
    }

    /// <summary>
    /// 基础轨迹点信息
    /// </summary>
    public class PointBase : Track.PointBase
    {
        /// <summary>
        /// 起点地址
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }
    }

    /// <summary>
    /// 超速信息
    /// </summary>
    public class Speeding 
    {
        /// <summary>
        /// 超速里程
        /// <para>单位：米</para>
        /// <para>本次超速的里程</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speeding_distance")]
        public double? SpeedingDistance { get; set; }

        /// <summary>
        /// 一条超速记录中的超速起点或终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speeding_points")]
        public List<SpeedingPoint> SpeedingPoints { get; set; }
    }

    /// <summary>
    /// 超速轨迹点信息
    /// </summary>
    public class SpeedingPoint : Track.PointBase
    {
        /// <summary>
        /// 实际行驶时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("actual_speed")]
        public double? ActualSpeed { get; set; }

        /// <summary>
        /// 所在道路限定最高时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("limit_speed")]
        public double? LimitSpeed { get; set; }
    }

    /// <summary>
    /// 急加速记录
    /// </summary>
    public class HarshAcceleration : Track.PointBase 
    {
        /// <summary>
        /// 实际加速度
        /// <para>单位：m/s^2</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("acceleration")]
        public double? Acceleration { get; set; }

        /// <summary>
        /// 加速前时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("initial_speed")]
        public double? InitialSpeed { get; set; }

        /// <summary>
        /// 加速后时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_speed")]
        public double? EndSpeed { get; set; }
    }

    /// <summary>
    /// 急转弯记录
    /// </summary>
    public class HarshSteering 
    {
        /// <summary>
        /// 向心加速度
        /// <para>单位：m/s^2</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("centripetal_acceleration")]
        public double? CentripetalAcceleration { get; set; }

        /// <summary>
        /// 转向类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("turn_type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TurnType? TurnType { get; set; }

        /// <summary>
        /// 转向时速
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_speed")]
        public double? Speed { get; set; }
    }

    /// <summary>
    /// 转弯类型
    /// </summary>
    public enum TurnType 
    {
        /// <summary>
        /// 方向未知
        /// </summary>
        [Description("方向未知")]
        unknow=0,

        /// <summary>
        /// 左转
        /// </summary>
        [Description("左转")]
        left=1,

        /// <summary>
        /// 右转
        /// </summary>
        [Description("右转")]
        right = 2,
    }
}
