using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 一段时间内的轨迹点，支持纠偏
    /// <para>简介：查询一个时间段内一个entity的连续轨迹信息，并进行纠偏。</para>
    /// <para>支持功能：支持对一段轨迹进行纠偏、绑路、补偿中断区间道路、分析起终点、计算总里程和收费里程。其中每一个轨迹点的信息包括：坐标、速度、方向、高度、定位精度、定位模式、交通方式等。</para>
    /// <para>适用场景：适用于查询一段时间的轨迹并进行纠偏，解决轨迹缺失与漂移问题，这也是开发者最常使用、最依赖鹰眼的一个场景。</para>
    /// </summary>
    public class GetTrack : Models.GetWithoutSNRequest<GetTrackResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/track/gettrack";

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

        /// <summary>
        /// 轨迹补偿内容
        /// <para>仅在supplement_mode不为no_supplement时生效。</para>
        /// <para>默认值：only_distance。</para>
        /// </summary>
        [Display(Name = "supplement_content")]
        [EnumName]
        public SupplementContent? SupplementContent { get; set; }

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

        /// <summary>
        /// 返回轨迹点的排序规则
        /// <para>默认值：asc</para>
        /// <para>取值规则：<br/>
        /// asc：按定位时间升序排序（旧->新）<br/>
        /// desc：按定位时间降序排序（新->旧）
        /// </para>
        /// </summary>
        [Display(Name = "sort_type")]
        public SortType? SortType { get; set; }

        /// <summary>
        /// 分页索引
        /// <para>默认值：1</para>
        /// <para>与page_size一起计算从第几条结果返回，代表返回第几页。</para>
        /// </summary>
        [Display(Name ="page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// <para>默认值：100</para>
        /// <para>返回结果最大个数与page_index一起计算从第几条结果返回，代表返回结果中每页有几个轨迹点。</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }
    }

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum SortType 
    {
        /// <summary>
        /// 按定位时间升序
        /// </summary>
        [Description("按定位时间升序")]
        asc=0,
        /// <summary>
        /// 按定位时间降序
        /// </summary>
        [Description("按定位时间降序")]
        desc=1,
    }

    /// <summary>
    /// 轨迹补偿内容
    /// </summary>
    public enum SupplementContent
    {
        /// <summary>
        /// 对于中断区间，只补偿中断的里程，不补偿轨迹点
        /// </summary>
        [Description("只补偿中断的里程")]
        only_distance = 0,

        /// <summary>
        /// 对于中断区间，既补偿里程，又补偿轨迹点
        /// </summary>
        [Description("既补偿里程，又补偿轨迹点")]
        distance_and_points = 1,
    }
}
