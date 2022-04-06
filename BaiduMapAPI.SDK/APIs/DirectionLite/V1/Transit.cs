using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.DirectionLite.V1
{
    /// <summary>
    /// 公交路线规划
    /// </summary>
    public class Transit : Models.GetRequest<TransitResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/directionlite/v1/transit";


        /// <summary>
        /// 起点经纬度
        /// <para>格式为：纬度,经度</para>
        /// <para>小数点后不超过6位</para>
        /// </summary>
        [Display(Name = "origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 终点
        /// <para>格式为：纬度,经度</para>
        /// <para>小数点后不超过6位</para>
        /// </summary>
        [Display(Name = "destination")]
        public Models.Location Destination { get; set; }

        /// <summary>
        /// 起点uid
        /// <para>POI 的 uid</para>
        /// <para>在已知起点POI 的 uid 情况下，请尽量填写uid，将提升路线规划的准确性</para>
        /// </summary>
        [Display(Name = "origin_uid")]
        public string OriginUid { get; set; }

        /// <summary>
        /// 终点uid
        /// <para>POI 的 uid</para>
        /// <para>在已知起点POI 的 uid 情况下，请尽量填写uid，将提升路线规划的准确性</para>
        /// </summary>
        [Display(Name = "destination_uid")]
        public string DestinationUid { get; set; }


        /// <summary>
        /// 输入坐标类型
        /// <para>默认bd09ll</para>
        /// <para>允许的值为： bd09ll：百度经纬度坐标;bd09mc：百度墨卡托坐标;gcj02：国测局加密坐标;wgs84：gps设备获取的坐标</para>
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
        /// 时间戳，与SN配合使用
        /// <para>SN存在时必填</para>
        /// </summary>
        [Models.Attributes.UnixDateTimeConverter]
        [Display(Name = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
