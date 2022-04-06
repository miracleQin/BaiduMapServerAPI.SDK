using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 轨迹纠偏
    /// </summary>
    public class Rectify : Models.FormDataPostRequest<RectifyResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/rectify/v1/track?";

        /// <summary>
        /// 轨迹点序列
        /// </summary>
        [Display(Name = "point_list")]
        [Models.Attributes.JsonConverter]
        public List<RectifyPoint> PointList { get; set; }

        /// <summary>
        /// 纠偏设置
        /// </summary>
        [Display(Name = "rectify_option")]
        [Models.Attributes.FilterConverter]
        public RectifyOption RectifyOption { get; set; }

        /// <summary>
        /// 里程补偿设置
        /// </summary>
        [Display(Name = "supplement_mode")]
        [Models.Attributes.EnumName]
        public Models.Enums.SupplementMode? SupplementMode { get; set; }
    }
}
