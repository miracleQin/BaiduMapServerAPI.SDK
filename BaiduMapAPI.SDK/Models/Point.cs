using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 百度poi坐标
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X 坐标
        /// </summary>
        [Display(Name ="x" )]
        [Newtonsoft.Json.JsonProperty("x")]
        public double? X { get; set; }

        /// <summary>
        /// Y 坐标
        /// </summary>
        [Display(Name = "y")]
        [Newtonsoft.Json.JsonProperty("y")]
        public double? Y { get; set; }
    }
}
