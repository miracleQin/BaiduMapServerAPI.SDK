using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.TimeZone.V1
{
    /// <summary>
    /// 时区服务
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/timezone/v1";


        /// <summary>
        /// 需查询时区的位置坐标(必填)
        /// <para>当前仅支持全球陆地坐标查询，海域坐标暂不支持。</para>
        /// </summary>
        [Display(Name = "location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 请求参数中坐标的类型
        /// <para>wgs84即GPS经纬度，gcj02即国测局经纬度坐标，bd09ll即百度经纬度坐标，bd09mc即百度米制坐标 坐标系说明</para>
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "coord_type")]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 所需时间(必填)
        /// <para>用于判断夏令时</para>
        /// <para>以协调世界时 1970 年 1 月 1 日午夜以来的秒数表示（即Unix时间戳）。</para>
        /// </summary>
        [Display(Name = "timestamp")]
        [UnixDateTimeConverter]
        public DateTime? Timestamp { get; set; }
    }
}
