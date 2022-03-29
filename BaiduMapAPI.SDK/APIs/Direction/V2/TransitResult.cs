using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 公交规划
    /// </summary>
    public class TransitResult : Models.ResponseOld
    {
        /// <summary>
        /// 公交规划结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public TransitResultResult Result { get; set; }

        /// <summary>
        /// 官网没解释这个字段是啥意思
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public int? Type { get; set; }
    }

    public class TransitResultResult
    {

        /// <summary>
        /// 起点城市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("origin")]
        public TransitResultCityInfo Origin { get; set; }

        /// <summary>
        /// 终点城市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("destination")]
        public TransitResultCityInfo Destination { get; set; }

        /// <summary>
        /// 出租车信息
        /// <para>仅在同城请求时才返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taxi")]
        public TransitResultTaxiInfo Taxi { get; set; }

        /// <summary>
        /// 所有路线的总数
        /// <para>符合条件的所有routes 的总数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 每页page_size 条，第page_index页的路线
        /// <para>请求中指定的page_index 和page_size 的部分。数组元素个数为page_size，每个元素代表从起点到终点的一条路线。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("routes")]
        public List<TransitResultRouteInfo> Routes { get; set; }
    }

    public class TransitResultCityInfo
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city_id")]
        public string CityID { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// 城市坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }

    }

    public class TransitResultTaxiInfo
    {
        /// <summary>
        /// 出租车的详细信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail")]
        public List<TransitResultTaxiDetail> Detail { get; set; }

        /// <summary>
        /// 出租车预计里程数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 出租车预计耗时
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 出租车备注信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("remark")]
        public string Remark { get; set; }
    }

    public class TransitResultTaxiDetail
    {
        /// <summary>
        /// 白天还是夜间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("desc")]
        public string Description { get; set; }

        /// <summary>
        /// 每公里价格（元）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("km_price")]
        public double? KMPrice { get; set; }

        /// <summary>
        /// 起步价格（元）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_price")]
        public double? StartPice { get; set; }

        /// <summary>
        /// 总价（元）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total_price")]
        public double? TotalPrice { get; set; }
    }

    public class TransitResultRouteInfo
    {
        /// <summary>
        /// 本条路线的总距离（米）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 本条路线的总耗时（秒）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 本条路线预计到达时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arrive_time")]
        public DateTime? ArriveTime { get; set; }

        /// <summary>
        /// 本条路线的总票价（元）
        /// <para>境外地区此字段值为null</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price")]
        public double? Price { get; set; }


        /// <summary>
        /// 车票详细信息
        /// <para>起终点为境内同城时此字段为一个数组，数组中的每一项都有ticket_type 和ticket_price 两个字段；起终点为境内跨城时，该字段为一个空的数组。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price_detail")]
        public List<TransitResultPriceDetail> PriceDetail { get; set; }

        /// <summary>
        /// 本条路线有几个step（步骤）
        /// <para> 数组，数组中的每一项是一步（step）。每条路线都由多个step组成。</para>
        /// <para> 起终点为同城时，比如从奎科大厦到西直门分3个step，第一步是奎科大厦步行到上地五街，第二步是上地五街到上地地铁站，第三步是上地地铁站到西直门；</para>
        /// <para> 起终点为跨城时，比如从奎科大厦到天津大学分3个step，第一步是奎科大厦到北京南站，第二步是北京南站到天津站，第三步是天津站到天津大学。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("steps")]
        public List<List<TransitResultStep>> Steps { get; set; }
    }

    public class TransitResultPriceDetail
    {
        /// <summary>
        /// 票类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ticket_type")]
        public Models.Enums.TicketType? TicketType { get; set; }

        /// <summary>
        /// 价格（元）
        /// <para>本类型的票的总价para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ticket_price")]
        public double? TicketPrice { get; set; }
    }

    /// <summary>
    /// 本step 中的有几个scheme（方案）或sub_step（子步骤）
    /// <para> 当起终点为同城时，一个step 中可能会有多个scheme（方案），上述同城的第二步上地五街到上地地铁站可以坐205或447，每一种是一个scheme；</para>
    /// <para> 当起终点为跨城时，一个step 中可能会有多个sub_step（子步骤），上述跨城的第一步从奎科大厦到北京南站分为多个sub_step(子步骤)，这里的每个子步骤类似同城时的一个scheme（方案）。</para>
    /// </summary>
    public class TransitResultStep
    {
        /// <summary>
        /// 本step 的距离（米）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// 本step 的耗时（秒）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// 本step 的描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// 本step 中的关键点坐标
        /// <para>坐标系由ret_coordtype设置，示例：</para>
        /// <para>“116.321858,40.039183;116.3216343,40.039141”</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("path")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.LocationListConverter))]
        public List<Models.Location> Path { get; set; }

        /// <summary>
        /// 本step 中的路况信息
        /// <para>目前无输出</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("traffic_condition")]
        public List<TransitResultTrafficCondition> TrafficCondition { get; set; }

        /// <summary>
        /// 交通方式信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vehicle_info")]
        public TransitResultVehicleInfo VehicleInfo { get; set; }
    }


    public class TransitResultTrafficCondition
    {
        /// <summary>
        /// 本step 起点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_location")]
        public Models.Location Start { get; set; }

        /// <summary>
        /// 本step 终点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_location")]
        public Models.Location End { get; set; }
    }

    public class TransitResultVehicleInfo
    {
        /// <summary>
        /// 本step 中交通方式的类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.TransitResultVehicleInfoType? Type { get; set; }

        /// <summary>
        /// 交通方式的具体信息
        /// <para>火车、飞机、大巴、公交4 种交通方式的这个字段有各自的格式，参见下面的文档，步行和驾车为null。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail")]
        public TransitResultVehicleInfoDetail Detail { get; set; }
    }

    public class TransitResultVehicleInfoDetail
    {
        /// <summary>
        /// 火车车次名称 | 航班名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 市内公交的具体类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.VehicleType? Type { get; set; }

        /// <summary>
        /// 途径站点数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stop_num")]
        public int? StopNumber { get; set; }


        /// <summary>
        /// 上车站点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("on_station")]
        public string OnStation { get; set; }

        /// <summary>
        /// 下车站点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("off_station")]
        public string OffStation { get; set; }

        /// <summary>
        /// 始发车发车时间
        /// <para>指的是从上车站点到下车站点这个方向上的始发车发车时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("first_time")]
        public TimeSpan? FirstTime { get; set; }

        /// <summary>
        /// 末班车发车时间
        /// <para>指的是从上车站点到下车站点这个方向上的末班车发车时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("last_time")]
        public TimeSpan? LastTime { get; set; }

        /// <summary>
        /// 总票价
        /// </summary>
        [Newtonsoft.Json.JsonProperty("price")]
        public double? Price { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        [Newtonsoft.Json.JsonProperty("discount")]
        public double? Discount { get; set; }

        /// <summary>
        /// 航空公司
        /// </summary>
        [Newtonsoft.Json.JsonProperty("airlines")]
        public string Airlines { get; set; }

        /// <summary>
        /// 订票电话
        /// </summary>
        [Newtonsoft.Json.JsonProperty("booking")]
        public string Booking { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        /// <summary>
        /// 合作方官网地址
        /// </summary>
        [Newtonsoft.Json.JsonProperty("provider_url")]
        public string ProviderUrl { get; set; }

        /// <summary>
        /// 上车火车站名称 | 登机机场名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departure_station")]
        public string DepartureStation { get; set; }

        /// <summary>
        /// 下车火车站名称 | 下飞机机场名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arrive_station")]
        public string ArriveStation { get; set; }

        /// <summary>
        /// 发车时间 | 飞机起飞时间
        /// <para>所乘的火车在上车火车站的发车时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("departure_time")]
        public string DepartureTime { get; set; }

        /// <summary>
        /// 到站时间 | 飞机降落时间
        /// <para>所乘的火车在下车火车站的到站时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arrive_time")]
        public string ArriveTime { get; set; }


        /// <summary>
        /// 起点站
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_info")]
        public TransitResultStartInfo StartInfo { get; set; }

        /// <summary>
        /// 终点站
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_info")]
        public TransitResultEndInfo EndInfo { get; set; }
    }

    public class TransitResultStartInfo
    {
        /// <summary>
        /// 起点站名 | 起点公交站名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_name")]
        public string StartName { get; set; }

        /// <summary>
        /// 起点poi 的 uid
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_uid")]
        public string StartUID { get; set; }

        /// <summary>
        /// 起点所在城市名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_city")]
        public string StartCity { get; set; }

        /// <summary>
        /// 出发时间 | 首班车时间
        /// <para>出发时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 起点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_location")]
        public Models.Location StartLocation { get; set; }
    }

    public class TransitResultEndInfo
    {
        /// <summary>
        /// 终点站名 | 终点公交站名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_name")]
        public string EndName { get; set; }

        /// <summary>
        /// 终点POI 的 uid
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_uid")]
        public string EndUID { get; set; }

        /// <summary>
        /// 终点所在城市名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_city")]
        public string EndCity { get; set; }

        /// <summary>
        /// 出发时间 | 末班车时间
        /// <para>出发时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_time")]
        public string EndTime { get; set; }


        /// <summary>
        /// 终点坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_location")]
        public Models.Location EndLocation { get; set; }
    }
}
