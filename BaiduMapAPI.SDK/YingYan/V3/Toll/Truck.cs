using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Toll
{
    /// <summary>
    /// 计算货车ETC
    /// </summary>
    public class Truck : Models.GetWithoutSNRequest<TruckResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/toll/truck";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// entity唯一标识(必填)
        /// <para>标识轨迹点所属的 entity</para>
        /// </summary>
        [Display(Name = "entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// 开始时间(必填)
        /// </summary>
        [Display(Name = "start_time")]
        [UnixDateTimeConverter]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间(必填)
        /// <para>结束时间不能大于当前时间，且起止时间区间不超过24小时。为提升响应速度，同时避免轨迹点过多造成请求超时（3s）失败，建议缩短每次请求的时间区间，将一天轨迹拆分成多段进行拼接</para>
        /// </summary>
        [Display(Name = "end_time")]
        [UnixDateTimeConverter]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 车辆高度(必填)
        /// <para>单位：米</para>
        /// <para>取值范围：[0,5.0]</para>
        /// </summary>
        [Display(Name ="height")]
        public double? Height { get; set; }

        /// <summary>
        /// 车辆宽度(必填)
        /// <para>单位：米</para>
        /// <para>取值范围：[0,3.0]</para>
        /// </summary>
        [Display(Name = "width")]
        public double? Width { get; set; }

        /// <summary>
        /// 车辆长度(必填)
        /// <para>单位：米</para>
        /// <para>取值范围：[0,20.0]</para>
        /// </summary>
        [Display(Name = "length")]
        public double? Length { get; set; }

        /// <summary>
        /// 车辆总重(必填)
        /// <para>单位：吨</para>
        /// <para>车辆总重=车辆自身重量+货物重量</para>
        /// <para>取值范围：[0,100]</para>
        /// </summary>
        [Display(Name = "weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// 轴数(必填)
        /// <para>取值范围[1,6]</para>
        /// </summary>
        [Display(Name = "axle_count")]
        public double? AxleCount { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于控制返回结果中的坐标类型。可选值为：<br/>
        /// gcj02：国测局加密坐标<br/>
        /// bd09ll：百度经纬度坐标
        /// </para>
        /// <para>该参数仅对国内（包含港、澳、台）轨迹有效，海外区域轨迹均返回 wgs84坐标系</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }
    }
}
