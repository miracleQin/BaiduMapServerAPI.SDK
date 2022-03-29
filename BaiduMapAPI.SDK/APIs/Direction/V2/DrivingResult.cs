using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 驾车路线规划
    /// </summary>
    public class DrivingResult : Models.ResponseOld
    {

        /// <summary>
        /// 默认返回2，开发者无需关注
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public int? Type { get; set; }

        /// <summary>
        /// 返回的结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public DrivingResultResult Result { get; set; }

    }

    public class DrivingResultResult
    {
        /// <summary>
        /// 限行结果提示信息
        /// <para>若无限行路线，则返回空</para>
        /// <para>若无法规避限行，则返回限行提示信息</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restriction")]
        public string Restriction { get; set; }

        /// <summary>
        /// step的耗时
        /// <para>单位秒</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 返回方案的总数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("holiday")]
        public string Holiday { get; set; }

        /// <summary>
        /// 返回的方案集
        /// <para>若请求参数设置了符合规则的departure_time，则按照设定时间的预测路况和限行规则计算路线。</para>
        /// <para>若未设置departure_time，则按照当前时刻的路况和限行规则计算路线 </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<DrivingResultRoute> Routes { get; set; }
    }

    public class DrivingResultRoute
    {
        /// <summary>
        /// 起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 终点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public Models.Location Destination { get; set; }


        /// <summary>
        /// 方案标签
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// 如无特殊需要，开发者无需关注
        /// </summary>
        [Newtonsoft.Json.JsonProperty("route_id")]
        public string RouteID { get; set; }


        /// <summary>
        /// 方案距离
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 方案距离
        /// <para>单位：米</para>
        /// <para>若请求参数设置了符合规则的departure_time，则按照设定出发时间的预测路况计算路线耗时。</para>
        /// <para>若未设置departure_time，则按照当前时刻的路况计算路线耗时  注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 线路耗时（扩展）
        /// <para>单位：秒</para>
        /// <para>若设置了请求参数ext_duration，则返回该字段；</para>
        /// <para>若ext_departure_time设置了一个或多个出发时间则以英文半角逗号","分隔返回多个扩展耗时； 若扩展耗时计算失败，则返回-1</para>
        /// <para>若未设置departure_time，则按照当前时刻的路况计算路线耗时  注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ext_duration")]
        public int? ExtDuration { get; set; }

        /// <summary>
        /// 方案距离
        /// <para>
        /// 若请求参数设置了符合规则的expect_arrival_time，则按照按照预计达到时间预测路况计算路线，并给出建议出发时间。
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("suggest_departure_time")]
        public long? SuggestDeparturTime { get; set; }

        /// <summary>
        /// 出租车费用
        /// <para>单位：元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taxi_fee")]
        public int? TaxiFee { get; set; }

        /// <summary>
        /// 出租车费用
        /// <para>单位：元</para>
        /// <para>此高速费为预估价格，与实际高速收费并不完全一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public int? Toll { get; set; }



        /// <summary>
        /// 收费路段里程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public int? TollDistance { get; set; }


        /// <summary>
        /// 路线分段
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<DrivingResultStep> Steps { get; set; }
    }

    public class DrivingResultStep
    {
        /// <summary>
        /// 途径点序号
        /// <para>途径点序号为从0开始的整数，用于标识step所属的途径点路段</para>
        /// <para>如：若该step属于起点至第一个途径中的路段，则其leg_index为0</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("leg_index")]
        public int? LegIndex { get; set; }

        /// <summary>
        /// 进入道路的角度
        /// <para>注：角度为与正北方向顺时针夹角</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public Models.Enums.DirectionType? Direction { get; set; }

        /// <summary>
        /// step的距离信息
        /// <para>单位:米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 分段的道路名称
        /// <para>如“信息路“</para>
        /// <para>若道路未命名或百度地图未采集到该道路名称，则返回"无名路" </para>
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
        /// <para>单位：元</para>
        /// <para>因一个收费路段可能覆盖多个step，部分情况下费用无法按step准确拆分，故分段step收费可能存在不准确情况</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public double? Toll { get; set; }

        /// <summary>
        /// 分段道路收费路程
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public int? TollDistance { get; set; }

        /// <summary>
        /// 收费站名称
        /// <para>只有在进收费站和出收费站时才有</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_gate_name")]
        public string TollGateName { get; set; }


        /// <summary>
        /// 收费站位置
        /// <para>只有在进收费站和出收费站时才有</para>
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
        /// 该路段道路的关键点坐标
        /// <para>坐标系由ret_coordtype设置，示例：</para>
        /// <para>“116.321858,40.039183;116.3216343,40.039141”</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Path { get; set; }

        /// <summary>
        /// 分段途经的城市编码
        /// <para>若途经多个城市，则adcode以英文半角逗号相隔</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcodes")]
        public string ADCodes { get; set; }

        /// <summary>
        /// 分段路况详情
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public List<DrivingResulttTrafficCondition> TrafficCondition { get; set; }
    }

    public class DrivingResulttTrafficCondition 
    {
        /// <summary>
        /// 路况指数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public Models.Enums.TrafficCondition? Status { get; set; }

        /// <summary>
        /// 从当前坐标点开始，path中路况相同的坐标点个数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("geo_cnt")]
        public int? GeoCnt { get; set; }

        /// <summary>
        /// 距离
        /// <para>从当前坐标点开始path 中路况相同的距离</para>
        /// <para>单位：米</para>
        /// <para>注：单条线路中所有distance的和会与route的distance字段存在差异，不是完全一致</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }
    }
}
