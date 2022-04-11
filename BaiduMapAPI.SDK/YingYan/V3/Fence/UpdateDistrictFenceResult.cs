using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 更新行政区划围栏 结果
    /// </summary>
    public class UpdateDistrictFenceResult : Models.ResponseOld
    {
        /// <summary>
        /// 结构化的行政区划描述
        /// <para>status=0，围栏创建成功时返回该字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// 关键字匹配的行政区划列表
        /// <para>status=5108，围栏创建失败，关键字匹配至多个行政区时，返回该字段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district_list")]
        public List<string> DistrictList { get; set; }
    }
}
