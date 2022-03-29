using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Routematrix.V2
{
    /// <summary>
    /// 批量算路-骑行
    /// </summary>
    public class Riding : GetBase<RidingResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/routematrix/v2/riding";

        /// <summary>
        /// 骑行类型
        /// </summary>
        [Display(Name="riding_type")]
        [EnumValue]
        public RidingType? RidingType { get; set; }
    }

    /// <summary>
    /// 骑行类型
    /// </summary>
    public enum RidingType
    {
        /// <summary>
        /// 自行车
        /// </summary>
        [Description("自行车")]
        Bicycle = 0,

        /// <summary>
        /// 电动自行车
        /// </summary>
        [Description("电动自行车")]
        ElectricBicycle = 1,
    }
}
