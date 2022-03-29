using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点检索单条结果
    /// </summary>
    public class SearchResultItem
    {
        /// <summary>
        /// poi名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// poi经纬度坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// POI 地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 所属省份
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 所属城市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 所属区县
        /// </summary>
        [Newtonsoft.Json.JsonProperty("area")]
        public string Area { get; set; }

        /// <summary>
        /// 行政区划代码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcode")]
        public int? Adcode { get; set; }

        /// <summary>
        /// poi电话信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// poi的唯一标示，可用于详情检索
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }

        /// <summary>
        /// 街景图id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("street_id")]
        public string StreetID { get; set; }

        /// <summary>
        /// 是否有详情页
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail")]
        public bool? HasDetail { get; set; }

        /// <summary>
        /// poi的扩展信息
        /// <para>仅当scope=2时，显示该字段，不同的poi类型，显示的detail_info字段不同</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("detail_info")]
        public SearchResultItemDetail DetailInfo { get; set; }
    }
}
