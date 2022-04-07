using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Analysis
{
    /// <summary>
    /// 驾驶行为分析
    /// <para>查询entity在指定时间段内的驾驶行为，返回以下分析结果：<br/>
    /// 1. 总体信息：起终点信息、里程、耗时、平均速度、最高速度<br/>
    /// 2. 异常信息：超速、急加速、急刹车、急转弯
    /// </para>
    /// </summary>
    public class DrivingBehavior : Models.GetWithoutSNRequest<DrivingBehaviorResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/analysis/drivingbehavior";

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
        /// 固定限速值
        /// <para>默认值：0</para>
        /// <para>取值规则：<br/>
        /// 0：根据百度地图道路限速数据计算超速点<br/>
        /// 其他数值：以设置的数值为阈值，轨迹点速度超过该值则认为是超速；</para>
        /// <para>示例： speeding_threshold=0，以道路限速数据计算 speeding_threshold=80，限速值为80km/h</para>
        /// </summary>
        [Display(Name = "speeding_threshold")]
        public double? SpeedingThreshold { get; set; }

        /// <summary>
        /// 急加速的加速度阈值
        /// <para>单位：m/s^2</para>
        /// <para>默认值：1.67，仅支持正数</para>
        /// </summary>
        [Display(Name = "harsh_acceleration_threshold")]
        public double? HarshAccelerationThreshold { get; set; }

        /// <summary>
        /// 急减速的加速度阈值
        /// <para>单位：m/s^2</para>
        /// <para>默认值：-1.67，仅支持负数</para>
        /// </summary>
        [Display(Name = "harsh_breaking_threshold")]
        public double? HarshBreakingThreshold { get; set; }

        /// <summary>
        /// 急转弯的向心加速度阈值
        /// <para>单位：m/s^2</para>
        /// <para>默认值：5，仅支持正数</para>
        /// </summary>
        [Display(Name = "harsh_steering_threshold")]
        public double? HarshSteeringThreshold { get; set; }

        /// <summary>
        /// 纠偏选项
        /// <para>可配置属性：need_mapmatch、transport_mode</para>
        /// </summary>
        [Display(Name = "process_option")]
        [FilterConverter(",", "=")]
        public Track.ProcessOption ProcessOption { get; set; }

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
