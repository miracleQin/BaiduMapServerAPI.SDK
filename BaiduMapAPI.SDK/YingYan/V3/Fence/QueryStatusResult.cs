using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询监控对象相对围栏的状态 结果
    /// </summary>
    public class QueryStatusResult : Models.ResponseOld
    {
        /// <summary>
        /// 总的查询结果数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 本页返回的结果数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// 报警的数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("monitored_statuses")]
        public List<MonitoredStatusInfo> MonitoredStatuses { get; set; }
    }

    /// <summary>
    /// 监控对象围栏状态信息
    /// </summary>
    public class MonitoredStatusInfo
    {
        /// <summary>
        /// 围栏 id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_id")]
        public int? FenceID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("monitored_status")]
        [Newtonsoft.Json.JsonConverter(typeof(CustomDescriptionConverter))]
        public MonitoredStatus? MonitoredStatus { get; set; }
    }

    /// <summary>
    /// 监控对象围栏状态
    /// </summary>
    public enum MonitoredStatus
    {
        /// <summary>
        /// 未知状态
        /// </summary>
        [CustomDescription("未知状态", "unknown")]
        unknown = 0,
        /// <summary>
        /// 未知状态
        /// </summary>
        [CustomDescription("未知状态", "in")]
        @in = 1,

        /// <summary>
        /// 未知状态
        /// </summary>
        [CustomDescription("未知状态", "out")]
        @out = 2,

    }
}
