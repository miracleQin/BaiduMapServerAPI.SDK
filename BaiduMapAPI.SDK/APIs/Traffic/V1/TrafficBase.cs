using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 区域路况通用请求
    /// </summary>
    public abstract class TrafficBase<TResponse> : Models.GetRequest<TResponse>
        where TResponse : Models.Response
    {
        /// <summary>
        /// 道路等级
        /// <para>用户可进行道路等级筛选，支持选择多个道路等级。道路等级之间使用英文“,”分隔。</para>
        /// <para>示例： 查询全部驾车道路路况：road_grade:0 查询高速道路路况：road_grade:1 查询高速路、环路及快速路、主干路的路况：road_grade=1,2,3</para>
        /// <para>提示：该枚举成员的值已设置为 2 的 N 次方，这里若要查多个，可用枚举或运算拼接起来。</para>
        /// </summary>
        [Display(Name = "road_grade")]
        [CustomDescriptionConverter]
        public RoadGrade? RoadGrade { get; set; }

        /// <summary>
        /// 请求参数 bounds的坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>取值范围： bd09ll：百度经纬度坐标 gcj02：国测局加密坐标 wgs84：gps 坐标</para>
        /// </summary>
        [Display(Name = "coord_type_input")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeInput { get; set; }

        /// <summary>
        /// 返回结果的坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于控制返回结果中坐标的类型。可选值为： bd09ll：百度经纬度坐标 gcj02：国测局加密坐标</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }
    }


    /// <summary>
    /// 道路等级
    /// </summary>
    public enum RoadGrade
    {
        /// <summary>
        /// 全部驾车道路
        /// </summary>
        [CustomDescription("全部驾车道路", 0)]
        All = 2,

        /// <summary>
        /// 高速路
        /// </summary>
        [CustomDescription("高速路", 1)]
        HighSpeedRoad = 4,

        /// <summary>
        /// 环路及快速路
        /// </summary>
        [CustomDescription("环路及快速路", 2)]
        Expressway = 8,

        /// <summary>
        /// 主干路
        /// </summary>
        [CustomDescription("主干路", 3)]
        TrunkRoad = 16,

        /// <summary>
        /// 次干路
        /// </summary>
        [CustomDescription("次干路", 4)]
        SecondaryTrunkRoad = 32,

        /// <summary>
        /// 支干路
        /// </summary>
        [CustomDescription("支干路", 5)]
        BranchRoad = 64,
    }
}
