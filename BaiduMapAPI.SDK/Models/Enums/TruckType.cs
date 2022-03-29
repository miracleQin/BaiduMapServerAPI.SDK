using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 卡车类型
    /// </summary>
    public enum TruckType
    {
        /// <summary>
        /// 微卡车
        /// </summary>
        [Description("微卡车")]
        MicroTruck = 1,

        /// <summary>
        /// 轻卡车
        /// </summary>
        [Description("轻卡车")]
        LightTruck = 2,

        /// <summary>
        /// 中卡车
        /// </summary>
        [Description("中卡车")]
        MediumTruck = 3,

        /// <summary>
        /// 重卡车
        /// </summary>
        [Description("重卡车")]
        HeavyTruck = 4,
    }
}
