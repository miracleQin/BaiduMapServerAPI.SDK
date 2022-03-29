using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// ETA时间戳
    /// </summary>
    public enum EtaTimestamp
    {
        /// <summary>
        /// 实时ETA
        /// </summary>
        [Description("实时ETA")]
        ActualTime = 0,

        /// <summary>
        /// 静态ETA（历史均值）
        /// </summary>
        [Description("静态ETA（历史均值）")]
        Static = 1,
    }
}
