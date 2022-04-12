using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 批量查询所有围栏报警信息 结果
    /// </summary>
    public class BatchHistoryAlarmResult : HistoryAlarmResult
    {

        /// <summary>
        /// 符合条件的总报警数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }
    }
}
