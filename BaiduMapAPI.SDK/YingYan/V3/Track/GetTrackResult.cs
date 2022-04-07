using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 一段时间内的轨迹点，支持纠偏 结果
    /// </summary>
    public class GetTrackResult : Models.ResponseOld
    {
        /// <summary>
        /// 符合条件的轨迹点数量
        /// <para>忽略掉page_index，page_size后的轨迹点数量	</para>
        /// <para>代表一共有多少条符合条件的轨迹点</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 返回的结果条数
        /// <para>代表本页返回了多少条符合条件的轨迹点数量</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("size")]
        public int? Size { get; set; }

        /// <summary>
        /// 此段轨迹的里程数
        /// <para>单位：米</para>
        /// <para>符合条件的所有轨迹点的总里程</para>
        /// <para>注意：是total个轨迹点的里程，和分页及本页显示的size无关</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public double? Distance { get; set; }


        /// <summary>
        /// 此段轨迹的收费里程数
        /// <para>单位：米</para>
        /// <para>收费道路包括高速等收费路段</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_distance")]
        public double? TollDistance { get; set; }

        /// <summary>
        /// 低速里程
        /// <para>单位：米</para>
        /// <para>若请求参数中填写了low_speed_threshold，则返回该字段，否则不返回代表速度低于low_speed_threshold的轨迹里程</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("low_speed_distance")]
        public double? LowSpeedDistance { get; set; }

        /// <summary>
        /// 起点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_point")]
        public PointBase StartPoint { get; set; }

        /// <summary>
        /// 终点信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_point")]
        public PointBase EndPoint { get; set; }

        /// <summary>
        /// 历史轨迹点列表
        /// </summary>
        [Newtonsoft.Json.JsonProperty("points")]
        public List<Point> Points { get; set; }
    }


    /// <summary>
    /// 基础坐标点信息
    /// </summary>
    public class PointBase 
    {
        /// <summary>
        /// 纬度(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 经度(必填)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 定位时设备的时间(必填)
        /// <para>输入的loc_time不能大于当前服务端时间10分钟以上，即不支持存未来的轨迹点。</para>
        /// <para>且输入的loc_time不能小于当前服务端时间1年以上，即不支持存1年以前的轨迹点。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("loc_time")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 坐标类型(必填)
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于描述上传的坐标类型。可选值为：</para>
        /// <para>wgs84：GPS 坐标</para>
        /// <para>gcj02：国测局加密坐标</para>
        /// <para>bd09ll：百度经纬度坐标</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord_type_input")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Models.Enums.CoordType? CoordTypeInput { get; set; }
    }

    /// <summary>
    /// 历史轨迹点信息
    /// </summary>
    public class Point : PointBase
    {
        /// <summary>
        /// 方向
        /// <para>范围为[0,359]，0度为正北方向，顺时针</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 高度
        /// <para>只在GPS定位结果时才返回，单位米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// 速度
        /// <para>单位：千米/小时</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("speed")]
        public double? Speed { get; set; }

        /// <summary>
        /// 定位精度
        /// <para>单位：米</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 轨迹对应的定位方式
        /// <para>鹰眼分析得出</para>
        /// <para>仅当请求参数is_processed=1时返回。</para>
        /// <para>可能的返回值：未知；GPS/北斗定位；网络定位；基站定位</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locate_mode")]
        public string LocateMode { get; set; }

        /// <summary>
        /// 轨迹对应的交通方式
        /// <para>鹰眼分析得出</para>
        /// <para>仅当请求参数is_processed=1，且process_option中transport_mode=auto时返回。</para>
        /// <para>可能的返回值：未知；驾车；骑行；步行；停留</para>
        /// <para>注意：该功能为高级付费服务，您可通过申请试用或购买使用该功能</para>
        /// <para><![CDATA[https://lbsyun.baidu.com/apiconsole/quota#/home?jumpService=trace]]></para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("transport_mode")]
        public string TransportMode { get; set; }

        /// <summary>
        /// 楼层
        /// </summary>
        [Newtonsoft.Json.JsonProperty("floor")]
        public string Floor { get; set; }

        /// <summary>
        /// 是否为补充的点
        /// <para>
        /// 若为原始轨迹点位置纠正后的点，则不返回该字段；<br/>
        /// 若该点为鹰眼纠偏绑路时自动补充的道路形状点，则_supplement=1；<br/>
        /// 若该点为通过supplement_mode和supplement_content在长距离中断区间使用路线规划补偿的轨迹点，则_supplement=2；
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("_supplement")]
        public Supplement? Supplement { get; set; }

        /// <summary>
        /// track的自定义字段
        /// <para>此处值的类型须与用户自定义的column的类型一致</para>
        /// <para>随轨迹点上传开发者自定义字段的值</para>
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        public Dictionary<string, Newtonsoft.Json.Linq.JToken> CustomColumnValues { get; set; }
    }

    /// <summary>
    /// 补偿点模式
    /// </summary>
    public enum Supplement 
    {
        /// <summary>
        /// 若该点为鹰眼纠偏绑路时自动补充的道路形状点
        /// </summary>
        [Description("纠偏绑路自动补充点")]
        Mode1=1,

        /// <summary>
        /// 在长距离中断区间使用路线规划补偿的轨迹点
        /// </summary>
        [Description("长距离中断补偿点")]
        Mode2=2,
    }
}
