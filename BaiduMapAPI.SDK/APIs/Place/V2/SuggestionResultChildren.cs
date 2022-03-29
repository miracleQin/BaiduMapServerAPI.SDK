using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点输入提示服务 - poi子点
    /// </summary>
    public class SuggestionResultChild
    {
        /// <summary>
        /// poi子点ID
        /// <para>可用于poi详情检索。默认不召回，若有需求请联系我们(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }

        /// <summary>
        /// poi子点名称
        /// <para>默认不召回，若有需求请联系我们(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// poi子点简称
        /// <para>默认不召回，若有需求请联系我们(完成企业认证后，才能开通权限)</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("show_name")]
        public string ShowName { get; set; }
    }
}
