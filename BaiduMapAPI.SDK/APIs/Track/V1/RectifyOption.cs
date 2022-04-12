using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Track.V1
{
    /// <summary>
    /// 待匹配轨迹的纠偏参数设置
    /// </summary>
    public class RectifyOption
    {
        /// <summary>
        /// 是否需要将轨迹点绑路并补充道路形状点
        /// </summary>
        [Display(Name = "need_mapmatch")]
        [Models.Attributes.BoolToNumConverter]
        public bool? NeedMapmatch { get; set; }

        /// <summary>
        /// 交通方式
        /// </summary>
        [Display(Name = "transport_mode")]
        [Models.Attributes.EnumName]
        public Models.Enums.TransportMode? TransportMode { get; set; }


        /// <summary>
        /// 去噪力度
        /// <para>取值范围[0,5]，数值越大去噪力度越大，代表越多的点会被当做噪点去除。若取值0，则代表不去噪</para>
        /// </summary>
        [Display(Name = "denoise_grade")]
        [Models.Attributes.EnumValue]
        public Models.Enums.DenoiseGrade? DenoiseGrade { get; set; }


        /// <summary>
        /// 抽稀力度
        /// <para>取值范围[0,5]，数值越大抽稀度力度越大，代表轨迹会越稀疏。若取值0，则代表不抽稀</para>
        /// </summary>
        [Display(Name = "vacuate_grade")]
        [Models.Attributes.EnumValue]
        public Models.Enums.VacuateGrade? VacuateGrade { get; set; }
    }
}
