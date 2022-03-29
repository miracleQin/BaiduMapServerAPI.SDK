using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    public class RectifyPointBase
    {
        /// <summary>
        /// 轨迹点的定位时间
        /// <para>使用UNIX时间戳（秒级）</para>
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        [Newtonsoft.Json.JsonProperty("loc_time")]
        public DateTime LocalTime { get; set; }

        /// <summary>
        /// 纬度
        /// <para>支持小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// 经度
        /// <para>支持小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("longitude")]
        public double Longitude { get; set; }


        

        /// <summary>
        /// 轨迹点的速度
        /// <para>单位：公里/小时</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }

        /// <summary>
        /// 轨迹点的方向
        /// <para>单位：范围为[0,359]，0度为正北方向，顺时针方向递增</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public double? Direction { get; set; }

        /// <summary>
        /// 轨迹点的高度
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// 定位时返回的定位精度
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public double? Radius { get; set; }
    }

    public class RectifyPoint: RectifyPointBase
    {
        /// <summary>
        /// 轨迹点的坐标系
        /// <para>支持以下值：bd09ll（百度经纬度坐标）、gcj02（国测局加密坐标）、wgs84（GPS所采用的坐标系）</para>
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [Newtonsoft.Json.JsonProperty("coord_type_input")]
        public Models.Enums.CoordType CoordTypeInput { get; set; }
    }

    public class RectifyPointResult : RectifyPointBase 
    {
        /// <summary>
        /// 轨迹点的坐标系
        /// <para>支持以下值：bd09ll（百度经纬度坐标）、gcj02（国测局加密坐标）、wgs84（GPS所采用的坐标系）</para>
        /// </summary>
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [Newtonsoft.Json.JsonProperty("coord_type")]
        public Models.Enums.CoordType? CoordType { get; set; }
    }
}
