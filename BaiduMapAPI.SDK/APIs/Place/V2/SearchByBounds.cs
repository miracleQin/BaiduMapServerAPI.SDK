using BaiduMapAPI.Models;
using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地址检索-矩形区域检索
    /// </summary>
    public class SearchByBounds : SearchBase
    {
        /// <summary>
        /// 检索矩形区域
        /// </summary>
        [Display(Name = "bounds")]
        [BoundsConverter]
        public Bound Bounds { get; set; }
    }
}
