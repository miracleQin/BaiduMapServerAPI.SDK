using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 道路路况查询
    /// </summary>
    public class Road : Models.GetRequest<RoadResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/traffic/v1/road";

        /// <summary>
        /// 道路名称
        /// <para>如："北五环"、"信息路"。</para>
        /// <para>目前支持除多方向立交桥和多方向道路以外的各类道路名称（注：多方向是指道路方向多于2个方向，如：南向北、北向南、西向东、东向西，称为4方向）</para>
        /// </summary>
        [Display(Name= "road_name")]
        public string RoadName { get; set; }

        /// <summary>
        /// 所在城市
        /// <para>1. 全国城市名称，如："北京市"、"上海市"等</para>
        /// <para>2. 百度地图行政区划adcode，仅支持城市级别（adcode映射表），如"110000"</para>
        /// <para>http://lbsyun.baidu.com/index.php?title=open/dev-res</para>
        /// </summary>
        [Display(Name ="city")]
        public string City { get; set; }
    }
}
