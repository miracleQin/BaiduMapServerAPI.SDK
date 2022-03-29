using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.AddressAnalyzer.V1
{
    /// <summary>
    /// 地址解析聚合结果
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public GetResultResult Result { get; set; }
    }

    /// <summary>
    /// 结果信息
    /// </summary>
    public class GetResultResult 
    {
        /// <summary>
        /// 地址文本中提取出的主体信息
        /// <para>model=1时召回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地址文本中提取出的联系方式
        /// <para>model=1时召回</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tel")]
        public string Tel { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 省编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 市编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city_code")]
        public string CityCode { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        [Newtonsoft.Json.JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// 区县编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("county_code")]
        public string CountyCode { get; set; }

        /// <summary>
        /// 乡镇
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town")]
        public string Town { get; set; }

        /// <summary>
        /// 乡镇编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("town_code")]
        public string TownCode { get; set; }

        /// <summary>
        /// 道路
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road")]
        public string Road { get; set; }

        /// <summary>
        /// 道路编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_code")]
        public string RoadCode { get; set; }

        /// <summary>
        /// 路段
        /// <para>一条道路包含多个路段。括号内为该路段的语义化描述。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("section")]
        public string Section { get; set; }

        /// <summary>
        /// 路段编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("section_code")]
        public string SectionCode { get; set; }

        /// <summary>
        /// 聚合后的兴趣点名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("poi")]
        public string Poi { get; set; }

        /// <summary>
        /// 聚合后的兴趣点编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("poi_code")]
        public string PoiCode { get; set; }

        /// <summary>
        /// 输入地址不合规提示
        /// <para>"|行政区划冲突" "|行政区划冗余" "|省级地址结构缺失" "|省级行政区划错误" "|城市级地址结构缺失" "|城市级行政区划错误" "|区县级地址结构缺失" "|区县级行政区划错误" "|乡镇级地址结构缺失"</para>
        /// <para>行政区划冲突 注意：该功能为高级付费服务，用户不能直接在官网付费入口中直接购买，如有采买需求，请提交工单联系我们，将有商务与您取得联系。</para>
        /// <para>http://lbsyun.baidu.com/apiconsole/fankui#?typeOne=%E4%BA%A7%E5%93%81%E9%9C%80%E6%B1%82&typeTwo=%E6%96%B0%E6%9C%8D%E5%8A%A1/%E5%8A%9F%E8%83%BD%E9%9C%80%E6%B1%82</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("problem")]
        public string Problem { get; set; }
    }
}
