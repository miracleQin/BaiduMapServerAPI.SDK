using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class TrackMatchPoint
    {
        /// <summary>
        /// 纬度
        /// <para>支持小数点后6位</para>
        /// </summary>
        [Display(Name = "latitude", Order = 1)]
        public double Latitude { get; set; }

        /// <summary>
        /// 经度
        /// <para>支持小数点后6位</para>
        /// </summary>
        [Display(Name = "longitude", Order = 2)]
        public double Longitude { get; set; }

        /// <summary>
        /// 时间
        /// <para>不需要纠偏去噪时选填，需要纠偏去噪时必填。轨迹点的定位时间，使用UNIX时间戳（秒级）</para>
        /// </summary>
        [Display(Name = "loc_time", Order = 3)]
        [Models.Attributes.UnixDateTimeConverter]
        public DateTime? LocalTime { get; set; }

        /// <summary>
        /// 轨迹点的速度(选填)
        /// <para>轨迹点的速度</para>
        /// <para>单位：公里/小时</para>
        /// </summary>
        [Display(Name = "speed", Order = 4)]
        public double? Speed { get; set; }

        /// <summary>
        /// 轨迹点的方向(选填)
        /// <para>轨迹点的方向</para>
        /// <para>单位：范围为[0,359]，0度为正北方向，顺时针方向递增</para>
        /// </summary>
        [Display(Name = "direction", Order = 5)]
        public int? Direction { get; set; }

        /// <summary>
        /// 轨迹点的高度(选填)
        /// <para>轨迹点的高度</para>
        /// <para>单位：米</para>
        /// </summary>
        [Display(Name = "height", Order = 6)]
        public double? Height { get; set; }
    }
}
