using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Geoconv.V1
{
    /// <summary>
    /// 坐标转换服务结果
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 转换结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public List<Models.Point> Result { get; set; }
    }
}
