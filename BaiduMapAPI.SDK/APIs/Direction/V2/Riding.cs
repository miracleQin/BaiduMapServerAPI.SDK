using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 骑行路线规划
    /// </summary>
    public class Riding : Models.GetRequest<RidingResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/direction/v2/riding";

        /// <summary>
        /// 起点
        /// </summary>
        [Display(Name= "origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        [Display(Name = "destination")]
        public Models.Location Destination { get; set; }


        /// <summary>
        /// 起点POI的uid
        /// <para>请尽量填写uid，将提升路线规划的准确性。</para>
        /// <para>使用地点检索服务获取uid ， 使用地点输入提示服务获取uid </para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/guide/webservice-placeapi</para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/place-suggestion-api</para>
        /// </summary>
        [Display(Name = "origin_uid")]
        public string OriginUID { get; set; }

        /// <summary>
        /// 终点POI的uid
        /// <para>请尽量填写uid，将提升路线规划的准确性。</para>
        /// <para>使用地点检索服务获取uid ， 使用地点输入提示服务获取uid </para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/guide/webservice-placeapi</para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/place-suggestion-api</para>
        /// </summary>
        [Display(Name = "destination_uid")]
        public string DestinationUID { get; set; }

        /// <summary>
        /// 起终点的坐标类型
        /// <para>默认为bd09ll</para>
        /// <para>可选值：bd09ll（百度经纬度坐标）;gcj02（国测局加密坐标）;wgs84（gps 设备获取的坐标）;</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 输出坐标类型
        /// <para>返回值的坐标类型，默认为百度经纬度坐标：bd09ll</para>
        /// <para>可选值： bd09ll：百度经纬度坐标;gcj02：国测局加密坐标</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        [EnumName]
        public Models.Enums.CoordType? RetCoordType { get; set; }

        /// <summary>
        /// 骑行类型
        /// </summary>
        [Display(Name = "riding_type")]
        [EnumValue]
        public Models.Enums.RidingType? RidingType { get; set; }

        /// <summary>
        /// 时间戳，与SN配合使用
        /// <para>SN存在时必填</para>
        /// </summary>
        [Models.Attributes.UnixDateTimeConverter]
        [Display(Name = "timestamp")]
        public DateTime? Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// 输出类型
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";
    }
}
