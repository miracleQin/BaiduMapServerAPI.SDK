using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.LogisticsRoutematrix.V1
{
    /// <summary>
    /// 物流批量算路
    /// </summary>
    public class Truck : Models.GetRequest<TruckResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/logistics_routematrix/v1/truck";

        /// <summary>
        /// 起点
        /// <para>【步骑行、摩托车】支持传入起点uid提升绑路准确性，格式为：纬度,经度;POI的uid|纬度,经度;POI的uid。</para>
        /// </summary>
        [Display(Name = "origins")]
        [LocationListConverter]
        public List<Models.Location> Origins { get; set; }

        /// <summary>
        /// 终点
        /// <para>【步骑行、摩托车】支持传入起点uid提升绑路准确性，格式为：纬度,经度;POI的uid|纬度,经度;POI的uid。</para>
        /// </summary>
        [Display(Name = "destinations")]
        [LocationListConverter]
        public List<Models.Location> Destinations { get; set; }

        /// <summary>
        /// 坐标类型
        /// <para>可选值为：bd09ll（百度经纬度坐标）、bd09mc（百度墨卡托坐标）、gcj02（国测局加密坐标）、wgs84（gps设备获取的坐标）。</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 车辆高度
        /// <para>单位：米</para>
        /// <para>取值[0,5.0]，默认1.8，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// 车辆宽度
        /// <para>单位：米</para>
        /// <para>取值[0,3.0]，默认1.9，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "width")]
        public double? Width { get; set; }

        /// <summary>
        /// 车辆总重
        /// <para>单位：吨</para>
        /// <para>车辆总重=车辆自身重量+货物重量</para>
        /// <para>取值[0,100]，默认2.5，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// 车辆长度
        /// <para>单位：米</para>
        /// <para>取值[0,20.0]，默认4.2，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "length")]
        public double? Length { get; set; }

        /// <summary>
        /// 轴重
        /// <para>单位：吨</para>
        /// <para>取值[0,50]，默认2，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "axle_weight")]
        public double? AxleWeight { get; set; }

        /// <summary>
        /// 轴数
        /// <para>取值[0,50]，默认2，会按照填写数字进行限行规避字段类型int64</para>
        /// </summary>
        [Display(Name = "axle_count")]
        public int? AxleCount { get; set; }

        /// <summary>
        /// 是否是挂车
        /// </summary>
        [Display(Name = "is_trailer")]
        [BoolToNumConverter]
        public bool? IsTrailer { get; set; }

        /// <summary>
        /// 车牌号省份
        /// <para>默认：空字串</para>
        /// </summary>
        [Display(Name = "plate_province")]
        public string PlateProvince { get; set; }

        /// <summary>
        /// 车牌号（省份以外号码）
        /// <para>默认：空字串</para>
        /// </summary>
        [Display(Name = "plate_number")]
        public string PlateNumber { get; set; }

        /// <summary>
        /// 车牌颜色
        /// </summary>
        [Display(Name = "plate_color")]
        [EnumValue]
        public Models.Enums.PlateColor? PlateColor { get; set; }

        /// <summary>
        /// 出发时间
        /// <para>Unix时间戳(秒)，默认为当前时间，一期支持未来3天内的区间：（now_timestamp - 600, now_timestamp + 3 * 86400）</para>
        /// </summary>
        [Display(Name = "departure_time")]
        [UnixDateTimeConverter]
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// 驾驶策略
        /// </summary>
        [Display(Name = "Tactics")]
        [EnumValue]
        public Tactics? Tactics { get; set; }

        /// <summary>
        /// 货车政策交规（如交通部门发布的分时段区域限行政策）剥离
        /// </summary>
        [Display(Name = "avoid_type")]
        [EnumValue]
        public AvoidType? AvoidType { get; set; }

        /// <summary>
        /// 用户标识
        /// <para>规避自定义区域时的特殊字段</para>
        /// <para>格式：大小写字母、数字、英文逗号、英文分号</para>
        /// </summary>
        [Display(Name = "user_mark")]
        public string UserMark { get; set; }
    }

    /// <summary>
    /// 驾驶策略
    /// </summary>
    public enum Tactics
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Default = 0,

        /// <summary>
        /// 距离优先
        /// </summary>
        [Description("距离优先")]
        ShortDistance = 1,

        /// <summary>
        /// 不走高速
        /// </summary>
        [Description("不走高速")]
        NoHighWay = 3,

        /// <summary>
        /// 少收费
        /// </summary>
        [Description("少收费")]
        LessFee = 6,
    }

    /// <summary>
    /// 货车政策交规
    /// </summary>
    public enum AvoidType
    {

        /// <summary>
        /// 政策交规默认生效
        /// </summary>
        [Description("生效")]
        Enable = 0,

        /// <summary>
        /// 算路时忽略针对货车的政策交规（道路上实体交通标牌限制仍正常生效）
        /// </summary>
        [Description("不生效")]
        Disable = 1,
    }
}
