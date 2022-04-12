using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 轨迹重合率分析
    /// </summary>
    public class TrackMatch : Models.FormDataPostRequest<TrackMatchResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/trackmatch/v1/track?";

        /// <summary>
        /// 基准轨迹
        /// </summary>
        [Display(Name = "standard_track")]
        [Models.Attributes.ListModelFieldOderStringConverter]
        public List<TrackMatchPoint> StandardTrack { get; set; }

        /// <summary>
        /// 待匹配轨迹
        /// </summary>
        [Display(Name = "track")]
        [Models.Attributes.ListModelFieldOderStringConverter]
        public List<TrackMatchPoint> Track { get; set; }

        /// <summary>
        /// 基准轨迹的纠偏参数设置
        /// </summary>
        [Display(Name = "standard_option")]
        [Models.Attributes.FilterConverter]
        public RectifyOption StandardOption { get; set; }

        /// <summary>
        /// 待匹配轨迹的纠偏参数设置
        /// </summary>
        [Display(Name = "option")]
        [Models.Attributes.FilterConverter]
        public RectifyOption Option { get; set; }
    }
}
