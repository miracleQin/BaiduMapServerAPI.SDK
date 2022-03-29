using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.RegionSearch.V1
{
    /// <summary>
    /// 行政区划查询服务
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://api.map.baidu.com/api_region_search/v1/";

        /// <summary>
        /// 检索行政区划关键字
        /// <para>行政区划区域检索不支持多关键字检索 关键字可填写：行政区名称（"中华人民共和国"/"中国"/"全国"，省、市、区和镇名称）以及 adcode；</para>
        /// <para>Adcode信息可参考（百度地图行政区划adcode映射表） http://lbsyun.baidu.com/index.php?title=open/dev-res</para>
        /// </summary>
        [Display(Name = "keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// 行政区划显示子级级数
        /// <para>可显示行政区划级别包含多级行政区划：国家（仅限中国）、省/直辖市、市、区/县、乡镇/街道</para>
        /// </summary>
        [Display(Name = "sub_admin")]
        [EnumValue]
        public SubAdmin? SubAdmin { get; set; }

        /// <summary>
        /// 是否召回国标行政区划编码
        /// </summary>
        [Display(Name = "extensions_code")]
        [BoolToNumConverter]
        public bool? ExtensionsCode { get; set; }
    }

    /// <summary>
    /// 下级行政区模式
    /// </summary>
    public enum SubAdmin
    {
        /// <summary>
        /// 不返回下级行政区
        /// </summary>
        [Description("不返回下级行政区")]
        None = 0,

        /// <summary>
        /// 返回下一级行政区
        /// </summary>
        [Description("返回下一级行政区")]
        Level_1=1,

        /// <summary>
        /// 返回下两级行政区
        /// </summary>
        [Description("返回下两级行政区")]
        Level_2 = 2,

        /// <summary>
        /// 返回下三级行政区
        /// </summary>
        [Description("返回下三级行政区")]
        Level_3 = 3,
    }
}
