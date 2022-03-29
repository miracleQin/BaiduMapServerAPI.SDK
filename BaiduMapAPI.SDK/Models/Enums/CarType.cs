using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 车辆类型
    /// </summary>
    public enum CarType
    {
        /// <summary>
        /// 普通汽车
        /// </summary>
        [Description("普通汽车")]
        NomarlCar=0,

        /// <summary>
        /// 电动汽车
        /// </summary>
        [Description("电动汽车")]
        ElectricCar=1,
    }
}
