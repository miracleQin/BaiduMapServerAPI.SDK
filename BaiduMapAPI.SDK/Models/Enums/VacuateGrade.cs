using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 抽稀力度
    /// </summary>
    public enum VacuateGrade
    {
        /// <summary>
        /// 不抽稀
        /// </summary>
        [Description("不抽稀")]
        leve0 = 0,
        /// <summary>
        /// 抽稀力度为1
        /// </summary>
        [Description("抽稀力度为1")]
        leve1 = 1,
        /// <summary>
        /// 抽稀力度为2
        /// </summary>
        [Description("抽稀力度为2")]
        leve2 = 2,
        /// <summary>
        /// 抽稀力度为3
        /// </summary>
        [Description("抽稀力度为3")]
        leve3 = 3,
        /// <summary>
        /// 抽稀力度为4
        /// </summary>
        [Description("抽稀力度为4")]
        leve4 = 4,
        /// <summary>
        /// 抽稀力度为5
        /// </summary>
        [Description("抽稀力度为5")]
        leve5 = 5,
    }
}
