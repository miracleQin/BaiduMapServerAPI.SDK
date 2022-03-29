using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 行政区划区域检索
    /// </summary>
    public class SearchByRegion:SearchBase
    {
        /// <summary>
        /// 支持全国、省、城市及对应百度编码
        /// <para>http://wiki.lbsyun.baidu.com/cms/citycode/BaiduMap_cityCode_1102.zip</para>
        /// <para>指定的区域的返回结果加权，可能返回其他城市高权重结果。若要对返回结果区域严格限制，请使用city_limit参数</para>
        /// </summary>
        [Display(Name = "region")]
        public string Region { get; set; }

        /// <summary>
        /// 取值为"true"，仅返回region中指定城市检索结果
        /// </summary>
        [Display(Name = "city_limit")]
        public bool? CityLimit { get; set; }
    }
}
