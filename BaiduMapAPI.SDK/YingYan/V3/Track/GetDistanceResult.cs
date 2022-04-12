using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 一段时间内的轨迹里程，支持纠偏 结果
    /// </summary>
    public class GetDistanceResult : Models.ResponseOld
    {
        /// <summary>
        /// 轨迹里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 低速里程
        /// <para>单位：米</para>
        /// <para>若请求参数中填写了low_speed_threshold，则返回该字段，否则不返回代表速度低于low_speed_threshold的里程</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("low_speed_distance")]
        public double? LowSpeedDistance { get; set; }
    }
}
