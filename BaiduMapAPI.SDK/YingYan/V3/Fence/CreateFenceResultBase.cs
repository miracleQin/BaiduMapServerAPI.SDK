using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 创建围栏基础结果
    /// </summary>
    public class CreateFenceResultBase : Models.ResponseOld
    {
        /// <summary>
        /// 围栏的唯一标识
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_id")]
        public int? FenceID { get; set; }
    }
}
