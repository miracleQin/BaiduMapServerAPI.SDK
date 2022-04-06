using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.DirectionLite.V1
{
    /// <summary>
    /// 驾车路线规划
    /// </summary>
    public class Driving : Models.GetRequest<DrivingResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/directionlite/v1/driving";

        /// <summary>
        /// 起点经纬度
        /// <para>格式为：纬度,经度</para>
        /// <para>小数点后不超过6位</para>
        /// </summary>
        [Display(Name= "origin")]
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
        /// 车牌号
        /// </summary>
        [Display(Name = "plate_number")]
        public string PlateNumber { get; set; }

        /// <summary>
        /// 途经点
        /// <para>支持5个以内的有序途径点。多个途径点坐标按顺序以英文竖线符号分隔</para>
        /// <para>示例： 40.465,116.314|40.232,116.352|40.121,116.453</para>
        /// </summary>
        [Display(Name = "waypoints")]
        [LocationListConverter]
        public List<Models.Location> Waypoints { get; set; }

        /// <summary>
        /// 路线偏好
        /// <para>默认值：0</para>
        /// </summary>
        [Display(Name = "tactics")]
        [EnumValue]
        public Models.Enums.Tactics? Tactics { get; set; }


        /// <summary>
        /// 起点的定位方向
        /// <para>车头方向为与正北方向顺时针夹角，取值范围[0,359]。</para>
        /// <para>该参数用于辅助判断起点所在正逆向车道，提高算路准确率。 当speed>1.5米/秒且gps_direction存在时，采用该方向。</para>
        /// <para>gps_direction并不代表需填写从gps获取的方向，可以填入校正后的方向。请填写尽量准确的方向，其准确性很大程度决定了计算的精度。</para>
        /// </summary>
        [Display(Name = "gps_direction")]
        public long? GpsDirection { get; set; }

        /// <summary>
        /// 起点的定位精度
        /// <para>配合gps_direction字段使用，取值范围[0,2000]</para>
        /// </summary>
        [Display(Name = "radius")]
        public float? Radius { get; set; }

        /// <summary>
        /// 起点车辆的行驶速度
        /// <para>配合gps_direction字段使用</para>
        /// <para>单位：米/秒</para>
        /// <para>当speed>1.5米/秒且gps_direction存在时，采用gps_direction的方向</para>
        /// </summary>
        [Display(Name ="speed")]
        public float? Speed { get; set; }

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
        public DateTime? Timestamp { get; set; } = DateTime.Now;

    }
}
