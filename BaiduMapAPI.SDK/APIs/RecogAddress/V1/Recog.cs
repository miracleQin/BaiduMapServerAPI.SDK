using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.RecogAddress.V1
{
    /// <summary>
    /// 地址城乡类型判别
    /// <para>注意：城乡类型判别是付费高级服务，您可以联系我们开通15天试用并了解更多信息。</para>
    /// </summary>
    public class Recog : Models.GetRequest<RecogResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/api_recog_address/v1/recog";

        /// <summary>
        /// 需要解析的地址
        /// </summary>
        [Display(Name="address")]
        public string Address { get; set; }

        /// <summary>
        /// 判断地址address是否加密
        /// <para>默认是不加密</para>
        /// <para>加密方式请通过反馈平台与我们联系</para>
        /// </summary>
        [Display(Name = "is_encry_address")]
        [BoolToNumConverter]
        public bool? IsEncryAddress { get; set; }

        /// <summary>
        /// 是否返回特殊区域标识
        /// </summary>
        [Display(Name = "is_airport_or_develop")]
        [BoolToNumConverter]
        public bool? IsAirportOrDevelop { get; set; }
    }
}
