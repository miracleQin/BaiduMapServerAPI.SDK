using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 动力类型
    /// </summary>
    public enum PowerType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All=0,

        /// <summary>
        /// 汽油
        /// </summary>
        [Description("汽油")]
        Gasoline=1,

        /// <summary>
        /// 柴油
        /// </summary>
        [Description("柴油")]
        DieselOil=2,

        /// <summary>
        /// 电动
        /// </summary>
        [Description("电动")]
        Electric=3,

        /// <summary>
        /// 混合
        /// </summary>
        [Description("混合")]
        Hybrid=4,
    }
}
