using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.DirectionLite.V1
{
    /// <summary>
    /// 步行规划返回参数
    /// </summary>
    public class WalkingResult : Models.ResponseOld
    {
        /// <summary>
        /// 返回的结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public DrivingResultResult Result { get; set; }
    }
}
