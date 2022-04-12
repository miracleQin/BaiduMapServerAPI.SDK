using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 查询entity
    /// </summary>
    public class List : Models.GetWithoutSNRequest<ListResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/list";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 过滤条件
        /// </summary>
        [Display(Name ="filter")]
        [FilterConverter]
        public Filter Filter { get; set; }

        /// <summary>
        /// 返回结果的坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于控制返回结果中坐标的类型。可选值为：</para>
        /// <para>bd09ll：百度经纬度坐标</para>
        /// <para>gcj02：国测局加密坐标</para>
        /// <para>注：该字段在国外无效，国外均返回 wgs84坐标</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }


        /// <summary>
        /// 分页索引
        /// <para>默认值为1。page_index与page_size一起计算从第几条结果返回，代表返回第几页。</para>
        /// </summary>
        [Display(Name = "page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// <para>默认值为100。page_size与page_index一起计算从第几条结果返回，代表返回结果中每页有几条记录。</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }
    }

    /// <summary>
    /// 过滤条件
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// entity_name列表
        /// <para>多个entity用逗号分隔，精确筛选</para>
        /// </summary>
        [Display(Name = "entity_names")]
        [ListConverter(EncodeValue: false)]
        public List<string> EntityNames { get; set; }

        /// <summary>
        /// unix时间戳
        /// <para>查询在此时间之后有定位信息上传的entity（loc_time>=active_time）。</para>
        /// </summary>
        [Display(Name = "active_time")]
        [UnixDateTimeConverter]
        public DateTime? ActiveTime { get; set; }

        /// <summary>
        /// unix时间戳
        /// <para>查询在此时间之后无定位信息上传的entity（loc_time＜inactive_time）。</para>
        /// </summary>
        [Display(Name = "inactive_time")]
        [UnixDateTimeConverter]
        public DateTime? InactiveTime { get; set; }

        /// <summary>
        /// 开发者自定义的可筛选的entity属性字段
        /// <para>示例："team:北京"</para>
        /// </summary>
        [Display(Name = "team")]
        public string Team { get; set; }
    }
}
