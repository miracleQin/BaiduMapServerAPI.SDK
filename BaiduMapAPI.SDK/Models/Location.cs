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
        public Location() { }
        public Location(double lat,double lng) 
        {
            this.Lat = lat;
            this.Lng = lng;
        }

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

        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }
    }

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
