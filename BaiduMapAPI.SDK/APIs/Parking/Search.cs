using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Parking
{
    /// <summary>
    /// 推荐上车点服务
    /// </summary>
    public class Search : Models.GetRequest<SearchResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/parking/search";

        /// <summary>
        /// 需查询周边推荐上车点的位置坐标
        /// </summary>
        [Display(Name = "location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 请求参数中坐标的类型
        /// <para>wgs84ll 即GPS经纬度</para>
        /// <para>gcj02ll 即国测局经纬度坐标</para>
        /// <para>bd09ll 即百度经纬度坐标</para>
        /// <para>bd09mc 即百度米制坐标</para>
        /// </summary>
        [Display(Name = "coord_type")]
        public Models.Enums.CoordType? CoordType { get; set; }
    }
}
