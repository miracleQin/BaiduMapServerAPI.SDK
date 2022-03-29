using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 实时路况查询-周边路况查询
    /// </summary>
    public class Around : TrafficBase<TrafficResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/traffic/v1/around";

        /// <summary>
        /// 中心点坐标
        /// </summary>
        [Display(Name = "center")]
        public Models.Location Center { get; set; }

        /// <summary>
        /// 查询半径
        /// <para>单位：米</para>
        /// <para>取值范围[1,1000]</para>
        /// </summary>
        [Display(Name = "radius")]
        public int? Radius { get; set; }
    }
}
