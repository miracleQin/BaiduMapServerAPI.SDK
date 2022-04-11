using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询围栏监控的所有entity 结果
    /// </summary>
    public class ListMonitoredPersonResult : Models.ResponseOld
    {
        /// <summary>
        /// 查询监控entity的总个数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 本页返回的entity个数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// entity列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("monitored_person")]
        public List<string> MonitoredPerson { get; set; }

    }
}
