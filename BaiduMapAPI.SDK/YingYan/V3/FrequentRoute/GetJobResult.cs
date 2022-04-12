using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.FrequentRoute
{
    /// <summary>
    /// 查询任务，将返回计算出的经验路线，可能为多条经验路线 结果
    /// </summary>
    public class GetJobResult : Models.ResponseOld
    {
        /// <summary>
        /// 数据结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data")]
        public Data Data { get; set; }
    }
}
