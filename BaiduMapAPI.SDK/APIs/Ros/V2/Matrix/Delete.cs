using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V2.Matrix
{
    /// <summary>
    /// 路网删除
    /// </summary>
    public class Delete : Models.JsonPutWithoutSNNoResponse
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v2/matrix/delete";

        /// <summary>
        /// 网点的集合Id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixIds")]
        public List<string> MatrixIds { get; set; }
    }
}
