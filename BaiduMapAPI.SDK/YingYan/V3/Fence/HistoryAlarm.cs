using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询某监控对象的围栏报警信息
    /// <para>查询围栏的监控对象7天以内（包含7天）的围栏报警信息，7天以外的报警信息将被删除。</para>
    /// <para>注：即使围栏或监控对象已被删除，仍能根据 fence_id 和 monitored_person 查询7天之内的报警信息。</para>
    /// </summary>
    public class HistoryAlarm : Models.GetWithoutSNRequest<HistoryAlarmResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/historyalarm";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 监控对象(必填)
        /// <para>监控对象的 entity_name</para>
        /// </summary>
        [Display(Name = "monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏id列表
        /// <para>若不填，则查询监控对象所有围栏的报警信息</para>
        /// </summary>
        [Display(Name = "fence_ids")]
        [ListObjectConverter(",")]
        public List<int> FenceIDs { get; set; }

        /// <summary>
        /// 分页索引
        /// <para>若不填，则返回7天内所有报警信息</para>
        /// </summary>
        [Display(Name = "start_time")]
        [UnixDateTimeConverter]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 每页返回数据量
        /// <para>若不填，则返回7天内所有报警信息</para>
        /// </summary>
        [Display(Name = "end_time")]
        [UnixDateTimeConverter]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 返回坐标类型
        /// <para>默认为 bd09ll。</para>
        /// <para>用于控制返回结果的坐标类型</para>
        /// <para>可选值如下：<br/>
        /// bd09ll：百度经纬度<br/>
        /// gcj02：国测局经纬度
        /// </para>
        /// <para>注：国外均返回 wgs84 坐标</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }
    }
}
