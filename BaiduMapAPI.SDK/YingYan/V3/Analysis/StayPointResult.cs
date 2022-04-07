using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Analysis
{
    /// <summary>
    /// 停留点分析 结果
    /// </summary>
    public class StayPointResult : Models.ResponseOld
    {
        /// <summary>
        /// 停留次数
        /// <para>本段行程中停留次数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("staypoint_num")]
        public int? StayPointNumber { get; set; }

        /// <summary>
        /// 停留记录列表
        /// <para>数组中每个元素代表一次停留，记录一个停留点坐标</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stay_points")]
        public List<StayPointInfo> StayPoints { get; set; }

    }

    /// <summary>
    /// 停留点信息
    /// </summary>
    public class StayPointInfo 
    {
        /// <summary>
        /// 停留开始时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 停留结束时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 停留时长
        /// <para>单位：秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 停留点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stay_point")]
        public StayPointLocation StayPoint { get; set; }
    }

    /// <summary>
    /// 停留点坐标信息
    /// </summary>
    public class StayPointLocation : Models.LocationDetail
    {
        /// <summary>
        /// 坐标类型
        /// <para>该字段仅在海外区域时返回，返回值为：wgs84。当坐标位于国内（含港、澳、台）时，返回坐标类型与请求参数 coord_type_output 所设一致，因此不再返回该字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type")]
        public Models.Enums.CoordType? CoorType { get; set; }
    }
}
