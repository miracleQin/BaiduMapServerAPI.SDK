using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.DirectionLite.V1
{
    /// <summary>
    /// 公交规划返回参数
    /// </summary>
    public class TransitResult : Models.ResponseOld
    {
        /// <summary>
        /// 公交规划结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public TransitResultResult Result { get; set; }
    }
    /// <summary>
    /// 公交规划结果
    /// </summary>
    public class TransitResultResult : DrivingResultResult 
    {
        /// <summary>
        /// 出租车信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taxi")]
        public TransitResultTaxi Taxi { get; set; }
        /// <summary>
        /// 路线方案
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public new List<TransitResultRoute> Routes { get; set; }
    }

    /// <summary>
    /// 路线方案
    /// </summary>
    public class TransitResultTaxi 
    {
        /// <summary>
        /// 出租车的详细信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail")]
        public List<TransitResultTaxiDetail> Details { get; set; }

        /// <summary>
        /// 出租车预计里程数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 出租车预计耗时
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        /// 出租车备注信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("remark")]
        public string Remark { get; set; }
    }

    /// <summary>
    /// 出租车备注信息
    /// </summary>
    public class TransitResultTaxiDetail 
    {
        /// <summary>
        /// 白天还是夜间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("desc")]
        public string Description { get; set; }


        /// <summary>
        /// 每公里价格(元)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("km_price")]
        public double? KMPrice { get; set; }

        /// <summary>
        /// 起步价(元)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_price")]
        public double? StartPrice { get; set; }

        /// <summary>
        /// 总价（元）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total_price")]
        public double? TotalPrice { get; set; }
    }

    /// <summary>
    /// 路线方案
    /// </summary>
    public class TransitResultRoute : DrivingResultRoute
    {

        /// <summary>
        /// 本条路线的总票价（元）
        /// <para>境外地区此字段值为null</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price")]
        public double? Price { get; set; }
        /// <summary>
        /// 车票详细信息
        /// <para>起终点为境内地区同城时此字段为一个数组，数组中的每一项都有ticket_type 和ticket_price 两个字段；</para>
        /// <para>起终点为境内跨城时，该字段为一个空的数组。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("line_price")]
        public List<TransitResultLinePrice> LinePrice { get; set; }

        /// <summary>
        /// 路线分段
        /// <para>数组，数组中的每一项是一步（step）。每条路线都由多个step组成</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public new List<List<TransitResultStep>> Steps { get; set; }
    }

    /// <summary>
    /// 车票详细信息
    /// </summary>
    public class TransitResultLinePrice
    {
        /// <summary>
        /// 票类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("line_type")]
        public Models.Enums.LinePriceType Type { get; set; }

        /// <summary>
        /// 价格
        /// <para>单位：元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("line_price")]
        public double? Price { get; set; }
    }

    /// <summary>
    /// 路线分段
    /// </summary>
    public class TransitResultStep : DrivingResultStep
    {
        /// <summary>
        /// 路段出行方式
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.TransitResultStepType? Type { get; set; }

        /// <summary>
        /// 交通工具信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicle")]
        public TransitResultVehicle Vehicle { get; set; }
    }

    /// <summary>
    /// 交通工具信息
    /// </summary>
    public class TransitResultVehicle
    {
        /// <summary>
        /// 公交路线名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 路线方向说明
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction_text")]
        public string DirectionText { get; set; }

        /// <summary>
        /// 路线方向说明
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_name")]
        public string StartName { get; set; }

        /// <summary>
        /// 公交线路终点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_name")]
        public string EndName { get; set; }

        /// <summary>
        /// 公交线路首班车时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 公交线路的末班车时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 路段经过的站点数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stop_num")]
        public int? StopNum { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total_price")]
        public double? TotalPrice { get; set; }


        /// <summary>
        /// 公交线路类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.VehicleType? Type { get; set; }

        /// <summary>
        /// 区间价
        /// </summary>
        [Newtonsoft.Json.JsonProperty("zone_price")]
        public double? ZonePrice { get; set; }

    }
}
