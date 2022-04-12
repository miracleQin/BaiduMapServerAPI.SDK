using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.FrequentRoute
{
    /// <summary>
    /// 创建一个任务，该任务完成后可通过getjob接口查询计算出的经验路线 结果
    /// </summary>
    public class CreateJobResult : Models.ResponseOld
    {
        /// <summary>
        /// 数据结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data")]
        public Data Data { get; set; }
    }

    /// <summary>
    /// 数据结果
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 经验路线条数
        /// <para>代表一共有分析出多少条经验路线</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 经验路线列表
        /// <para>每条经验路线取一条实际轨迹作为代表。</para>
        /// <para>返回的路线将按出行频率从高至低排序，并剔除了里程过短、轨迹点数过少的经验路线。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }

    /// <summary>
    /// 经验路线
    /// </summary>
    public class Route
    {
        /// <summary>
        /// 路线出行频率
        /// <para>出行频率为该经验路线的原始行程个数/总行程个数，保留小数点后2位。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("frequency")]
        public double? Frequency { get; set; }

        /// <summary>
        /// 路线距离
        /// <para>单位：米</para>
        /// <para>保留小数点后2位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 路线耗时
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 出发时间区间
        /// <para>该经验路线用户出发的最早和最晚时间，格式：hh:mm:ss, hh:mm:ss</para>
        /// <para>示例："start_time_range":"7:8:51,13:32:52"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_time_range")]
        [Newtonsoft.Json.JsonConverter(typeof(TimeRangeConverter))]
        public TimeRange StartTimeRange { get; set; }

        /// <summary>
        /// 到达时间区间
        /// <para>该经验路线用户到达的最早和最晚时间，格式：hh:mm:ss, hh:mm:ss</para>
        /// <para>示例："end_time_range":"7:8:51,13:32:52"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_time_range")]
        [Newtonsoft.Json.JsonConverter(typeof(TimeRangeConverter))]
        public TimeRange EndTimeRange { get; set; }

        /// <summary>
        /// 起点
        /// <para>保留小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_point")]
        public Models.LocationDetail StartPoint { get; set; }

        /// <summary>
        /// 终点
        /// <para>保留小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_point")]
        public Models.LocationDetail EndPoint { get; set; }

        /// <summary>
        /// 经验路线轨迹点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("points")]
        public List<Point> Points { get; set; }
    }

    /// <summary>
    /// 时间范围信息
    /// </summary>
    public class TimeRange
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public TimeSpan? Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public TimeSpan? End { get; set; }
    }

    /// <summary>
    /// 经验路线轨迹点
    /// </summary>
    public class Point : Models.LocationDetail 
    {
        /// <summary>
        /// 定位时的设备时间
        /// <para>若是原始轨迹点位置纠正后的点，则loc_time为原始轨迹点的定位时间</para>
        /// <para>若是鹰眼通过绑路补充的道路形状点（标识为_supplement=1），则loc_time使用了前序原始轨迹点的定位时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 方向
        /// <para>范围为[0,359]，0度为正北方向，顺时针</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 高度
        /// <para>只在GPS定位结果时才返回，单位米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// 速度
        /// <para>单位：千米/小时</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }
    }
}
