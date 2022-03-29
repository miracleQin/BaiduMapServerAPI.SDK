using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Matrix
{
    /// <summary>
    /// 路网任务权重修改接口
    /// </summary>
    public class Weight : Models.JsonPutWithoutSN<WeightResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v1/matrix/weight";

        /// <summary>
        /// 路网ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixId")]
        public string MatrixID { get; set; }

        /// <summary>
        /// 该路网的权重
        /// <para>0最低， 10最高</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("weight")]
        public int WeightValue { get; set; }
    }
}
