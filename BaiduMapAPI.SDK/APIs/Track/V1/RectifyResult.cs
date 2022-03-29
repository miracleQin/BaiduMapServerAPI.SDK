using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 轨迹纠偏
    /// </summary>
    public class RectifyResult : Models.ResponseOld
    {
        /// <summary>
        /// 忽略掉page_index，page_size后的轨迹点数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 此段轨迹的里程数
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 此段轨迹的收费里程数
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public double? TollDistance { get; set; }


        /// <summary>
        /// 低速里程数
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("low_speed_distance")]
        public double? LowSpeedDistance { get; set; }
        
        /// <summary>
        /// 历史轨迹点列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("points")]

        public List<RectifyPointResult> Points { get; set; }
    }
}
