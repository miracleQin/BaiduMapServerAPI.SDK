using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum LbsType
    {
        /// <summary>
        /// 时间优先
        /// </summary>
        [Description("时间优先")]
        LEAST_TIME = 2,

        /// <summary>
        /// 距离最短
        /// </summary>
        [Description("距离最短")]
        LEAST_DISTANCE = 4,

        /// <summary>
        /// 不走高速
        /// <para>客户可以根据自己场景填写</para>
        /// </summary>
        [Description("不走高速")]
        NO_HIGHWAY = 8,
    }
}
