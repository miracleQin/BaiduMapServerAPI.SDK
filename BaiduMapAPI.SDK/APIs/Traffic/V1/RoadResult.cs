using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 道路路况查询结果
    /// </summary>
    public class RoadResult : Models.ResponseOld
    {
        /// <summary>
        /// 路况语义化描述
        /// <para>如："东四北大街：双向行驶缓慢；南向北，北新桥地铁站附近严重拥堵。"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 路况整体评估
        /// </summary>
        [Newtonsoft.Json.JsonProperty("evaluation")]
        public Evaluation Evaluation { get; set; }

        /// <summary>
        /// 路况详细信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_traffic")]
        public List<RoadTraffic> RoadTraffic { get; set; }
    }

    /// <summary>
    /// 路况整体评估
    /// </summary>
    public class Evaluation
    {
        /// <summary>
        /// 路况整体评价
        /// <para>道路的整体拥堵评价，较status更为细致，分为：畅通、较为畅通、缓行、轻微拥堵、拥堵、严重拥堵</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public CongestionSectionStatus? Status { get; set; }


        /// <summary>
        /// 路况整体评价的语义化描述
        /// <para>如："双向拥堵"或"东向西拥堵，西向东畅通"等。</para>
        /// <para>注意：路况整体评价关注的是道路整体拥堵情况，对于距离较长如：高速路、城市环路、复杂立交桥等，由于道路距离过长路况差异较大，整体拥堵评价可能与用户在具体路段的感知存在差异。此外，目前尚不支持对复杂多方向道路如立交桥、复杂道路等进行详细的分方向播报</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status_desc")]
        public string StatusDescription { get; set; }
    }

    /// <summary>
    /// 路况详细信息
    /// </summary>
    public class RoadTraffic
    {
        /// <summary>
        /// 道路名称
        /// <para>如："信息路"、"北五环"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_name")]
        public string RoadName { get; set; }

        /// <summary>
        /// 拥堵路段详情
        /// <para>若道路上有拥堵路段，则返回该字段。</para>
        /// <para>若无拥堵路段，则不返回该字段</para>
        /// <para>注意：拥堵路段是依据拥堵情况、车流量、拥堵距离等因素综合计算得到，并不完全参考拥堵情况</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("congestion_sections")]
        public List<CongestionSection> CongestionSections { get; set; }
    }

    /// <summary>
    /// 拥堵路段详情
    /// </summary>
    public class CongestionSection
    {
        /// <summary>
        /// 拥堵路段详情
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public CongestionSectionStatus? Status { get; set; }


        /// <summary>
        /// 路段拥堵语义化描述
        /// <para>如：南向北，北新桥地铁站附近严重拥堵</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("section_desc")]
        public string StatusDescription { get; set; }

        /// <summary>
        /// 平均通行速度
        /// <para>单位：千米/小时</para>
        /// <para>当前路段的平均通行速度</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }


        /// <summary>
        /// 拥堵距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("congestion_distance")]
        public int? CongestionDistance { get; set; }

        /// <summary>
        /// 较10分钟前拥堵趋势
        /// <para>相较10分钟前拥堵变化情况，支持以下值：</para>
        /// <para>持平：与10分钟前变化不大</para>
        /// <para>缓解：较10分钟前拥堵有所缓解</para>
        /// <para>加重：较10分钟前拥堵加重</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("congestion_trend")]
        public string CongestionTrend { get; set; }
    }

    /// <summary>
    /// 路段拥堵评价
    /// </summary>
    public enum CongestionSectionStatus
    {
        /// <summary>
        /// 未知路况
        /// </summary>
        [Description("未知路况")]
        Unknow = 0,

        /// <summary>
        /// 畅通
        /// </summary>
        [Description("畅通")]
        Unblocked = 1,

        /// <summary>
        /// 缓行
        /// </summary>
        [Description("缓行")]
        Amble = 2,

        /// <summary>
        /// 拥堵
        /// </summary>
        [Description("拥堵")]
        Congested = 3,

        /// <summary>
        /// 严重拥堵
        /// </summary>
        [Description("严重拥堵")]
        HeavilyCongested = 4,
    }
}
