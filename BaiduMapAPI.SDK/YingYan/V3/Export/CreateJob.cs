using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Export
{
    /// <summary>
    /// 创建批量导出任务
    /// <para>创建一个新的轨迹数据导出任务，下载该service 内一段时间内的全部轨迹。</para>
    /// <para>
    /// 注意：<br/>
    /// 1. 只能下载距当前时间6小时之前的轨迹，例如：2017-8-7 10:00创建的下载任务只能下载2017-8-7 4:00之前产生的轨迹<br/>
    /// 2. 每一个任务最多下载24小时时长的轨迹。例如，若下载7天的轨迹，则需创建7个任务<br/>
    /// 3. 每个service_id同时只允许存在10个未完成任务，超过10个则返回创建失败，请等待现有的任务处理完之后再创建新的任务
    /// </para>
    /// </summary>
    public class CreateJob : Models.FormDataPostWithoutSNRequest<CreateJobResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/export/createjob";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识。</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name= "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 轨迹起始时间(必填)
        /// </summary>
        [Display(Name = "start_time")]
        [UnixDateTimeConverter]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 轨迹结束时间(必填)
        /// <para>注：结束时间需比当前最新时间小12小时（即只能下载12小时以前的轨迹），且结束时间和起始时间差在24小时之内（即一次只能下载24小时区间内的轨迹）。</para>
        /// </summary>
        [Display(Name = "end_time")]
        [UnixDateTimeConverter]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 输出坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于控制返回结果中的坐标类型。可选值为：<br/>
        /// bd09ll：百度经纬度<br/>
        /// gcj02：国测局经纬度
        /// </para>
        /// <para>该参数仅对国内（包含港、澳、台）轨迹有效，海外区域轨迹均返回 wgs84坐标</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }
    }
}
