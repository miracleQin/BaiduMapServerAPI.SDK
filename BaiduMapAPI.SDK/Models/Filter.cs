using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 检索过滤条件
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 行业类型
        /// <para>注意：设置该字段可提高检索速度和过滤精度</para>
        /// </summary>
        [Display(Name = "industry_type")]        
        public IndustryType? IndustryType { get; set; }

        /// <summary>
        /// 排序字段
        /// <para>根据industry_type字段的值而定。</para>
        /// </summary>
        [Display(Name = "sort_name")]
        public SortName? SortName { get; set; }

        /// <summary>
        /// 排序规则
        /// </summary>
        [Display(Name = "sort_rule")]
        [Models.Attributes.EnumValue]
        public SortRule? SortRule { get; set; }

        /// <summary>
        /// 价格区间
        /// </summary>
        [Display(Name = "price_section")]
        [PriceSectionConverter]
        public PriceSection PriceSection { get; set; }

        /// <summary>
        /// 是否有团购
        /// </summary>
        [Display(Name = "groupon")]
        [Models.Attributes.EnumValue]
        public HasOrNot? Groupon { get; set; }

        /// <summary>
        /// 是否有打折
        /// </summary>
        [Display(Name = "discount")]
        [Models.Attributes.EnumValue]
        public HasOrNot? Discount { get; set; }

        //public override string ToString()
        //{
        //    List<string> result = new List<string>();

        //    foreach (var propertyInfo in this.GetType().GetProperties())
        //    {
        //        var val = propertyInfo.GetValue(this);
        //        string valStr = null;
        //        if (val != null && (valStr = val.ToString()) != "")
        //        {
        //            var attr = propertyInfo.GetCustomAttribute<DisplayAttribute>();
        //            result.Add($"{attr}:{valStr}");
        //        }
        //    }
        //    return string.Join("|", result);
        //}
    }
}
