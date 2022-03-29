using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 摩托车规划返回参数
    /// </summary>
    public class MotorcycleResult : Models.ResponseOld
    {
        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public MotorcycleResultResult Result { get; set; }
    }

    public class MotorcycleResultResult 
    {
        /// <summary>
        /// 限行结果提示信息
        /// <para>1: 若无限行路 线，则返回空 </para>
        /// <para>2: 若无法规避限 行，则返回限行 提示信息</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restriction")]
        public string Restriction { get; set; }

        /// <summary>
        /// 返回方案的总数
        /// <para>若请求参数设置 了符合规则的 departure_time， 则按照设定时间 的预测路况和限 行规则计算路 线。 若未设置 departure_time， 则按照当前时刻 的路况和限行规 则计算路线</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 返回的方案集
        /// <para></para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<MotorcycleResultRoute> Routes { get; set; }
    }

    public class MotorcycleResultRoute 
    {
        /// <summary>
        /// 起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 重点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public Models.Location Destination { get; set; }

        /// <summary>
        /// 方案标签
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 限行信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restriction_info")]
        public MotorcycleResultRestrictionInfo RestrictionInfo { get; set; }

        /// <summary>
        /// 方案距离
        /// <para>单 位:米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 线路耗时
        /// <para>单 位:秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 出租车费用
        /// <para>单 位:元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taxi_fee")]
        public int? TaxiFee { get; set; }

        /// <summary>
        /// 此路线道路收费
        /// <para>单 位:元</para>
        /// <para>此高速费为预估价格，与实际高速收费并不完全一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public int? Toll { get; set; }

        /// <summary>
        /// 收费路段里程
        /// <para>单 位:米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public int? TollDistance { get; set; }

        /// <summary>
        /// 路线分段
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<MotorcycleResultStep> Steps { get; set; }
    }

    public class MotorcycleResultRestrictionInfo 
    {
        /// <summary>
        /// 限行状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public Models.Enums.RestrictionStatus? Status { get; set; }

        /// <summary>
        /// 限行提示语
        /// <para>当限行status为1或 2时，会有相应的 限行描述信息。 若该路线有多条 提示信息，则以 英文竖线分隔符 分隔，如: "已为您避开北京 限行区域" "无法为您避开北 京限行区域，请 合理安排出行" "起点在北京限行 区域，请合理安 排出行" "终点在北京限行 区域，请合理安 排出行" "起点在北京限行 区域，请合理安 排出行|终点在北 京限行区域，请 合理安排出行"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("desc")]
        public string Description { get; set; }
    }

    public class MotorcycleResultStep 
    {
        /// <summary>
        /// 途径点序号
        /// <para>途径点序号为从0 开始的整数，用 于标识step所属的 途径点路段</para>
        /// <para>如:若该step属于 起点至第一个途 径中的路段，则 其leg_index为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("leg_index")]
        public int? LegIndex { get; set; }

        /// <summary>
        /// 进入道路的角度
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public Models.Enums.DirectionType? Direction { get; set; }

        /// <summary>
        /// step的距离信息
        /// <para>单 位:米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 分段的道路名称
        /// <para>如“信息路“ 若道路未命名或 百度地图未采集 到该道路名称， 则返回"无名路"</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_name")]
        public string RoadName { get; set; }

        /// <summary>
        /// 分段的道路类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_type")]
        public Models.Enums.RoadType? RoadType { get; set; }

        /// <summary>
        /// 分段道路收费
        /// <para>单 位:元</para>
        /// <para>因一个收费路段 可能覆盖多个 step，部分情况下 费用无法按step准 确拆分，故分段 step收费可能存在 不准确情况</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public int? Toll { get; set; }

        /// <summary>
        /// 分段道路收费路程
        /// <para>单 位:米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public int? TollDistance { get; set; }

        /// <summary>
        /// 收费站名称
        /// <para>只有在进收费站 和出收费站时才 有</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_gate_name")]
        public string TollGateName { get; set; }

        /// <summary>
        /// 收费站坐标
        /// <para>只有在进收费站和出收费站时才有</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_gate_location")]
        public Models.Location TollGateLocation { get; set; }

        /// <summary>
        /// 分段起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_location")]
        public Models.Location StartLocation { get; set; }

        /// <summary>
        /// 分段终点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_location")]
        public Models.Location EndLocation { get; set; }

        /// <summary>
        /// 分段坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Paths { get; set; }

        /// <summary>
        /// 分段途经的城市 编码
        /// <para>若途经多个城 市，则adcode以英 文半角逗号相隔</para>
        /// <para>如: 110000,120000</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcodes")]
        public string ADCodes { get; set; }


        /// <summary>
        /// 分段路况详情
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public MotorcycleResultTrafficCondition TrafficCondition { get; set; }
    }

    public class MotorcycleResultTrafficCondition 
    {
        /// <summary>
        /// 路况指数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public Models.Enums.TrafficCondition? Status { get; set; }

        /// <summary>
        /// 路况相 同的坐标点个数
        /// <para>从当前坐标点开 始，path中路况相 同的坐标点个数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("geo_cnt")]
        public int? GeoCount { get; set; }

        /// <summary>
        /// 距离
        /// <para>从当前坐 标点开始path 中 路况相同的距 离</para>
        /// <para>单位:米</para>
        /// <para>注:单条线路中 所有distance的和 会与route的 distance字段存在 差异，不是完全 一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }
    }
}
