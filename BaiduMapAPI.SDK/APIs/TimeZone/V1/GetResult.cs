using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.TimeZone.V1
{
    /// <summary>
    /// 时区服务结果
    /// <para>注：请求位置的实际时间=传入的timestamp+ dst_offset+ raw_offset</para>
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 所在时区ID字符串
        /// <para>https://zh.wikipedia.org/wiki/%E6%97%B6%E5%8C%BA%E5%88%97%E8%A1%A8</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("timezone_id")]
        public string TimeZoneID { get; set; }

        /// <summary>
        /// 夏令时(Daylight Saving Time：DST)时间偏移秒数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("dst_offset")]
        public int? DaylightSavingTimeOffset { get; set; }

        /// <summary>
        /// 坐标点位置时间较协调世界时偏移秒数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("raw_offset")]
        public int? RawOffset { get; set; }
    }
}
