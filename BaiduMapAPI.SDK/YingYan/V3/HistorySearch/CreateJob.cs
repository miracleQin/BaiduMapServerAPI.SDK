using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.HistorySearch
{
    /// <summary>
    /// 创建检索任务
    /// <para>在创建一个新的历史轨迹检索任务时，注意：<br/>
    /// 1. 只能检索距当前时间6小时之前的轨迹，例如：2021-11-15 10:00创建的任务只能检索2021-11-15 4:00之前产生的轨迹。<br/>
    /// 2. 检索的时间区间不超过24小时，即结束时间和起始时间差在24小时之内。<br/>
    /// 3. 每个service_id同时只允许存在10个未完成任务，超过10个则返回创建失败，请等待现有的任务处理完之后再创建新的任务。
    /// </para>
    /// </summary>
    public class CreateJob : Models.FormDataPostWithoutSNRequest<CreateJobResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://yingyan.baidu.com/api/v3/historysearch/createjob";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识。</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
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
        /// 圆形检索时的圆心及半径
        /// <para>around和bounds二选一</para>
        /// <para>格式：经度，纬度，半径<br/>
        /// 其中半径不能超过1000m<br/>
        /// 示例：119.493328,40.467639,100</para>
        /// <para>around和bounds参数不能都不设置，或都存在</para>
        /// </summary>
        [Display(Name ="around")]
        public Around Around { get; set; }

        /// <summary>
        /// 矩形检索时的矩形范围
        /// <para>around和bounds二选一</para>
        /// <para>注意是左下右上顺序的坐标<br/>
        /// 其中半径不能超过1000m<br/>
        /// 示例：119.493328,40.467639,119.501234,40.478878</para>
        /// <para>around和bounds参数不能都不设置，或都存在</para>
        /// </summary>
        [Display(Name = "bounds")]
        public BoundInfo Bounds { get; set; }

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

    /// <summary>
    /// 半径信息
    /// </summary>
    public class Around : Models.Location
    {
        /// <summary>
        /// 半径
        /// </summary>
        public int? Radius { get; set; }

        /// <summary>
        /// 转成字符串格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Lng},{this.Lat},{this.Radius}";
        }
    }

    /// <summary>
    /// 区域信息
    /// </summary>
    public class BoundInfo 
    {
        /// <summary>
        /// 区域左下角坐标
        /// </summary>
        public Models.Location LeftBottom { get; set; }

        /// <summary>
        /// 右上角坐标
        /// </summary>
        public Models.Location RightTop { get; set; }

        /// <summary>
        /// 转成字符串格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{LeftBottom.Lng},{LeftBottom.Lat},{RightTop.Lng},{RightTop.Lat}";
        }
    }
}
