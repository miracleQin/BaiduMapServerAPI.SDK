using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 骑行模式
    /// </summary>
    public enum RidingType
    {
        /// <summary>
        /// 普通自行车
        /// </summary>
        [Description("普通自行车")]
        Bike = 0,

        /// <summary>
        /// 电动自行车
        /// </summary>
        [Description("电动自行车")]
        EBike = 1,
    }
}
