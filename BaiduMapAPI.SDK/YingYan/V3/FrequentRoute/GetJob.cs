using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.FrequentRoute
{
    /// <summary>
    /// 查询任务，将返回计算出的经验路线，可能为多条经验路线
    /// </summary>
    public class GetJob : Models.GetWithoutSNRequest<GetJobResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/frequentroute/getjob";

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
        /// 时间容忍度阈值(必填)
        /// <para>取值范围[1,1440]，单位：分钟。</para>
        /// <para>出发时间是判断两个原始行程是否会被聚类为一条经验路线的时间纬度特征。若两个原始行程路线一致，但出发时间差值大于该阈值，则将被聚类至2条备选的经验路线中。例如，当time_range=180时，两个路线相同的行程出发时间分别为早晨8点和中午12点，则将被聚类至2条备选经验路线中；若出发时间分别为早晨8点和早晨9点，则将被聚类至1条备选经验路线中。</para>
        /// <para>若开发者不希望用出发时间来区分不同的经验路线，即不论何时出发，只要路线一致都被认为是一条经验路线，则设置time_range=1440，24小时即可。</para>
        /// </summary>
        [Display(Name = "time_range")]
        public int? TimeRange { get; set; }

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
        public Track.ProcessOption ProcessOption { get; set; }

        /// <summary>
        /// 轨迹补偿交通方式选择
        /// <para>默认值：no_supplement</para>
        /// <para>在轨迹纠偏时，两个轨迹点定位时间间隔5分钟以上，被认为是中断。中断轨迹和里程提供以下5种估算方式。<br/>
        /// no_supplement：不补充，中断两点间距离不记入里程。<br/>
        /// straight：使用直线补充<br/>
        /// driving：使用最短驾车路线规划补充<br/>
        /// riding：使用最短骑行路线规划补充<br/>
        /// walking：使用最短步行路线规划补充
        /// </para>
        /// </summary>
        [Display(Name = "supplement_mode")]
        [EnumName]
        public Track.SupplementMode? SupplementMode { get; set; }

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
