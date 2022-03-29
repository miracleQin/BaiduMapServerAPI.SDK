using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 普通IP定位 - 列表结果对象
    /// </summary>
    public class SuggestionResultItem
    {
        /// <summary>
        /// poi名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// poi经纬度坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// poi的唯一标示，ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Newtonsoft.Json.JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 百度城市编码 详情见资源下载citycode编码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("cityid")]
        public string CityID { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 行政区划代码
        /// <para>http://lbsyun.baidu.com/index.php?title=open/dev-res</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("adcode")]
        public int? Adcode { get; set; }

        /// <summary>
        /// 商圈
        /// </summary>
        [Newtonsoft.Json.JsonProperty("business")]
        public string Business { get; set; }

        /// <summary>
        /// poi分类
        /// <para>默认不召回，若有需求请联系我们(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// poi地址
        /// <para>默认不召回，若有需求请联系我们(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// poi子点
        /// <para>默认不召回，若有需求请联系我们；地点输入提示中的子点为简要信息，无poi坐标，如需要坐标，可通过返回的子点uid，使用地点检索中的地点详情检索功能检索坐标信息。(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("children")]
        public List<SuggestionResultChild> Children { get; set; }
    }
}
