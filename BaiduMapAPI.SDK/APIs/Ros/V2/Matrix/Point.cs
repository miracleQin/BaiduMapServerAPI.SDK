using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V2.Matrix
{
    /// <summary>
    /// 网点线路更新
    /// </summary>
    public class Point:Models.JsonPutWithoutSN<V1.Matrix.PostResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v2/matrix/point";
        /// <summary>
        /// 路网ID
        /// </summary>
        [Display(Name = "matrixId")]
        [QueryParameter("matrixId")]
        [Newtonsoft.Json.JsonIgnore]
        public string MatrixId { get; set; }

        /// <summary>
        /// 网点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("from")]
        public V1.Matrix.PostLocation From { get; set; }

        /// <summary>
        /// 网点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("to")]
        public V1.Matrix.PostLocation To { get; set; }
    }
}
