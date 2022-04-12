using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Analysis
{
    /// <summary>
    /// 停留点分析
    /// <para>查询entity在指定时间段内的停留点。停留点判断规则为：在stay_radius半径范围内，滞留stay_time以上，被认为是一次停留，将取一个代表性坐标作为停留点，其中 stay_radius 默认为20米，stay_time 默认为 600秒。</para>
    /// </summary>
    public class StayPoint : Models.GetWithoutSNRequest<StayPointResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/analysis/staypoint";


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
        /// 停留时间
        /// <para>单位：秒</para>
        /// <para>默认值：600</para>
        /// <para>该字段用于设置停留点判断规则，即若系统判断在半径为stay_radius的圆形范围内停留时间超过stay_time，则被认为是一次停留</para>
        /// </summary>
        [Display(Name = "stay_time")]
        public int? StayTime { get; set; }

        /// <summary>
        /// 停留半径
        /// <para>单位：米</para>
        /// <para>取值范围：[1,500]，默认值：20</para>
        /// <para>该字段用于设置停留点判断规则，即若系统判断在半径为stay_radius的圆形范围内停留时间超过stay_time，则被认为是一次停留</para>
        /// </summary>
        [Display(Name = "stay_radius")]
        public int? StayRadius { get; set; }

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
