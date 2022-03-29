using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 响应状态
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// 正在处理
        /// </summary>
        [Description("正在处理")]
        RUNNING = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        FINISHED = 1,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        ERROR = 2,
    }
}
