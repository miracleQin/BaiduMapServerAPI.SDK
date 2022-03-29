using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 响应信息
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 原始数据
        /// </summary>
        public string OriginData { get; set; }
    }

    /// <summary>
    /// 老接口响应实体主结构
    /// </summary>
    public class ResponseOld : Response
    {
        /// <summary>
        /// 状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 状态码对应的信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("msg")]
        public string ErrMsg { get; set; }
    }

    /// <summary>
    /// 新接口响应实体结构
    /// </summary>
    public class ResponseNew : Response 
    {
        /// <summary>
        /// 响应状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Enums.ResponseStatus Status { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        [Newtonsoft.Json.JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
