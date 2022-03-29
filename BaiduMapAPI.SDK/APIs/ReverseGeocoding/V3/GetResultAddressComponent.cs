using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 
    /// </summary>
    public class GetResultAddressComponent
    {
        /// <summary>
        /// 国家
        /// </summary>
        [Newtonsoft.Json.JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coucountry_codentry")]
        public int? CountryCode { get; set; }

        /// <summary>
        /// 国家英文缩写（三位）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("country_code_iso")]
        public string CountryCodeIso { get; set; }

        /// <summary>
        /// 国家英文缩写（两位）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("country_code_iso2")]
        public string CountryCodeIso2 { get; set; }

        /// <summary>
        /// 省名
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市名
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }


        /// <summary>
        /// 城市所在级别
        /// <para>仅国外有参考意义。国外行政区划与中国有差异，城市对应的层级不一定为『city』</para>
        /// <para>country、province、city、district、town分别对应0-4级，若city_level=3，则district层级为该国家的city层级</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city_level")]
        public Models.Enums.CityLevel? CityLevel { get; set; }

        /// <summary>
        /// 区县名
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 乡镇名
        /// <para>需设置extensions_town=true时才会返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town")]
        public string Town { get; set; }


        /// <summary>
        /// 乡镇id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town_code")]
        public string TownCode { get; set; }

        /// <summary>
        /// 街道名（行政区划中的街道层级）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// 街道门牌号
        /// </summary>
        [Newtonsoft.Json.JsonProperty("street_number")]
        public string StreetNumber { get; set; }


        /// <summary>
        /// 行政区划代码
        /// <para>下载地址：https://lbsyun.baidu.com/index.php?title=open/dev-res </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcode")]
        public int? ADCode { get; set; }

        /// <summary>
        /// 相对当前坐标点的方向
        /// <para>当有门牌号的时候返回数据</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// 相对当前坐标点的距离
        /// <para>当有门牌号的时候返回数据</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public string Distance { get; set; }
    }
}
