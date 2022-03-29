using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 逆地理编码结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public GetResultResult Result { get; set; }
    }
    /// <summary>
    /// 逆地理编码结果
    /// </summary>
    public class GetResultResult
    {
        /// <summary>
        /// 经纬度坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 结构化地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// 坐标所在商圈信息
        /// <para>如 "人民大学,中关村,苏州街"。最多返回3个。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("business")]
        public string Business { get; set; }

        /// <summary>
        /// 注意，国外行政区划，字段仅代表层级
        /// </summary>
        [Newtonsoft.Json.JsonProperty("addressComponent")]
        public GetResultAddressComponent AddressComponent { get; set; }

        /// <summary>
        /// 周边poi数组
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pois")]
        public List<GetResultPoi> Pois { get; set; }

        /// <summary>
        /// 周边路信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("roads")]
        public List<GetResultRoad> Roads { get; set; }

        /// <summary>
        /// POI 区域信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("poiRegions")]
        public List<GetResultPoiRegion> PoiRegions { get; set; }

        /// <summary>
        /// 当前位置结合POI的语义化结果描述
        /// <para>需设置extensions_poi=1才能返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("sematic_description")]
        public string SematicDescription { get; set; }

        /// <summary>
        /// 百度定义的城市id
        /// <para>正常更新与维护，但建议使用adcode</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("cityCode")]
        public int? CityCode { get; set; }
    }
}
