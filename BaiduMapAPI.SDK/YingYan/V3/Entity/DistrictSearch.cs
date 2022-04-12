using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 行政区搜索，搜索行政区范围内的entity
    /// <para>搜索中国范围内，国家、省、市、区/县中的entity</para>
    /// </summary>
    public class DistrictSearch : SearchBase
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/districtsearch";

        /// <summary>
        /// 行政区划关键字(必填)
        /// <para>支持中国范围内的国家、省、市、区/县名称。请尽量输入完整的行政区层级和名称，保证名称的唯一性。若输入的行政区名称匹配多个行政区，搜索会失败，将会返回匹配的行政区列表。</para>
        /// <para>关键字示例： 中国 北京市 湖南省长沙市 湖南省长沙市雨花区</para>
        /// </summary>
        [Display(Name = "keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// 设置返回值的内容
        /// <para>默认值为：all</para>
        /// </summary>
        [Display(Name = "return_type")]
        public ReturnType? ReturnType { get; set; }
    }

    /// <summary>
    /// 设置返回值的内容
    /// </summary>
    public enum ReturnType
    {
        /// <summary>
        /// 仅返回 total
        /// <para>即符合本次检索条件的所有entity 数量（若仅需行政区内entity数量，建议选择 simple，将提升检索性能）</para>
        /// </summary>
        [CustomDescription("仅返回 total", "simple")]
        Simple = 0,

        /// <summary>
        /// 返回全部结果
        /// </summary>
        [CustomDescription("返回全部结果", "all")]
        All = 1,
    }
}
