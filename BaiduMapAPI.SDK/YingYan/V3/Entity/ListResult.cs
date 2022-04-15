using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 查询entity 结果
    /// </summary>
    public class ListResult : Models.ResponseOld
    {

        /// <summary>
        /// 本次检索总结果条数
        /// <para>代表符合本次检索条件的结果总数</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 本页返回的结果条数
        /// <para>代表本页返回了多少条符合条件的entity</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        

        /// <summary>
        /// entity详细信息列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entities")]
        public List<Entity> Entities { get; set; }


    }

    /// <summary>
    /// Entity 详情
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// entity名称，其唯一标识
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// entity 可读性描述
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entity_desc")]
        public string EntityDescription { get; set; }

        /// <summary>
        /// entity属性修改时间
        /// <para>该时间为服务端时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("modify_time")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// entity属性修改时间
        /// <para>该时间为服务端时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 开发者自定义的entity属性信息
        /// <para>只有当开发者为entity创建了自定义属性字段，且赋过值，才会返回。</para>
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        public Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomColumnValues { get; set; }

        /// <summary>
        /// 最新的轨迹点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latest_location")]
        public LatestLocation LatestLocation { get; set; }
    }

    /// <summary>
    /// 最新的轨迹点信息
    /// </summary>
    public class LatestLocation : Models.LocationDetail 
    {
        /// <summary>
        /// 定位精度
        /// <para>单位：m</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 该entity最新定位时间
        /// <para>该entity最新定位时间（定位时设备的时间）</para>
        /// <para>该时间为Unix时间，未加时区</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeNoUTCConverter))]
        public DateTime? LocationTime { get; set; }


        /// <summary>
        /// 方向
        /// <para>范围为[0,359]，0度为正北方向，顺时针</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 速度
        /// <para>单位：km/h</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }


        /// <summary>
        /// 高度
        /// <para>单位： m</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("height")]
        public double? Height { get; set; }


        /// <summary>
        /// 楼层
        /// <para>若处于百度支持室内定位的区域，则将返回楼层信息，默认 null</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("floor")]
        public string Floor { get; set; }

        /// <summary>
        /// 对象数据名称
        /// <para>若无值则不返回该字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("object_name")]
        public string ObjectName { get; set; }

        /// <summary>
        /// 开发者自定义track的属性
        /// <para>只有当开发者为track创建了自定义属性字段，且赋过值，才会返回。</para>
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        public Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomColumnValues { get; set; }
    }
}
