using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 摩托车路线规划
    /// <para>摩托车路线规划为开放平台高级服务，需申请开通权限后才能访问服务</para>
    /// <para> https://lbsyun.baidu.com/apiconsole/quota#/home?jumpService=motorcycle </para>
    /// </summary>
    public class Motorcycle : Models.GetRequest<MotorcycleResult>
    {
        public override string URL => "https://api.map.baidu.com/direction/v2/motorcycle";


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
        /// 途径点坐标串
        /// <para>支持18个以内的有序途径点。 多个途径点坐标按顺序以英文竖线符号分隔</para>
        /// <para>示例: 40.465,116.314|40.232,116.352|40. 121,116.453</para>
        /// </summary>
        [Display(Name ="waypoints")]
        [LocationListConverter]
        public List<Models.Location> WayPoints { get; set; }

        /// <summary>
        /// 规划策略
        /// </summary>
        [Display(Name ="tactics")]
        public Models.Enums.TacticsDetail Tactics { get; set; }

        /// <summary>
        /// 是否返回备选路线
        /// </summary>
        [Display(Name = "alternatives")]
        [BoolToNumConverter]
        public bool? Alternatives { get; set; }

        /// <summary>
        /// 车牌号
        /// <para>不填则不作规避</para>
        /// <para>如 京A00022 用于规避车牌号限行路段。</para>
        /// <para>  1. 若有规避限行区域的可选路线， 则返回规避后的路线，不会返回限行 路线</para>
        /// <para>  2.若无规避限行的可选路线(如: 起终点在限行区域内，或所有符合偏 好的路线都无法规避限行区域)，则返回限行路线中最优路线，并在返回字段 restriction 中提示用户路段被限行</para>
        /// <para></para>
        /// </summary>
        [Display(Name = "plate_number")]
        public string PlateNumber { get; set; }

        /// <summary>
        /// 摩托车排量
        /// <para>单位cc</para>
        /// </summary>
        [Display(Name = "displacement")]
        public int? Displacement { get; set; }

        /// <summary>
        /// 起点的车头方向
        /// <para>取值范 围:0-359</para>
        /// <para>车头方向为与正北方向顺时针夹角，该参数用于辅助判断起点所在正逆向车道，提高算路准 确率。 当speed>1.5米/秒且gps_direction存在 时，采用该方向。</para>
        /// <para>gps_direction并不代表需填 写从gps获取的方向，可以填入校正后的方 向。请填写尽量准确的方向，其准确性很大程 度决定了计算的精度。</para>
        /// </summary>
        [Display(Name = "gps_direction")]
        public int? GpsDirection { get; set; }

        /// <summary>
        /// 起点的定位精度
        /// <para>取值范围 [0,2000]</para>
        /// <para>配合gps_direction字段使用</para>
        /// </summary>
        [Display(Name = "radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 起点车辆的行驶速度
        /// <para>单位:米/秒</para>
        /// <para>配合gps_direction字段使用，当 speed>1.5米/秒且gps_direction存在时，采用 gps_direction的方向</para>
        /// </summary>
        [Display(Name ="speed")]
        public double? Speed { get; set; }

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

        /// <summary>
        /// 输出类型
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";
    }
}
