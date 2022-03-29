using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Routematrix.V2
{
    /// <summary>
    /// 批量算路基础类
    /// <para>该服务不支持SN校验方式，请使用IP白名单校验方式。</para>
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class GetBase<TResponse> : Models.GetWithoutSNRequest<TResponse>
        where TResponse : GetResultBase
    {

        /// <summary>
        /// 起点
        /// <para>【步骑行、摩托车】支持传入起点uid提升绑路准确性，格式为：纬度,经度;POI的uid|纬度,经度;POI的uid。</para>
        /// </summary>
        [Display(Name = "origins")]
        [LocationListConverter]
        public List<Models.Location> Origins { get; set; }

        /// <summary>
        /// 终点
        /// <para>【步骑行、摩托车】支持传入起点uid提升绑路准确性，格式为：纬度,经度;POI的uid|纬度,经度;POI的uid。</para>
        /// </summary>
        [Display(Name = "destinations")]
        [LocationListConverter]
        public List<Models.Location> Destinations { get; set; }

        /// <summary>
        /// 驾车偏好
        /// </summary>
        [Display(Name = "tactics")]
        [EnumValue]
        public Tactics? Tactics { get; set; }

        /// <summary>
        /// 表示输出类型
        /// <para>可设置为xml或json</para>
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";


        /// <summary>
        /// 坐标类型
        /// <para>可选值为：bd09ll（百度经纬度坐标）、bd09mc（百度墨卡托坐标）、gcj02（国测局加密坐标）、wgs84（gps设备获取的坐标）。</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }
    }

    /// <summary>
    /// 驾车偏好
    /// </summary>
    public enum Tactics
    {
        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NoHighWay = 10,

        /// <summary>
        /// 常规路线
        /// <para>即多数用户常走的一条经验路线，满足大多数场景需求，是较推荐的一个策略</para>
        /// </summary>
        [Description("常规路线")]
        Nomarl = 11,

        /// <summary>
        /// 距离较短（考虑路况）
        /// <para>即距离相对较短的一条路线，但并不一定是一条优质路线。计算耗时时，考虑路况对耗时的影响；</para>
        /// </summary>
        [Description("距离较短（考虑路况）")]
        ShortDistance = 12,

        /// <summary>
        /// 距离较短（不考虑路况）
        /// <para>路线同以上，但计算耗时时，不考虑路况对耗时的影响，可理解为在路况完全通畅时预计耗时。 </para>
        /// </summary>
        [Description("距离较短（不考虑路况）")]
        ShortDistanceWithout = 13,
    }

    /// <summary>
    /// 摩托车驾车偏好
    /// </summary>
    public enum MotorcycleTactics
    {
        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NoHighWay = 10,

        /// <summary>
        /// 最短时间
        /// </summary>
        [Description("最短时间")]
        ShortTime = 11,

        /// <summary>
        /// 距离较短
        /// </summary>
        [Description("距离较短")]
        ShortDistance = 12,
    }
}
