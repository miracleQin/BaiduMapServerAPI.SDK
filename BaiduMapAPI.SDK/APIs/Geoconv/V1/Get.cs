using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Geoconv.V1
{
    /// <summary>
    /// 坐标转换服务
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/geoconv/v1/";


        /// <summary>
        /// 需转换的源坐标(必填)
        /// </summary>
        [Display(Name = "coords")]
        [LocationListConverter(";")]
        public List<Models.Location> Coords { get; set; }

        /// <summary>
        /// 源坐标类型
        /// <para>可用枚举所有类型</para>
        /// </summary>
        [Display(Name = "from")]
        public CoordType? From { get; set; }

        /// <summary>
        /// 目标坐标类型
        /// <para>可选范围：gcj02、bd09ll、bd09mc</para>
        /// </summary>
        [Display(Name = "to")]
        public CoordType? To { get; set; }

        /// <summary>
        /// 返回结果格式
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";
    }

    /// <summary>
    /// 坐标类型
    /// </summary>
    public enum CoordType
    {
        /// <summary>
        /// GPS标准坐标（wgs84）
        /// </summary>
        [Description("GPS标准坐标（wgs84）")]
        wgs84 = 1,

        /// <summary>
        /// 搜狗地图坐标
        /// </summary>
        [Description("搜狗地图坐标")]
        SouGou = 2,

        /// <summary>
        /// 火星坐标（gcj02）
        /// <para>即高德地图、腾讯地图和MapABC等地图使用的坐标</para>
        /// </summary>
        [Description("火星坐标（gcj02）")]
        gcj02 = 3,

        /// <summary>
        /// 墨卡托平面坐标
        /// <para>火星坐标（gcj02）中列举的地图坐标对应的墨卡托平面坐标</para>
        /// </summary>
        [Description("墨卡托平面坐标")]
        Mercator = 4,

        /// <summary>
        /// 百度地图采用的经纬度坐标（bd09ll）
        /// </summary>
        [Description("百度地图采用的经纬度坐标（bd09ll）")]
        bd09ll = 5,

        /// <summary>
        /// 百度地图采用的墨卡托平面坐标（bd09mc）
        /// </summary>
        [Description("百度地图采用的墨卡托平面坐标（bd09mc）")]
        bd09mc = 6,

        /// <summary>
        /// 图吧地图坐标
        /// </summary>
        [Description("图吧地图坐标")]
        MapTuba = 7,

        /// <summary>
        /// 51地图坐标
        /// </summary>
        [Description("51地图坐标")]
        Map51 = 8,
    }
}
