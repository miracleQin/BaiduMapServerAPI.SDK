using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Export
{
    /// <summary>
    /// 创建任务 结果
    /// </summary>
    public class CreateJobResult : Models.ResponseOld
    {
        /// <summary>
        /// 任务 id
        /// <para>任务id，每个任务的唯一标识</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("job_id")]
        public int? JobID { get; set; }
    }
}
