using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Weather.V1
{
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 天气结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public WeatherResult Result { get; set; }
    }

    public class WeatherResult 
    {
        /// <summary>
        /// 地理位置信息
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public LocationInfo Location { get; set; }

        /// <summary>
        /// 实况数据
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("now")]
        public NowResult Now { get; set; }

        /// <summary>
        /// 气象预警数据
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("alerts")]
        public List<AlertResult> Alerts { get; set; }

        /// <summary>
        /// 生活指数数据
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("indexes")]
        public List<IndexResult> Indexes { get; set; }

        /// <summary>
        /// 预报数据
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("forecasts")]
        public List<ForeCast> ForeCasts { get; set; }

        /// <summary>
        /// 未来24小时预报数据
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("forecast_hours")]
        public List<ForeCastHour> ForeCastsHours { get; set; }
    }


    /// <summary>
    /// 地理位置信息
    /// </summary>
    public class LocationInfo
    {

        /// <summary>
        /// 国家
        /// </summary>
        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 省、直辖市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 行政区编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }
    }


    /// <summary>
    /// 实况数据
    /// </summary>
    public class NowResult
    {
        /// <summary>
        /// 温度（℃）
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("temp")]
        public int? Temperature { get; set; }

        /// <summary>
        /// 体感温度(℃)
        /// <para>data_type=now/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("feels_like")]
        public int? FeelsLike { get; set; }

        /// <summary>
        /// 相对湿度(%)
        /// <para>data_type=now/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rh")]
        public int? RelativeHumidity { get; set; }

        /// <summary>
        /// 风力等级
        /// <para>data_type=now/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wind_class")]
        public string WindClass { get; set; }

        /// <summary>
        /// 风向描述
        /// <para>data_type=now/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        /// <summary>
        /// 天气现象
        /// <para>data_type=now/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 1小时累计降水量(mm)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("prec_1h")]
        public double? Prec1h { get; set; }

        /// <summary>
        /// 云量(%)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("clouds")]
        public int? Clouds { get; set; }

        /// <summary>
        /// 能见度(m)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vis")]
        public int? Visibility { get; set; }

        /// <summary>
        /// 空气质量指数数值
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("aqi")]
        public int? AirQualityIndex { get; set; }

        /// <summary>
        /// pm2.5浓度(μg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pm25")]
        public int? PM25 { get; set; }

        /// <summary>
        /// pm10浓度(μg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pm10")]
        public int? PM10 { get; set; }

        /// <summary>
        /// 二氧化氮浓度(μg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("no2")]
        public int? NO2 { get; set; }

        /// <summary>
        /// 二氧化硫浓度(μg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("so2")]
        public int? SO2 { get; set; }

        /// <summary>
        /// 臭氧浓度(μg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("o3")]
        public int? O3 { get; set; }

        /// <summary>
        /// 一氧化碳浓度(mg/m³)
        /// <para>data_type=now/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("co")]
        public double? CO { get; set; }

        /// <summary>
        /// 数据更新时间
        /// <para>北京时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uptime")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.DatetimeNumberConverter))]
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// 气象预警数据
    /// </summary>
    public class AlertResult 
    {
        /// <summary>
        /// 预警事件类型
        /// <para>data_type=alert/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 预警事件等级
        /// <para>data_type=alert/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("level")]
        public string Level { get; set; }

        /// <summary>
        /// 预警标题
        /// <para>data_type=alert/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 预警详细提示信息
        /// <para>data_type=alert/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("desc")]
        public string Description { get; set; }
    }

    /// <summary>
    /// 生活指数数据
    /// </summary>
    public class IndexResult 
    {
        /// <summary>
        /// 生活指数中文名称
        /// <para>data_type=index/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 生活指数概要说明
        /// <para>data_type=index/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("brief")]
        public string SummaryInformation { get; set; }

        /// <summary>
        /// 生活指数详细说明
        /// <para>data_type=index/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail")]
        public string Detail { get; set; }
    }

    /// <summary>
    /// 预报数据
    /// </summary>
    public class ForeCast 
    {
        /// <summary>
        /// 日期
        /// <para>北京时区</para>
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// 星期
        /// <para>北京时区</para>
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("week")]
        public string Week { get; set; }

        /// <summary>
        /// 最高温度(℃)
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("high")]
        public int? HighTemperature { get; set; }

        /// <summary>
        /// 最低温度(℃)
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("low")]
        public int? LowTemperature { get; set; }

        /// <summary>
        /// 白天风力
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wc_day")]
        public string WindClassDay { get; set; }

        /// <summary>
        /// 晚上风力
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wc_night")]
        public string WindClassNight { get; set; }

        /// <summary>
        /// 白天风向
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wd_day")]
        public string WindDirectionDay { get; set; }

        /// <summary>
        /// 晚上风向
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wd_night")]
        public string WindDirectionNight { get; set; }

        /// <summary>
        /// 白天天气现象
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text_day")]
        public string TextDay { get; set; }

        /// <summary>
        /// 晚上天气现象
        /// <para>data_type=fc/all</para>
        /// <para>基础字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text_night")]
        public string TextNight { get; set; }
    }

    /// <summary>
    /// 小时预报数据
    /// </summary>
    public class ForeCastHour 
    {
        /// <summary>
        /// 天气现象
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 温度（℃）
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("temp_fc")]
        public int? Temperature { get; set; }

        /// <summary>
        /// 风力等级
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wind_class")]
        public string WindClass { get; set; }

        /// <summary>
        /// 风向描述
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        /// <summary>
        /// 相对湿度(%)
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rh")]
        public int? RelativeHumidity { get; set; }

        /// <summary>
        /// 1小时累计降水量(mm)
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("prec_1h")]
        public double? Prec1h { get; set; }

        /// <summary>
        /// 云量(%)
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("clouds")]
        public int? Clouds { get; set; }

        /// <summary>
        /// 数据时间
        /// <para>data_type=fc_hour/all</para>
        /// <para>高级字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data_time")]
        public DateTime? DataTime { get; set; }
    }
}
