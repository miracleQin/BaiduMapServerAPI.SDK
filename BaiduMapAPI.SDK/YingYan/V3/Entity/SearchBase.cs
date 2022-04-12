using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 空间搜索通用基类
    /// </summary>
    public abstract class SearchBase : Models.GetWithoutSNRequest<SearchResult>
    {

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
        [Display(Name = "filter")]
        [FilterConverter]
        public Filter Filter { get; set; }

        /// <summary>
        /// 排序方法
        /// </summary>
        [Display(Name ="sortby")]
        public SortByInfo SortBy { get; set; }

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
    /// 原有字段排序逻辑
    /// </summary>
    public enum SortBy
    {
        /// <summary>
        /// 按名称升序
        /// </summary>
        [CustomDescription("按名称升序", "entity_name:asc")]
        EntityNameAsc = 1,

        /// <summary>
        /// 按名称降序
        /// </summary>
        [CustomDescription("按名称降序", "entity_name:desc")]
        EntityNameDesc = 2,

        /// <summary>
        /// 按最新定位时间升序
        /// </summary>
        [CustomDescription("按最新定位时间升序", "loc_time:asc")]
        LocationTimeAsc = 3,

        /// <summary>
        /// 按最新定位时间降序
        /// </summary>
        [CustomDescription("按最新定位时间降序", "loc_time:desc")]
        LocationTimeDesc = 4,

        /// <summary>
        /// 按最新定位时间升序
        /// </summary>
        [CustomDescription("按最新定位时间升序", "entity_desc:asc")]
        EntityDescriptionAsc = 5,

        /// <summary>
        /// 按最新定位时间降序
        /// </summary>
        [CustomDescription("按最新定位时间降序", "entity_desc:desc")]
        EntityDescriptionDesc = 6,
    }

    /// <summary>
    /// 排序信息
    /// </summary>
    public class SortByInfo
    {
        /// <summary>
        /// 原有字段排序
        /// <para>若是自定义字段排序该属性设 null</para>
        /// </summary>
        public SortBy? SortBy { get; set; }

        /// <summary>
        /// 自定义字段名称
        /// <para>若要按自定义字段来排序，则该字段需填写要排序的字段名称</para>
        /// </summary>
        public string Column { get; set; }


        /// <summary>
        /// 自定义字段排序规则
        /// <para>若要以自定义字段排序，则该字段需设置排序规则</para>
        /// </summary>
        public Models.Enums.SortRule? ColumnSortRule { get; set; }

        /// <summary>
        /// 获取字符串结果
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.SortBy.HasValue)
            {
                var customDescription = this.SortBy.GetCustomDescription();
                return customDescription.Value.ToString();
            }
            else
            {
                return $"{Column}:{ColumnSortRule?.ToString().ToLower()}";
            }
        }
    }
}
