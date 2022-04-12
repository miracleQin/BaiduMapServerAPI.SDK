using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 批量查询所有围栏报警信息
    /// <para>批量查询某 service 7天内任意1小时，所有围栏的报警信息。</para>
    /// </summary>
    public class BatchHistoryAlarm : Models.GetWithoutSNRequest<BatchHistoryAlarmResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/batchhistoryalarm";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

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


        /// <summary>
        /// 分页索引
        /// <para>默认值：1</para>
        /// <para>与page_size一起计算从第几条结果返回，代表返回第几页</para>
        /// </summary>
        [Display(Name = "page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页返回数据量
        /// <para>默认值：1000</para>
        /// <para>返回结果最大个数与page_index一起计算从第几条结果返回，代表返回结果中每页的围栏个数</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }
    }
}
