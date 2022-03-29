using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 实时路况查询-多边形区域路况查询
    /// </summary>
    public class Polygon : TrafficBase<TrafficResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/traffic/v1/polygon";

        /// <summary>
        /// 多边形边界点
        /// <para>多边形顶点，规则： 经纬度顺序为：纬度,经度； 顶点顺序需按逆时针排列。</para>
        /// </summary>
        [Display(Name= "vertexes")]
        [LocationListConverter(";")]
        public List<Models.Location> Vertexes { get; set; }
    }
}
