using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 批量上传多个 entity 的多个轨迹点
    /// <para>与 v2版接口不同的是：</para>
    /// <para>1. 轨迹点列表采用 json格式，而非.csv 文件；</para>
    /// <para>2.一次请求可上传多个 entity 的轨迹点；</para>
    /// <para>注：开发者可参照示例代码实现高并发批量上传轨迹点：批量上传轨迹点的Java源码和示例</para>
    /// <para><![CDATA[http://lbsyun.baidu.com/index.php?title=yingyan/download]]></para>
    /// </summary>
    public class AddPoints : Models.FormDataPostWithoutSNRequest<AddPointsResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/track/addpoints";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 轨迹点列表
        /// <para>轨迹点总数不超过100个，json 格式。轨迹点字段描述参见 addpoint 接口，其中 entity_name,latitude,longitude,loc_time,coord_type_input5个字段必填，其他字段可选。</para>
        /// </summary>
        [Display(Name = "point_list")]
        [JsonConverter]
        public List<PointInfo> PointList { get; set; }
    }

    /// <summary>
    /// 轨迹点信息
    /// </summary>
    public class PointInfo
    {
        /// <summary>
        /// entity唯一标识(必填)
        /// <para>标识轨迹点所属的 entity</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entity_name")]
        public string EntityName { get; set; }

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
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
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
