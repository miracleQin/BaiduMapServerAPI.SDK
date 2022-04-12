using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询围栏 结果
    /// </summary>
    public class ListResult:Models.ResponseOld
    {
        /// <summary>
        /// 总的查询结果数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 本页返回的结果数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// 围栏列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fences")]
        public List<Fence> Fences { get; set; }
    }

    /// <summary>
    /// 围栏信息
    /// </summary>
    public class Fence 
    {
        /// <summary>
        /// 围栏唯一标识
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_id")]
        public int? FenceID { get; set; }

        /// <summary>
        /// 围栏名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_name")]
        public string FenceName { get; set; }

        /// <summary>
        /// 围栏的监控对象
        /// <para>1. 该围栏仅监控一个entity时，返回entity_name<br/>
        /// 2. 该围栏监控service下的所有entity时，返回#allentity<br/>
        /// 3. 该围栏监控service下的部分entity时，返回#partofentity</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏的形状
        /// </summary>
        [Newtonsoft.Json.JsonProperty("shape")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Shape? Shape { get; set; }

        /// <summary>
        /// 经度
        /// <para>shape=circle时返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// <para>shape=circle时返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 半径
        /// <para>shape=circle时返回</para>
        /// <para>单位米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 多边形和线型围栏的顶点列表
        /// <para>shape=polygon或shape=polyline时返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vertexes")]
        [Newtonsoft.Json.JsonConverter(typeof(LocationDetailListConverter))]
        public List<Models.LocationDetail> Vertexes { get; set; }

        /// <summary>
        /// 偏移距离
        /// <para>单位：米</para>
        /// <para>仅在shape=polyline时返回偏移距离（若偏离折线距离超过该距离即报警）</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("offset")]
        public double? Offset { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// <para>仅在国外区域返回该字段，<br/>
        /// wgs84：GPS经纬度<br/>
        /// gcj02：国测局经纬度<br/>
        /// bd09ll：百度经纬度
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 围栏去噪参数
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("denoise")]
        public int? Denoise { get; set; }

        /// <summary>
        /// 行政区划描述
        /// <para>shape=district时返回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 围栏创建时间
        /// <para>格式化时间。</para>
        /// <para>示例： 2015-08-19 10:23:20</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 围栏创建时间
        /// <para>格式化时间。</para>
        /// <para>示例： 2015-08-19 10:23:20</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("modify_time")]
        public DateTime? ModifyTime { get; set; }
    }

    /// <summary>
    /// 形状
    /// </summary>
    public enum Shape 
    {
        /// <summary>
        /// 圆形
        /// </summary>
        [Description("圆形")]
        circle=0,

        /// <summary>
        /// 多边形
        /// </summary>
        [Description("多边形")]
        polygon =1,

        /// <summary>
        /// 线型
        /// </summary>
        [Description("线型")]
        polyline = 2,

        /// <summary>
        /// 行政区划
        /// </summary>
        [Description("行政区划")]
        district = 3,
    }
}
