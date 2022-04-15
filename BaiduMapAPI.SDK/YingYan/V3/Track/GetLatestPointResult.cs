using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 的实时位置，支持纠偏 结果
    /// </summary>
    public class GetLatestPointResult:Models.ResponseOld
    {
        /// <summary>
        /// 实时位置信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latest_point")]
        public LatestPoint LatestPoint { get; set; }
    }

    /// <summary>
    /// 最后位置信息
    /// </summary>
    public class LatestPoint 
    {
        /// <summary>
        /// 纬度(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 经度(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 定位时设备的时间(必填)
        /// <para>输入的loc_time不能大于当前服务端时间10分钟以上，即不支持存未来的轨迹点。</para>
        /// <para>且输入的loc_time不能小于当前服务端时间1年以上，即不支持存1年以前的轨迹点。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeNoUTCConverter))]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 坐标类型(必填)
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于描述上传的坐标类型。可选值为：</para>
        /// <para>wgs84：GPS 坐标</para>
        /// <para>gcj02：国测局加密坐标</para>
        /// <para>bd09ll：百度经纬度坐标</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type_input")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.CoordType? CoordTypeInput { get; set; }

        /// <summary>
        /// 速度
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }

        /// <summary>
        /// 方向
        /// <para>范围为[0,359]，0度为正北方向，顺时针</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 高度
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// 定位精度，GPS或定位SDK返回的值
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        [Newtonsoft.Json.JsonProperty("floor")]
        public string Floor { get; set; }

        /// <summary>
        /// 轨迹对应的定位方式
        /// <para>鹰眼分析得出</para>
        /// <para>仅当请求参数is_processed=1时返回。</para>
        /// <para>可能的返回值：未知；GPS/北斗定位；网络定位；基站定位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locate_mode")]
        public string LocateMode { get; set; }

        /// <summary>
        /// 轨迹对应的交通方式
        /// <para>鹰眼分析得出</para>
        /// <para>仅当请求参数is_processed=1，且process_option中transport_mode=auto时返回。</para>
        /// <para>可能的返回值：未知；驾车；骑行；步行；停留</para>
        /// <para>注意：该功能为高级付费服务，您可通过申请试用或购买使用该功能</para>
        /// <para><![CDATA[https://lbsyun.baidu.com/apiconsole/quota#/home?jumpService=trace]]></para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("transport_mode")]
        public string TransportMode { get; set; }

        /// <summary>
        /// 对象数据名称
        /// <para>通过鹰眼 SDK 上传的图像文件名称</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("object_name")]
        public string ObjectName { get; set; }

        /// <summary>
        /// track的自定义字段
        /// <para>此处值的类型须与用户自定义的column的类型一致</para>
        /// <para>随轨迹点上传开发者自定义字段的值</para>
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        public Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomColumnValues { get; set; }
    }
}
