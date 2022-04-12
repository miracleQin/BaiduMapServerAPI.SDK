using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.LogisticsDirection.V1
{

    /// <summary>
    /// 货车路线规划
    /// </summary>
    public class TruckResult : Models.ResponseOld
    {
        /// <summary>
        /// 返回的结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public TruckResultResult Result { get; set; }
    }

    /// <summary>
    /// 规划结果
    /// </summary>
    public class TruckResultResult
    {
        /// <summary>
        /// 车牌限行信息（城市级别）
        /// <para>若一条路线触发多个限行，仅返回其中一个</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restriction")]
        public TruckResultRestriction Restriction { get; set; }

        /// <summary>
        /// 返回方案的总数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 路线扩展信息
        /// <para>如session_id，算路时间等，json结构字符串，原样透传</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routesinfo_ext")]
        public string RoutesinfoExt { get; set; }

        /// <summary>
        /// 返回的方案集
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<TruckResultRoute> Routes { get; set; }
    }

    /// <summary>
    /// 车牌限行信息
    /// </summary>
    public class TruckResultRestriction
    {
        /// <summary>
        /// 限行类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.RestrictionType? Type { get; set; }

        /// <summary>
        /// 限行信息的文字
        /// </summary>
        [Newtonsoft.Json.JsonProperty("info")]
        public string Info { get; set; }
    }

    /// <summary>
    /// 方案
    /// </summary>
    public class TruckResultRoute
    {
        /// <summary>
        /// 起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public Models.Location Destination { get; set; }

        /// <summary>
        /// 方案标签
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 轨迹索引
        /// <para>和输入的多段经验轨迹对应，说明此路线是参考哪个经验轨迹点计算的</para>
        /// <para>-1: 不参考经验轨迹点计算的路线</para>
        /// <para>>=0: 和经验轨迹点对应，索引从0开始</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("track_idx")]
        public int? TrackIndex { get; set; }

        /// <summary>
        /// 未规避的避让区域索引
        /// <para>从0开始，如都已规避，则返回空字符串</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("unavoid_polygons_idx")]
        public int? UnavoidPolygonsIndex { get; set; }

        /// <summary>
        /// 方案距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 线路耗时
        /// <para>单位：秒（历史eta）</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 此路线道路收费
        /// <para>单位：元</para>
        /// <para>注：该字段为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <![CDATA[https://lbs.baidu.com/apiconsole/fankui#?typeOne=%E4%BA%A7%E5%93%81%E9%9C%80%E6%B1%82&typeTwo=%E9%AB%98%E7%BA%A7%E6%9C%8D%E5%8A%A1&typeThree=%E8%B4%A7%E8%BD%A6%E5%AF%BC%E8%88%AA]]>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public int? Toll { get; set; }

        /// <summary>
        /// 收费路段里程
        /// <para>单位：米</para>
        /// <para>注：该字段为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <![CDATA[https://lbs.baidu.com/apiconsole/fankui#?typeOne=%E4%BA%A7%E5%93%81%E9%9C%80%E6%B1%82&typeTwo=%E9%AB%98%E7%BA%A7%E6%9C%8D%E5%8A%A1&typeThree=%E8%B4%A7%E8%BD%A6%E5%AF%BC%E8%88%AA]]>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public double? TollDistance { get; set; }


        /// <summary>
        /// 油费
        /// <para>单位:元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("oil_cost")]
        public double? OilCost { get; set; }

        /// <summary>
        /// 路线分段
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<TruckResultStep> Steps { get; set; }
    }

    /// <summary>
    /// 路线分段信息
    /// </summary>
    public class TruckResultStep
    {

        /// <summary>
        /// 途径点序号
        /// <para>为从0开始的整数，用于标识step所属的途径点路段</para>
        /// <para>如：若该step属于起点至第一个途径中的路段，则其leg_index为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("leg_index")]
        public int? LegIndex { get; set; }


        /// <summary>
        /// 进入道路的角度。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public Models.Enums.DirectionType? Direction { get; set; }

        /// <summary>
        /// step的距离信息
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 线路耗时
        /// <para>单位：秒</para>
        /// <para>若选择实时ETA，则返回考虑实时路况的ETA</para>
        /// <para>若选择静态ETA，则返回一个历史估值ETA</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 经过的城市列表
        /// <para>市级，英文逗号分隔</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcodes")]
        public string ADCodes { get; set; }

        /// <summary>
        /// 分段的道路名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_name")]
        public string RoadName { get; set; }

        /// <summary>
        /// 分段的道路类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_type")]
        public Models.Enums.RoadType? RoadType { get; set; }

        /// <summary>
        /// 收费站名称
        /// <para>注：该字段为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <![CDATA[https://lbs.baidu.com/apiconsole/fankui#?typeOne=%E4%BA%A7%E5%93%81%E9%9C%80%E6%B1%82&typeTwo=%E9%AB%98%E7%BA%A7%E6%9C%8D%E5%8A%A1&typeThree=%E8%B4%A7%E8%BD%A6%E5%AF%BC%E8%88%AA]]>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_gate_name")]
        public string TollGateName { get; set; }

        /// <summary>
        /// 收费站位置
        /// <para>注：该字段为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <![CDATA[https://lbs.baidu.com/apiconsole/fankui#?typeOne=%E4%BA%A7%E5%93%81%E9%9C%80%E6%B1%82&typeTwo=%E9%AB%98%E7%BA%A7%E6%9C%8D%E5%8A%A1&typeThree=%E8%B4%A7%E8%BD%A6%E5%AF%BC%E8%88%AA]]>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_gate_location")]
        public Models.Location TollGateLocation { get; set; }

        /// <summary>
        /// 分段起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_location")]
        public Models.Location StartLocation { get; set; }

        /// <summary>
        /// 分段终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_location")]
        public Models.Location EndLocation { get; set; }

        /// <summary>
        /// 分段坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Path { get; set; }


        /// <summary>
        /// 分段路况详情（填历史路况）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public List<TruckResultTrafficCondition> TrafficCondition { get; set; }
    }

    /// <summary>
    /// 分段详情
    /// </summary>
    public class TruckResultTrafficCondition 
    {

        /// <summary>
        /// 路况指数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public Models.Enums.TrafficCondition? Status { get; set; }

        /// <summary>
        /// 从当前坐标点开始，path中路况相同的坐标点个数
        /// <para>注：绘制路况时，指标指向第一个path的第一个点，往后数n个点组成的路段路况是一样的，计数时不算指标所在的点（当前step所有geo_cnt的和为path中的点数减1）</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("geo_cnt")]
        public int? GeoCount { get; set; }

        /// <summary>
        /// 距离
        /// <para>单位：米</para>
        /// <para>从当前坐标点开始path 中路况相同的距离</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }
    }
}
