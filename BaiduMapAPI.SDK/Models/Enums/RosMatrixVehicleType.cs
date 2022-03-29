using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 路网初始化需要的车型信息
    /// </summary>
    public enum RosMatrixVehicleType
    {
        /// <summary>
        /// 4.5米箱货
        /// </summary>
        [Description("4.5米箱货")]
        GB01=2,

        /// <summary>
        /// 小轿车
        /// </summary>
        [Description("小轿车")]
        SMALL=4,
    }
}
