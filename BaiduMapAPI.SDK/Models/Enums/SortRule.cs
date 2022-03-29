using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 排序规则
    /// </summary>
    public enum SortRule
    {
        /// <summary>
        /// 从低到高
        /// </summary>
        [Description("从低到高")]
        Asc = 1,

        /// <summary>
        /// 从高到低
        /// </summary>
        [Description("从高到低")]
        Desc = 0,
    }
}
