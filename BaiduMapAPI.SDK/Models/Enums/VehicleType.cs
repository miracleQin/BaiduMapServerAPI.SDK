using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 公交线路类型
    /// </summary>
    public enum VehicleType
    {
        /// <summary>
        /// 普通日行公交车
        /// </summary>
        [Description("普通日行公交车")]
        OrdinaryDailyBus = 0,
        /// <summary>
        /// 地铁、轻轨
        /// </summary>
        [Description("地铁、轻轨")]
        Metro = 1,

        /// <summary>
        /// 机场巴士（前往机场）
        /// </summary>
        [Description("机场巴士（前往机场）")]
        AirportBusEntry = 2,

        /// <summary>
        /// 有轨电车
        /// </summary>
        [Description("有轨电车")]
        Tram = 3,

        /// <summary>
        /// 机场巴士（从机场返回）
        /// </summary>
        [Description("机场巴士（从机场返回）")]
        AirportBusExit = 4,

        /// <summary>
        /// 旅游线路车
        /// </summary>
        [Description("旅游线路车")]
        TourBus = 5,

        /// <summary>
        /// 夜班车
        /// </summary>
        [Description("夜班车")]
        NightBus = 6,

        /// <summary>
        /// 机场巴士（机场之间）
        /// </summary>
        [Description("机场巴士（机场之间）")]
        AirportBusBetweenAirports = 7,

        /// <summary>
        /// 轮渡
        /// </summary>
        [Description("轮渡")]
        Ferry = 8,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 9,

        /// <summary>
        /// 快车
        /// </summary>
        [Description("快车")]
        FastCar = 10,

        /// <summary>
        /// 慢车
        /// </summary>
        [Description("慢车")]
        SlowCar = 11,

        /// <summary>
        /// 机场快轨（前往机场）
        /// </summary>
        [Description("机场快轨（前往机场）")]
        AirportExpressRailEntry = 12,

        /// <summary>
        /// 机场快轨（从机场返回）
        /// </summary>
        [Description("机场快轨（从机场返回）")]
        AirportExpressRailExit = 13,

        /// <summary>
        /// 机场轨道交通环路
        /// </summary>
        [Description("机场轨道交通环路")]
        AirportRailTransitLoop = 14,

    }
}
