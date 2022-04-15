using BaiduMapAPI.Models.JsonConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询某监控对象的围栏报警信息 结果
    /// </summary>
    public class HistoryAlarmResult : Models.ResponseOld
    {
        /// <summary>
        /// 返回结果的数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// 报警的数量
        /// </summary>
        [Newtonsoft.Json.JsonProperty("alarms")]
        public List<AlarmInfo> Alarms { get; set; }
    }

    /// <summary>
    /// 报警信息
    /// </summary>
    public class AlarmInfo
    {
        /// <summary>
        /// 围栏唯一标识
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_id")]
        public int? FenceID { get; set; }

        /// <summary>
        /// 围栏名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fence_name")]
        public string FenceName { get; set; }

        /// <summary>
        /// 围栏的监控对象
        /// <para>1. 该围栏仅监控一个entity时，返回entity_name<br/>
        /// 2. 该围栏监控service下的所有entity时，返回#allentity<br/>
        /// 3. 该围栏监控service下的部分entity时，返回#partofentity</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 触发动作
        /// </summary>
        [Newtonsoft.Json.JsonProperty("action")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Action? Action { get; set; }

        /// <summary>
        /// 触发围栏报警轨迹点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("alarm_point")]
        public PointInfo AlarmPoint { get; set; }

        /// <summary>
        /// 触发围栏报警轨迹点的上一个轨迹点
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pre_point")]
        public PointInfo PrePoint { get; set; }
    }

    /// <summary>
    /// 动作类型
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// 进入围栏
        /// </summary>
        [Description("进入围栏")]
        enter = 0,
        /// <summary>
        /// 离开围栏
        /// </summary>
        [Description("离开围栏")]
        exit = 1,
    }

    /// <summary>
    /// 报警点信息
    /// </summary>
    public class PointInfo : Models.LocationDetail
    {
        /// <summary>
        /// 定位精度
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public int? Radius { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// <para>仅在国外区域返回该字段，返回值为：wgs84</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type")]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 围栏实际触发时间
        /// <para>即触发围栏报警的轨迹点的定位时间</para>
        /// <para>即使触发围栏的轨迹点未实时上传，由于轨迹点中携带了 loc_time，鹰眼仍能根据 loc_time判断围栏实际触发时间。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeNoUTCConverter))]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 服务端接收到报警信息的时间
        /// <para>由于鹰眼 API 围栏为服务端围栏，即只有当轨迹点上传鹰眼服务端时，才能进行围栏触发判断。因此服务端接收到报警的时间可能由于轨迹点上传的不及时性，而晚于围栏实际触发时间 loc_time。例如，轨迹点实际触发围栏时间为13:00，但若由于各种原因，轨迹点上传至服务端进行围栏计算的时间为14:00，则该报警的 create_time为14:00。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("create_time")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeNoUTCConverter))]
        public DateTime? CreateTime { get; set; }


    }
}
