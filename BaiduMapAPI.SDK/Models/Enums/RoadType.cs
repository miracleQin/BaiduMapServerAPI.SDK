using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 道路类型
    /// </summary>
    public enum RoadType
    {
        /// <summary>
        /// 高速路
        /// </summary>
        [Description("高速路")]
        HightWay = 0,

        /// <summary>
        /// 城市高速路
        /// </summary>
        [Description("城市高速路")]
        CityHightWay = 1,


        /// <summary>
        /// 国道
        /// </summary>
        [Description("国道")]
        NationalRoad = 2,

        /// <summary>
        /// 省道
        /// </summary>
        [Description("省道")]
        ProvincialRoad = 3,

        /// <summary>
        /// 县道
        /// </summary>
        [Description("县道")]
        CountyRoad = 4,

        /// <summary>
        /// 乡镇村道
        /// </summary>
        [Description("乡镇村道")]
        TownshipVillageRoad = 5,

        /// <summary>
        /// 其他道路
        /// </summary>
        [Description("其他道路")]
        OtherRoad = 6,

        /// <summary>
        /// 九级路
        /// </summary>
        [Description("九级路")]
        Level9Road = 7,

        /// <summary>
        /// 航线(轮渡)
        /// </summary>
        [Description("航线(轮渡)")]
        FerryLinks = 8,

        /// <summary>
        /// 行人道路
        /// </summary>
        [Description("行人道路")]
        PedestrianRoad = 9,

    }
}
