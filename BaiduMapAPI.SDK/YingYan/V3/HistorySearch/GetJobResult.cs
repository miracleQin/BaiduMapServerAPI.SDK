using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.HistorySearch
{
    /// <summary>
    /// 查询搜索 结果
    /// <para>导出文件说明：<br/>
    /// 1. 导出文件名为格式为：{service_id}_{job_id}.zip（例如：135252_10.zip）<br/>
    /// 2. 使用zip解压工具解压可以得到文件：{service_id}_{job_id}.txt（例：135252_10.txt）<br/>
    /// 3. 文件中每行文本代表一个entity name
    /// </para>
    /// </summary>
    public class GetJobResult : Models.ResponseOld
    {
        /// <summary>
        /// 总结果数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 任务
        /// <para>若对应任务状态为 done 的，可调用 GetResultAsync()/GetResult() 函数获取任务中的坐标信息</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("jobs")]
        public List<Job> Jobs { get; set; }
    }

    /// <summary>
    /// 任务信息
    /// </summary>
    public class Job : Models.DonwloadZipFile<Export.EntityTraceInfo>
    {
        /// <summary>
        /// 任务id
        /// </summary>
        [Newtonsoft.Json.JsonProperty("job_id")]
        public int? JobID { get; set; }

        /// <summary>
        /// 轨迹起始时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 轨迹结束时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 圆形检索参数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("around")]
        public AroundResult Around { get; set; }

        /// <summary>
        /// 矩形检索参数
        /// </summary>
        [Newtonsoft.Json.JsonProperty("bounds")]
        public BoundResult Bounds { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// <para>返回值的坐标类型。可能返回的值为：<br/>
        /// gcj02：国测局加密坐标<br/>
        /// bd09ll：百度经纬度坐标
        /// </para>
        /// <para>该参数仅对国内（包含港、澳、台）轨迹有效，海外区域轨迹均返回 wgs84坐标</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type_output")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }

        /// <summary>
        /// 任务创建的格式化时间
        /// <para>该时间为服务端时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("create_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.DatetimeNumberConverter))]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 任务创建的格式化时间
        /// <para>该时间为服务端时间</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("modify_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Models.JsonConverter.DatetimeNumberConverter))]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 任务当前的执行状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("job_status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Export.JobStatus? JobStatus { get; set; }

        /// <summary>
        /// 轨迹数据文件下载链接
        /// <para>数据准备好后（即：job_status为 done 时），将会生成轨迹数据文件下载链接，开发者可通过该链接下载数据文件。</para>
        /// <para>注：已完成的任务会在48小时之后自动清理，请及时下载。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("file_url")]
        public string FileUrl { get; set; }

        /// <summary>
        /// 问价下载地址
        /// </summary>
        public override string URL => this.FileUrl;

        /// <summary>
        /// 判断当前是否可以下载
        /// </summary>
        /// <returns></returns>
        protected override bool CanGetResult()
        {
            return JobStatus == Export.JobStatus.done && this.FileUrl.StartsWith("http", StringComparison.CurrentCultureIgnoreCase);
        }
    }

    /// <summary>
    /// 圆搜索结果
    /// </summary>
    public class AroundResult
    {
        /// <summary>
        /// 圆心坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("center")]
        public Models.Location Center { get; set; }

        /// <summary>
        /// 半径
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public int? Radius { get; set; }
    }

    /// <summary>
    /// 矩形检索信息
    /// </summary>
    public class BoundResult
    {
        /// <summary>
        /// 左下角坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ll")]
        public Models.LocationDetail LeftBottom { get; set; }

        /// <summary>
        /// 右上角坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rt")]
        public Models.LocationDetail RightTop { get; set; }
    }
}
