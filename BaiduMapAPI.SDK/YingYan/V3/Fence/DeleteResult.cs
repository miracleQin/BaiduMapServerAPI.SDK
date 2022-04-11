using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 删除围栏 结果
    /// </summary>
    public class DeleteResult : Models.ResponseOld
    {
        /// <summary>
        /// 围栏id列表
        /// <para>返回删除成功的围栏 id 列表</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_ids")]
        public List<int> FenceIDs { get; set; }
    }
}
