using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 驾车路线规划
    /// </summary>
    public class Driving : Models.GetRequest<DrivingResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/direction/v2/driving";

        /// <summary>
        /// 起点
        /// </summary>
        [Display(Name = "origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 起点
        /// </summary>
        [Display(Name = "destination")]
        public Models.Location Destination { get; set; }


        /// <summary>
        /// 起点POI的uid
        /// <para>请尽量填写uid，将提升路线规划的准确性。</para>
        /// <para>使用地点检索服务获取uid ， 使用地点输入提示服务获取uid </para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/guide/webservice-placeapi</para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/place-suggestion-api</para>
        /// </summary>
        [Display(Name = "origin_uid")]
        public string OriginUID { get; set; }

        /// <summary>
        /// 终点POI的uid
        /// <para>请尽量填写uid，将提升路线规划的准确性。</para>
        /// <para>使用地点检索服务获取uid ， 使用地点输入提示服务获取uid </para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/guide/webservice-placeapi</para>
        /// <para>http://lbs.baidu.com/index.php?title=webapi/place-suggestion-api</para>
        /// </summary>
        [Display(Name = "destination_uid")]
        public string DestinationUID { get; set; }

        /// <summary>
        /// 途径点坐标串
        /// <para>支持18个以内的有序途径点。 多个途径点坐标按顺序以英文竖线符号分隔</para>
        /// <para>示例: 40.465,116.314|40.232,116.352|40. 121,116.453</para>
        /// </summary>
        [Display(Name = "waypoints")]
        [LocationListConverter]
        public List<Models.Location> WayPoints { get; set; }

        /// <summary>
        /// 起终点的坐标类型
        /// <para>默认为bd09ll</para>
        /// <para>可选值：bd09ll（百度经纬度坐标）;gcj02（国测局加密坐标）;wgs84（gps 设备获取的坐标）;</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 输出坐标类型
        /// <para>返回值的坐标类型，默认为百度经纬度坐标：bd09ll</para>
        /// <para>可选值： bd09ll：百度经纬度坐标;gcj02：国测局加密坐标</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        [EnumName]
        public Models.Enums.CoordType? RetCoordType { get; set; }

        /// <summary>
        /// 路线偏好
        /// </summary>
        [Display(Name = "tactics")]
        public Models.Enums.DirectionDrivingTactics? Tactics { get; set; }

        /// <summary>
        /// 是否返回备选路线
        /// <para>false : 返回一条推荐路线</para>
        /// <para>true : 返回1~3条路线供选择</para>
        /// </summary>
        [Display(Name = "alternatives")]
        [BoolToNumConverter]
        public bool? AlterNatives { get; set; }

        /// <summary>
        /// 车辆类型
        /// <para>区分车辆是普通燃油车或纯电动汽车。</para>
        /// <para>由于部分城市对燃油车和电动车限行规则有差异，该字段用于结合plate_number车牌号来规避限行。</para>
        /// <para>例如：纯电动汽车在北京本地无尾号限行，而燃油车需遵守尾号限行。</para>
        /// </summary>
        [Display(Name = "cartype")]
        [EnumValue]
        public Models.Enums.CarType? CarType { get; set; }


        /// <summary>
        /// 车牌号
        /// <para>如 京A00022</para>
        /// <para>用于规避车牌号限行路段。</para>
        /// <para>1、若有规避限行区域的可选路线，则返回规避后的路线，不会返回限行路线</para>
        /// <para>2、若无规避限行的可选路线（如：起终点在限行区域内，或所有符合偏好的路线都无法规避限行区域），则返回限行路线中最优路线，并在返回字段 restriction 中提示用户路段被限行</para>
        /// </summary>
        [Display(Name = "plate_number")]
        public string PlateNumber { get; set; }

        /// <summary>
        /// 设置出发时间（支持未来7天）
        /// <para>取值范围：当前时间之后7天*24小时内任意时刻（超出时间范围将预估路线）</para>
        /// <para>若设置该参数，则路线规划服务将依据设定时间预测路况和限行规则，并据此计算路线和耗时</para>
        /// <para>注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <para>http://lbsyun.baidu.com/apiconsole/fankui</para>
        /// </summary>
        [Display(Name = "departure_time")]
        [UnixDateTimeConverter]
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// 更多出发时间
        /// <para>该字段将影响ext_duration字段的返回，用于返回路线在指定出发时间的耗时。目前支持输入过去7天内一个或多个出发时间戳（不超过12个），多个时间戳之间用","英文半角逗号隔开。</para>
        /// <para>示例： ext_departure_time=1526527619 </para>
        /// <para>ext_departure_time=1526527619,1526525384,1526523654</para>
        /// <para>注：目前出发时间仅影响ext_duration字段，还不会影响路线计算和选择。即仍按照现在的路况计算并推荐路线，但将增加返回该路线在其他时间的耗时。</para>
        /// <para>注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <para>http://lbsyun.baidu.com/apiconsole/fankui</para>
        /// </summary>
        [Display(Name = "ext_departure_time")]
        [MultisUnixDateTimeConverter]
        public List<DateTime> ExtDepartureTime { get; set; }

        /// <summary>
        /// 预期的到达时间
        /// <para>该字段将影响suggest_departure_time字段的返回，用于返回建议出发时间。取值范围：当前时间之后15分钟的任意时刻（小于这个时间则不做处理）</para>
        /// <para>若设置此参数，则路线规划服务将依据设定时间计算路线和耗时，并给出建议出发时间</para>
        /// <para>若算出的suggest_departure_time小于当前时间，则设置suggest_departure_time为-1</para>
        /// <para>不填则不返回suggest_departure_time字段</para>
        /// <para>注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// <para>http://lbsyun.baidu.com/apiconsole/fankui</para>
        /// </summary>
        [Display(Name = "expect_arrival_time")]
        [UnixDateTimeConverter]
        public DateTime? ExpectArrivalTime { get; set; }

        /// <summary>
        /// 起点的车头方向
        /// <para>取值范围：0-359</para>
        /// <para>车头方向为与正北方向顺时针夹角，该参数用于辅助判断起点所在正逆向车道，提高算路准确率。</para>
        /// <para>当speed>1.5米/秒且gps_direction存在时，采用该方向。</para>
        /// <para>gps_direction并不代表需填写从gps获取的方向，可以填入校正后的方向。请填写尽量准确的方向，其准确性很大程度决定了计算的精度。</para>
        /// </summary>
        [Display(Name = "gps_direction")]
        public int? GpsDirection { get; set; }

        /// <summary>
        /// 起点的定位精度
        /// <para>取值范围[0,2000]</para>
        /// <para>配合gps_direction字段使用</para>
        /// </summary>
        [Display(Name = "radius")]
        public double? Radius { get; set; }

        /// <summary>
        /// 起点车辆的行驶速度
        /// <para>单位：米/秒</para>
        /// <para>配合gps_direction字段使用，当speed>1.5米/秒且gps_direction存在时，采用gps_direction的方向。</para>
        /// </summary>
        [Display(Name = "speed")]
        public double? Speed{ get; set; }

        /// <summary>
        /// 时间戳，与SN配合使用
        /// <para>SN存在时必填</para>
        /// </summary>
        [Models.Attributes.UnixDateTimeConverter]
        [Display(Name = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// 输出类型
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";
    }
}
