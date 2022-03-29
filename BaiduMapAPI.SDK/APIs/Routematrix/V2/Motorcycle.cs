using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Routematrix.V2
{
    /// <summary>
    /// 批量算路-摩托车
    /// <para>摩托车批量算路为开放平台高级服务，需申请开通权限后才能访问服务</para>
    /// <para>https://lbsyun.baidu.com/apiconsole/quota#/home?jumpService=multi_motorcycle</para>
    /// </summary>
    public class Motorcycle : GetBase<MotorcycleResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/routematrix/v2/motorcycle";

        /// <summary>
        /// 摩托车驾车偏好
        /// </summary>
        [Display(Name = "tactics")]
        [EnumValue]
        public new MotorcycleTactics? Tactics { get; set; }
    }
}
