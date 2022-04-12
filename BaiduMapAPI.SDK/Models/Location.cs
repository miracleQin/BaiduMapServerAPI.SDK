using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 百度地图坐标对象
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 百度地图坐标对象
        /// </summary>
        public Location() { }

        /// <summary>
        /// 百度地图坐标对象
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        public Location(double lat,double lng) 
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        /// <summary>
        /// 百度地图坐标对象
        /// </summary>
        /// <param name="locationStr">坐标信息<br/>格式：lng,lat</param>
        public Location(string locationStr) 
        {
            var infos = locationStr.Split(',');
            double lat, lng;
            if (double.TryParse(infos[1], out lat) && double.TryParse(infos[0], out lng)) 
            {
                this.Lat = lat;
                this.Lng = lng;
            }
        }
        /// <summary>
        /// 经度
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lng")]
        public double? Lng { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lat")]
        public double? Lat { get; set; }

        /// <summary>
        /// 转成字符串
        /// <para>格式:lat,lng</para>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }
    }

    /// <summary>
    /// 坐标详情
    /// </summary>
    public class LocationDetail 
    {
        /// <summary>
        /// 经度
        /// <para>经度，支持小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// <para>纬度，支持小数点后6位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latitude")]
        public double? Latitude { get; set; }
    }
}
