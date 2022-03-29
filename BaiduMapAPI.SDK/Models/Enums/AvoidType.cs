using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 货车政策交规（如交通部门发布的分时段区域限行政策）剥离
    /// </summary>
    public enum AvoidType
    {
        /// <summary>
        /// 政策交规默认生效
        /// </summary>
        [Description("政策交规默认生效")]
        Default = 0,

        /// <summary>
        /// 算路时忽略针对货车的政策交规
        /// <para>道路上实体交通标牌限制仍正常生效</para>
        /// </summary>
        [Description("算路时忽略针对货车的政策交规")]
        Ignore = 1,
    }
}
