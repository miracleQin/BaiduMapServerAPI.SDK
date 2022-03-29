using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V2.Matrix
{
    /// <summary>
    /// 路网查询接口
    /// </summary>
    public class Get : Models.GetWithoutSNRequest<V1.Matrix.PostResult>
    {
        public override string URL => "https://api.map.baidu.com/ros/v2/matrix";

        /// <summary>
        /// 路网ID
        /// </summary>
        [Display(Name= "matrixId")]
        public string MatrixId { get; set; }

        /// <summary>
        /// 路网版本
        /// </summary>
        [Display(Name = "commitId")]
        public string CommitId { get; set; }
    }
}
