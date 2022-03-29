using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.RegionSearch.V1
{
    /// <summary>
    /// 行政区划查询服务 结果
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 行政区划数据版本
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data_version")]
        public string DataVersion { get; set; }

        /// <summary>
        /// 行政区划个数
        /// <para>检索到的包含关键字（keyword）信息的行政区划个数。如keyword=朝阳，返回result_size=44</para>
        /// <para>检索结果中包括“北京市朝阳区”，“辽宁省朝阳市”及其他42个带有“朝阳”关键字的乡镇街道信息。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result_size")]
        public int? ResultSize { get; set; }

        /// <summary>
        /// 行政区列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("districts")]
        public List<District> Districts { get; set; }
    }

    /// <summary>
    /// 行政区信息
    /// </summary>
    public class District
    {
        /// <summary>
        /// 行政区划编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 行政区划名称	
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 行政区划级别
        /// </summary>
        [Newtonsoft.Json.JsonProperty("level")]        
        public DistrictLevel? Level { get; set; }

        /// <summary>
        /// 下级行政区列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("districts")]
        public List<District> Districts { get; set; }
    }

    /// <summary>
    /// 行政区级别
    /// </summary>
    public enum DistrictLevel
    {
        /// <summary>
        /// 全国
        /// </summary>
        [Description("全国")]
        AllCountry = 0,

        /// <summary>
        /// 省
        /// </summary>
        [Description("省")]
        Province = 1,

        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        City = 2,

        /// <summary>
        /// 区/县
        /// </summary>
        [Description("区/县")]
        County = 3,

        /// <summary>
        /// 镇
        /// </summary>
        [Description("镇")]
        Town = 4,
    }
}
