using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 行业类型
    /// </summary>
    public enum IndustryType
    {
        /// <summary>
        /// 宾馆
        /// </summary>
        [Description("宾馆")]
        hotel,
        /// <summary>
        /// 餐饮
        /// </summary>
        [Description("餐饮")]
        cater,
        /// <summary>
        /// 生活娱乐
        /// </summary>
        [Description("生活娱乐")]
        life,
    }
}
