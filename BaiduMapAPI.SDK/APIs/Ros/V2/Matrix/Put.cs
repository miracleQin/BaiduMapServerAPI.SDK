using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V2.Matrix
{
    /// <summary>
    /// 路网新增/减少网点/更新网点坐标
    /// </summary>
    public class Put : Models.JsonPutWithoutSN<V1.Matrix.PostResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v2/matrix";

        /// <summary>
        /// 路网ID
        /// </summary>
        [Display(Name = "matrixId")]
        [QueryParameter("matrixId")]
        [Newtonsoft.Json.JsonIgnore]
        public string MatrixId { get; set; }
        /// <summary>
        /// 网点列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locations")]
        public List<V1.Matrix.PostLocation> Locations { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Type? Type { get; set; }
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        ADD = 0,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        DELETE = 1,
        /// <summary>
        /// 编辑
        /// </summary>
        [Description("编辑")]
        UPDATE = 2,
    }
}
