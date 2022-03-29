using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 逆地理编码
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 逆地理编码
        /// </summary>
        public Get()
        {
            this.Output = "json";
        }
        public override string URL => "https://api.map.baidu.com/reverse_geocoding/v3/";

        /// <summary>
        /// 根据经纬度坐标获取地址。
        /// </summary>
        [Display(Name = "location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 坐标的类型
        /// <para>目前支持的坐标类型包括：bd09ll（百度经纬度坐标）、bd09mc（百度米制坐标）、gcj02ll（国测局经纬度坐标，仅限中国）、wgs84ll（ GPS经纬度）</para>
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "coordtype")]
        public Models.Enums.CoordType? Coordtype { get; set; }

        /// <summary>
        /// 可选参数，添加后返回国测局经纬度坐标或百度米制坐标
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        public Models.Enums.CoordType? RetCoordtype { get; set; }

        /// <summary>
        /// poi召回半径
        /// <para>允许设置区间为0-1000米，超过1000米按1000米召回</para>
        /// </summary>
        [Display(Name = "radius")]
        public int? Radius { get; set; }

        /// <summary>
        /// 输出格式为json或者xml
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; private set; }

        /// <summary>
        /// 可以选择poi类型召回不同类型的poi
        /// <para>例如poi_types=酒店，如想召回多个POI类型数据，可以‘|’分割例如poi_types=酒店|房地产不添加该参数则默认召回全部POI分类数据。</para>
        /// <para>http://lbsyun.baidu.com/index.php?title=lbscloud/poitags</para>
        /// </summary>
        [Display(Name = "poi_types")]
        [ListConverter("|")]
        public List<string> PoiTypes { get; set; }

        /// <summary>
        /// 是否返回pois数据
        /// <para>（默认显示周边1000米内的poi），并返回sematic_description语义化数据。</para>
        /// </summary>
        [Display(Name = "extensions_poi")]
        [BoolToNumConverter]
        public bool? ExtensionsPoi { get; set; }

        /// <summary>
        /// 是否召回坐标周围最近的3条道路数据
        /// <para>区别于行政区划中的street参数（street参数为行政区划中的街道，和普通道路不对应）</para>
        /// </summary>
        [Display(Name = "extensions_road")]
        public bool? ExtensionsRoad { get; set; }

        /// <summary>
        /// 行政区划返回乡镇级数据（town）
        /// <para>仅国内召回乡镇数据。默认不访问。</para>
        /// </summary>
        [Display(Name = "extensions_town")]
        public bool? ExtensionsTown { get; set; }

        /// <summary>
        /// 指定召回的行政区划语言类型
        /// <para>召回行政区划语言list（全量支持的语言见示例）。</para>
        /// <para>el gu en vi ca it iw sv eu ar cs gl id es en-GB ru sr nl pt tr tl lv en-AU lt th ro fil ta fr bg hr bn de hu fa hi pt-BR fi da ja te pt-PT ml ko kn sk zh-CN pl uk sl mr local</para>
        /// <para>当language=local时，根据请求中坐标所对应国家的母语类型，自动选择对应语言类型的行政区划召回。</para>
        /// <para>目前支持多语言的行政区划区划包含country、province、city、district</para>
        /// </summary>
        [Display(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// 当用户指定language参数时，是否自动填充行政区划
        /// <para>当服务按某种语言类别召回时，若某一行政区划层级的语言数据未覆盖，则按照“英文→中文→本地语言”类别行政区划数据对该层级行政区划进行填充，保证行政区划数据召回完整性。</para>
        /// </summary>
        [Display(Name = "language_auto")]
        [BoolToNumConverter]
        public bool? LanguageAuto { get; set; }
    }
}
