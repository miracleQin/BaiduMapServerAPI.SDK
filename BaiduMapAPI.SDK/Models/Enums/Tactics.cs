using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 路线偏好
    /// </summary>
    public enum Tactics
    {
        /// <summary>
        /// 常规路线
        /// <para>即多数用户常走的一条经验路线，满足大多数场景需求，是较推荐的一个策略</para>
        /// </summary>
        [Description("常规路线")]
        Normal = 0,

        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NOT_HightWay = 1,

        /// <summary>
        /// 躲避拥堵
        /// </summary>
        [Description("躲避拥堵")]
        NOT_TrafficJam = 2,

        /// <summary>
        /// 距离较短
        /// </summary>
        [Description("距离较短")]
        ShortWay = 3,
    }

    public enum TacticsDetail
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Normal = 0,

        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NOT_HightWay = 3,

        /// <summary>
        /// 高速优先
        /// </summary>
        [Description("高速优先")]
        HightWayFirst = 4,

        /// <summary>
        /// 躲避拥堵
        /// </summary>
        [Description("躲避拥堵")]
        NOT_TrafficJam = 5,

        /// <summary>
        /// 少收费
        /// </summary>
        [Description("少收费")]
        LowFee = 6,

        /// <summary>
        /// <![CDATA[躲避拥堵&高速优先]]> 
        /// </summary>
        [Description("躲避拥堵&高速优先")]
        NOT_TrafficJam_And_HightWayFirst = 7,

        /// <summary>
        /// 躲避拥堵且不走高速
        /// </summary>
        [Description("躲避拥堵&不走高速")]
        NOT_TrafficJam_AND_NOT_HightWay = 8,

        /// <summary>
        /// <![CDATA[躲避拥堵&少收费]]> 
        /// </summary>
        [Description("躲避拥堵&少收费")]
        NOT_TrafficJam_AND_LowFee = 9,

        /// <summary>
        /// 少收躲避拥堵且不走高速且少收费费
        /// </summary>
        [Description("躲避拥堵&不走高速&少收费")]
        NOT_TrafficJam_AND_NOT_HightWay_AND_LowFee = 10,

        /// <summary>
        /// 不走高速且少收费
        /// </summary>
        [Description("不走高速&少收费")]
        NOT_HightWay_AND_LowFee = 11,
    }

    public enum TacticsIncity
    {
        /// <summary>
        /// 推荐
        /// </summary>
        [Description("推荐")]
        Default = 0,

        /// <summary>
        /// 少换乘
        /// </summary>
        [Description("少换乘")]
        LessTransfer = 1,

        /// <summary>
        /// 少步行
        /// </summary>
        [Description("少步行")]
        LessWalking = 2,

        /// <summary>
        /// 不坐地铁
        /// </summary>
        [Description("不坐地铁")]
        NoSubway = 3,

        /// <summary>
        /// 时间短
        /// </summary>
        [Description("时间短")]
        ShortTime = 4,

        /// <summary>
        /// 地铁优先
        /// </summary>
        [Description("地铁优先")]
        MetroPriority = 5,
    }

    public enum TacticsIntercity
    {
        /// <summary>
        /// 时间短
        /// </summary>
        [Description("时间短")]
        ShortTime = 0,

        /// <summary>
        /// 出发早
        /// </summary>
        [Description("出发早")]
        EarlyDeparture = 1,

        /// <summary>
        /// 价格低
        /// </summary>
        [Description("价格低")]
        LowPrice = 2,


    }

    /// <summary>
    /// 路线规划驾车模式路线偏好
    /// </summary>
    public enum DirectionDrivingTactics
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Default = 0,

        /// <summary>
        /// 距离最短
        /// <para>只返回一条路线，不考虑限行和路况，距离最短且稳定，用于估价场景</para>
        /// </summary>
        [Description("距离最短")]
        ShortWay = 2,

        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NOT_HightWay = 3,

        /// <summary>
        /// 高速优先
        /// </summary>
        [Description("高速优先")]
        HightWayFirst = 4,

        /// <summary>
        /// 躲避拥堵
        /// </summary>
        [Description("躲避拥堵")]
        NOT_TrafficJam = 5,

        /// <summary>
        /// 少收费
        /// </summary>
        [Description("少收费")]
        LowFee = 6,

        /// <summary>
        /// <![CDATA[躲避拥堵&高速优先]]>
        /// </summary>
        [Description("躲避拥堵&高速优先")]
        NOT_TrafficJam_And_HightWayFirst = 7,

        /// <summary>
        /// 躲避拥堵且不走高速
        /// </summary>
        [Description("躲避拥堵&不走高速")]
        NOT_TrafficJam_AND_NOT_HightWay = 8,

        /// <summary>
        /// <![CDATA[躲避拥堵&少收费]]>
        /// </summary>
        [Description("躲避拥堵&少收费")]
        NOT_TrafficJam_AND_LowFee = 9,

        /// <summary>
        /// 少收躲避拥堵且不走高速且少收费费
        /// </summary>
        [Description("躲避拥堵&不走高速&少收费")]
        NOT_TrafficJam_AND_NOT_HightWay_AND_LowFee = 10,

        /// <summary>
        /// 不走高速且少收费
        /// </summary>
        [Description("不走高速&少收费")]
        NOT_HightWay_AND_LowFee = 11,

        /// <summary>
        /// 距离优先
        /// <para>考虑限行和路况，距离相对短且不一定稳定</para>
        /// </summary>
        [Description("距离优先")]
        ShortWayFirst = 12,
    }

    public enum LogisticsDirectionTruckTactics 
    {
        /// <summary>
        /// 常规路线
        /// <para>即多数用户常走的一条经验路线，满足大多数场景需求，是较推荐的一个策略</para>
        /// </summary>
        [Description("常规路线")]
        Normal = 0,

        /// <summary>
        /// 距离优先
        /// </summary>
        [Description("距离优先")]
        ShortWay = 1,

        /// <summary>
        /// 躲避拥堵
        /// </summary>
        [Description("躲避拥堵")]
        Less_HightWay = 3,


        /// <summary>
        /// 经济路线
        /// </summary>
        [Description("经济路线")]
        LessFee = 7 ,
    }
}
