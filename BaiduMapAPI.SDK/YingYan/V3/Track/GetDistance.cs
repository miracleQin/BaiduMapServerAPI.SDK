using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 一段时间内的轨迹里程，支持纠偏
    /// <para>简介：查询entity 一段时间内行驶里程。</para>
    /// <para>支持功能：<br/>
    /// 1. 支持计算一段时间内轨迹纠偏、补偿后的总里程，也支持计算原始轨迹里程；<br/>
    /// 2.支持对中断的轨迹区间进行里程补偿，支持使用直线或驾车/骑行/步行路线规划的里程进行补偿。</para>
    /// <para>适用场景：<br/>
    /// 1. 通用型的原始和纠偏后轨迹里程计算；<br/>
    /// 2. 应用于网约车、物流等行业的用车实时计费，通过纠偏和补偿后的里程，校准用车计费。</para>
    /// </summary>
    public class GetDistance : Models.GetWithoutSNRequest<GetDistanceResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/track/getdistance";

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
        [Display(Name ="start_time")]
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
        /// 是否返回纠偏后里程
        /// <para>取值规则：<br/>
        /// 0：关闭轨迹纠偏，返回原始轨迹<br/>
        /// 1：打开轨迹纠偏，返回纠偏后轨迹。
        /// </para>
        /// </summary>
        [Display(Name = "is_processed")]
        [BoolToNumConverter]
        public bool? IsProcessed { get; set; }

        /// <summary>
        /// 纠偏选项
        /// </summary>
        [Display(Name = "process_option")]
        [FilterConverter(",", "=")]
        public ProcessOption ProcessOption { get; set; }

        /// <summary>
        /// 里程补偿方式
        /// <para>默认值：no_supplement，不补充</para>
        /// <para>在里程计算时，两个轨迹点定位时间间隔5分钟以上，被认为是中断。</para>
        /// </summary>
        [Display(Name = "supplement_mode")]
        [EnumName]
        public SupplementMode? SupplementMode { get; set; }

        /// <summary>
        /// 低速阈值
        /// <para>单位：千米/小时</para>
        /// <para>若填写该值且is_processed=1时，则返回结果中将增加low_speed_distance字段，表示速度低于该值的里程。</para>
        /// <para>示例：<br/>
        /// low_speed_threshold=20，则返回结果中将增加<br/>
        /// low_speed_distance字段表示此段轨迹中速度低于20千米/小时的里程，可用于网约车行业中计算低速里程。
        /// </para>
        /// </summary>
        [Display(Name = "low_speed_threshold")]
        public double? LowSpeedThreshold { get; set; }
    }

    /// <summary>
    /// 里程补偿方式
    /// </summary>
    public enum SupplementMode 
    {
        /// <summary>
        /// 不补充
        /// <para>中断两点间距离不记入里程。</para>
        /// </summary>
        [Description("不补充")]
        no_supplement=0,

        /// <summary>
        /// 使用直线距离补充
        /// </summary>
        [Description("使用直线距离补充")]
        straight=1,

        /// <summary>
        /// 使用最短驾车路线距离补充
        /// </summary>
        [Description("使用最短驾车路线距离补充")]
        driving = 2,

        /// <summary>
        /// 使用最短骑行路线距离补充
        /// </summary>
        [Description("使用最短骑行路线距离补充")]
        riding = 3,

        /// <summary>
        /// 使用最短步行路线距离补充
        /// </summary>
        [Description("使用最短步行路线距离补充")]
        walking = 4,
    }
}
