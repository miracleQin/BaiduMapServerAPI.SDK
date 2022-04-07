using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 批量上传多个 entity 的多个轨迹点 结果
    /// </summary>
    public class AddPointsResult : Models.ResponseOld
    {
        /// <summary>
        /// 上传成功的点个数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("success_num")]
        public int? SuccessNumber { get; set; }

        /// <summary>
        /// 上传失败的点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fail_info")]
        public FialInfo FialInfo { get; set; }
    }

    /// <summary>
    /// 失败信息
    /// </summary>
    public class FialInfo
    {
        /// <summary>
        /// 输入参数不正确导致的上传失败的点
        /// <para>上传的point_list中，参数不符合规范的点，以及该点的错误信息（在"error"字段中返回）</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("param_error")]
        public List<ParameterError> ParameterErrors { get; set; }


        /// <summary>
        /// 服务器内部错误导致上传失败的点
        /// <para>鹰眼服务端内部失败导致的上传失败的点</para>
        /// <para>该类在百度文档上尚未有字段说明，顾暂时用动态类型代替</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("internal_error")]
        public List<dynamic> InternalErrors { get; set; }
    }

    /// <summary>
    /// 提交参数错误信息
    /// </summary>
    public class ParameterError : PointInfo
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("error")]
        public string Error { get; set; }
    }
}
