using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Export
{
    /// <summary>
    /// 查询任务 结果
    /// <para>导出文件说明<br/>
    /// 1. 导出文件名为格式为：{service_id}_{job_id}.zip（例如：135252_10.zip）<br/>
    /// 2. 使用zip解压工具解压可以得到文件：{service_id}_{job_id}.json（例：135252_10.json）<br/>
    /// 3. 文件中每行文本代表一条轨迹数据，json格式，其中：<br/>
    /// - entity_name是entiy的唯一标识，字符串类型；entity_id是鹰眼内部使用的id，可以忽略<br/>
    /// - 速度、方向、自定义字段等都存放在custom_data结构中，value统一是字符串类型<br/>
    /// - coord_type是坐标类型字段，分为3种：COORD_TYPE_WGS84LL（GPS经纬度）、COORD_TYPE_GCJ02LL（国测局经纬度）、COORD_TYPE_BD09LL（百度加密经纬度）<br/>
    /// </para>
    /// </summary>
    public class GetJobResult : Models.ResponseOld
    {
        /// <summary>
        /// 任务总条数
        /// <para>当前service_id下的任务总数</para>
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
    /// 导出轨迹任务信息
    /// </summary>
    public class Job : Models.DonwloadZipFile<EntityTraceInfo>
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
        public JobStatus? JobStatus { get; set; }

        /// <summary>
        /// 轨迹数据文件下载链接
        /// <para>数据准备好后（即：job_status为 done 时），将会生成轨迹数据文件下载链接，开发者可通过该链接下载数据文件。</para>
        /// <para>注：已完成的任务会在48小时之后自动清理，请及时下载。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("file_url")]
        public string FileUrl { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        public override string URL => this.FileUrl;

        /// <summary>
        /// 判断当前是否能获取结果
        /// </summary>
        /// <returns></returns>
        protected override bool CanGetResult() => this.JobStatus == Export.JobStatus.done;
    }

    /// <summary>
    /// 任务状态
    /// </summary>
    public enum JobStatus
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        waiting = 0,

        /// <summary>
        /// 正在准备数据
        /// </summary>
        [Description("正在准备数据")]
        running = 1,

        /// <summary>
        /// 数据已准备完成
        /// <para>已生成可供下载的数据文件</para>
        /// </summary>
        [Description("数据已准备完成")]
        done = 2,
    }

    /// <summary>
    /// 坐标信息
    /// </summary>
    public class Point : Models.LocationDetail
    {
        /// <summary>
        /// 坐标类型
        /// <para>
        /// 分为3种：<br/>
        /// COORD_TYPE_WGS84LL（GPS经纬度）<br/>
        /// COORD_TYPE_GCJ02LL（国测局经纬度）<br/>
        /// COORD_TYPE_BD09LL（百度加密经纬度）<br/>
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.CoordType? CoordType { get; set; }
    }

    /// <summary>
    /// 实体轨迹点信息
    /// <para>轨迹数据是乱序的，同一个entity的轨迹数据需要按loc_time字段排序后使用</para>
    /// </summary>
    public class EntityTraceInfo : Models.Response
    {
        /// <summary>
        /// 实体ID
        /// <para>entity_id是鹰眼内部使用的id，可以忽略</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entity_id")]
        public int? EntityID { get; set; }

        /// <summary>
        /// 实体名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// 坐标信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc")]
        public Point Location { get; set; }

        /// <summary>
        /// 定位时间
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 自定义数据
        /// <para>速度、方向、自定义字段等都存放在custom_data结构中，value统一是字符串类型</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("custom_data")]
        public Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomData { get; set; }
    }
}
