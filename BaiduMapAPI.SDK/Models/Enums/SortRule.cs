using BaiduMapAPI.Models.Attributes;
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
        [CustomDescription("从低到高","asc")]
        Asc = 1,

        /// <summary>
        /// 从高到低
        /// </summary>
        [CustomDescription("从高到低","desc")]
        Desc = 0,
    }
}
