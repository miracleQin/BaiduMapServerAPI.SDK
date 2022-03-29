using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.RecogAddress.V1
{
    /// <summary>
    /// 地址城乡类型判别结果
    /// </summary>
    public class RecogResult : Models.ResponseOld
    {
        /// <summary>
        /// 行政区信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("admin_info")]
        public AdminInfo AdminInfo { get; set; }


        /// <summary>
        /// 行政区类型信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("admin_type")]
        public AdminType AdminType { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stats_type")]
        public StatsType StatsType { get; set; }

        /// <summary>
        /// 该地点是否属于特殊区域（包含机场和开发区）
        /// <para>若设置了请求参数is_airport_or_develop=true时，则返回该字段，返回类型包含机场和开发区</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("airport_or_develop")]
        public string AirportOrDevelop { get; set; }
    }

    /// <summary>
    /// 行政区信息
    /// </summary>
    public class AdminInfo
    {
        /// <summary>
        /// 省份
        /// <para>省级行政区划名称</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// <para>市级行政区划名称</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 行政区
        /// <para>区级行政区划名称</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// 街道
        /// <para>街道、镇级行政区划名称</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town")]
        public string Town { get; set; }
    }

    /// <summary>
    /// 行政区类型
    /// </summary>
    public class AdminType
    {

        /// <summary>
        /// 区县级行政区划的类型
        /// <para>区县级行政区划类型有：区、市、县、旗、特区、林区、自治县和自治旗。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("county_type")]
        public string CountyType { get; set; }

        /// <summary>
        /// 乡镇级行政区划的类型
        /// <para>乡镇级行政区划类型有：乡、镇、街道、民族乡、苏木和民族苏木等。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town_type")]
        public string TownType { get; set; }

        /// <summary>
        /// 行政区划维度的城乡类别
        /// <para>根据行政区划的标准，判别城乡类型，包括城市和农村两种类型</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town_urban_rural")]
        public string TownUrbanRural { get; set; }

        /// <summary>
        /// 行政区划维度城乡类别的置信分
        /// <para>分数越高表示越有可能是这一类别。如类别为城市，置信分为90分，代表90%的可能性是城市</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("confidence")]
        public double? Confidence { get; set; }
    }

    /// <summary>
    /// 属性类型
    /// </summary>
    public class StatsType
    {
        /// <summary>
        /// 经济统计维度的城市类别置信分
        /// <para>如置信分为90，代表90%的可能性是城市</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("urban")]
        public double? Urban { get; set; }

        /// <summary>
        /// 该地点在城市类别中所属的具体区域及其置信分
        /// <para>如代码111置信分为80，代表80%的可能性是主城区</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("urban_list")]
        [Newtonsoft.Json.JsonConverter(typeof(StatsConfidenceListConverter))]
        public List<StatsConfidence> UrbanList { get; set; }

        /// <summary>
        /// 经济统计维度的乡镇类型置信分
        /// <para>如置信分为10，代表10%的可能性是乡镇</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("township")]
        public double? Township { get; set; }

        /// <summary>
        /// 该地点在乡镇类别中所属的具体区域及其置信分
        /// <para>如代码121置信分为70，代表70%的可能性是镇中心区</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("township_list")]
        [Newtonsoft.Json.JsonConverter(typeof(StatsConfidenceListConverter))]
        public List<StatsConfidence> TownshipList { get; set; }


        /// <summary>
        /// 经济统计维度的农村类型置信分
        /// <para>如置信分为0，代表0%的可能性是农村</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rural")]
        public double? Rural { get; set; }

        /// <summary>
        /// 该地点在农村类别中所属的具体区域及其置信分
        /// <para>如代码220置信分为80，代表80%的可能性是村庄</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rural_list")]
        [Newtonsoft.Json.JsonConverter(typeof(StatsConfidenceListConverter))]
        public List<StatsConfidence> RuralList { get; set; }
    }

    /// <summary>
    /// 状态评分
    /// </summary>
    public class StatsConfidence
    {
        /// <summary>
        /// 行政区类型
        /// </summary>
        public AdminTypes? Type { get; set; }

        /// <summary>
        /// 置信分
        /// </summary>
        public double? Confidence { get; set; }
    }

    /// <summary>
    /// 行政区类型
    /// </summary>
    public enum AdminTypes
    {
        /// <summary>
        /// 城镇
        /// </summary>
        [Description("城镇")]
        City = 100,

        /// <summary>
        /// 城区
        /// </summary>
        [Description("城区")]
        CityArea = 110,

        /// <summary>
        /// 主城区
        /// </summary>
        [Description("主城区")]
        CityCenter = 111,

        /// <summary>
        /// 城乡结合区
        /// </summary>
        [Description("城乡结合区")]
        ConbinationOfCityAndCountry = 112,

        /// <summary>
        /// 镇区
        /// </summary>
        [Description("镇区")]
        Town = 120,

        /// <summary>
        /// 镇中心区
        /// </summary>
        [Description("镇中心区")]
        TownCenter = 121,

        /// <summary>
        /// 城乡结合区
        /// </summary>
        [Description("城乡结合区")]
        ConbinationOfTownAndCountry = 122,

        /// <summary>
        /// 特殊区域
        /// </summary>
        [Description("特殊区域")]
        TownSpecArea = 123,

        /// <summary>
        /// 乡村
        /// </summary>
        [Description("乡村")]
        Country = 200,

        /// <summary>
        /// 乡村中心
        /// </summary>
        [Description("乡村中心")]
        CountryCenter = 210,

        /// <summary>
        /// 村庄
        /// </summary>
        [Description("村庄")]
        Village = 220,
    }
}
