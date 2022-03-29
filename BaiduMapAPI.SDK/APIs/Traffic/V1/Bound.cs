using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Traffic.V1
{
    /// <summary>
    /// 矩形区域路况查询
    /// </summary>
    public class Bound : TrafficBase<TrafficResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/traffic/v1/bound";

        /// <summary>
        /// 矩形区域, 左下角和右上角的经纬度坐标点
        /// <para>坐标点顺序为"左下;右上"，坐标对间使用;号分隔，格式为：纬度,经度;纬度,经度。对角线距离不超过2公里。</para>
        /// </summary>
        [Display(Name = "bounds")]
        [BoundInfoConverter]
        public BoundInfo Bounds { get; set; }
    }

    /// <summary>
    /// 矩形区域, 左下角和右上角的经纬度坐标点
    /// </summary>
    public class BoundInfo
    {
        /// <summary>
        /// 左下角
        /// </summary>
        public Models.Location LeftBottom { get; set; }

        /// <summary>
        /// 右上角
        /// </summary>
        public Models.Location RightTop { get; set; }
    }

}
