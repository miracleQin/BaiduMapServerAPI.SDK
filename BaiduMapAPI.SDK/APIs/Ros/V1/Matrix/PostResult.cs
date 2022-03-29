using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Matrix
{
    /// <summary>
    /// 路网创建接口
    /// </summary>
    public class PostResult : Models.ResponseNew
    {
        /// <summary>
        /// 路网ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// 路网版本
        /// <para>增加网点删除网点更新网点 路网版本会变化，路网ID不变</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("commitId")]
        public string CommitId { get; set; }

    }
}
