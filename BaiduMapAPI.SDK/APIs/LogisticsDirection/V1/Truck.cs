using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.LogisticsDirection.V1
{
    /// <summary>
    /// 货车路线规划
    /// </summary>
    public class Truck : Models.GetRequest<TruckResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/logistics_direction/v1/truck";


        /// <summary>
        /// 起点坐标
        /// <para>格式为：纬度,经度</para>
        /// <para>如：21.22345,112.11478</para>
        /// </summary>
        [Display(Name = "origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 起点坐标
        /// <para>格式为：纬度,经度</para>
        /// <para>如：21.22345,112.11478</para>
        /// </summary>
        [Display(Name = "destination")]
        public Models.Location Destination { get; set; }

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
        /// 车辆高度
        /// <para>单位：米，取值[0,5.0]，默认1.8，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// 车辆宽度
        /// <para>单位：米，取值[0,5.0]，默认1.8，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "Width")]
        public double? Width { get; set; }

        /// <summary>
        /// 车辆总重
        /// <para>车辆总重=车辆自身重量+货物重量</para>
        /// <para>车辆总重=车辆自身重量+货物重量</para>
        /// </summary>
        [Display(Name = "weight")]
        public double? Weight { get; set; }


        /// <summary>
        /// 车辆长度
        /// <para>单位：米，取值[0,20.0]，默认4.2，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "length")]
        public double? Length { get; set; }


        /// <summary>
        /// 轴重
        /// <para>单位：吨，取值[0,50]，默认2，会按照填写数字进行限行规避</para>
        /// </summary>
        [Display(Name = "axle_weight")]
        public double? AxleWeight { get; set; }

        /// <summary>
        /// 轴数
        /// <para>取值[0,50]，默认2，会按照填写数字进行限行规避</para>
        /// <para></para>
        /// </summary>
        [Display(Name = "axle_count")]
        public int? AXLECount { get; set; }

        /// <summary>
        /// 是否是挂车
        /// </summary>
        [Display(Name = "is_trailer")]
        [BoolToNumConverter]
        public bool? ISTrailer { get; set; }


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
        public string PlateMumber { get; set; }

        /// <summary>
        /// 车牌颜色
        /// </summary>
        [Display(Name = "plate_color")]
        [EnumValue]
        public Models.Enums.PlateColor? PlateColor { get; set; }

        /// <summary>
        /// 出发时间
        /// <para>Unix时间戳(秒)，默认为当前时间，支持未来7天内的区间:（now_timestamp - 600, now_timestamp + 7 * 86400）</para>
        /// </summary>
        [Display(Name = "departure_time")]
        [UnixDateTimeConverter]
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// ETA时间戳
        /// <para>未来时间戳：返回未来(历史) ETA （now_timestamp - 600, now_timestamp + 7 * 86400） 其他时间返回参数错误</para>
        /// <para>注：根据departure_time算路，只是返回的duration按次字段规定填充</para>
        /// </summary>
        [Display(Name = "eta_timestamp")]
        [EnumValue]
        public Models.Enums.EtaTimestamp? ETATimestamp { get; set; }

        /// <summary>
        /// 驾驶策略
        /// </summary>
        [Display(Name = "tactics")]
        [EnumValue]
        public Models.Enums.LogisticsDirectionTruckTactics? Tactics { get; set; }


        /// <summary>
        /// 途经点算路时各分段算路偏好
        /// <para>各偏好间以逗号分隔，枚举值参考tactics字段说明，且个数为 途经点个数+1</para>
        /// <para>如有1个途经点，则需传递2个偏好对应 起点→途经点； 途经点→终点 分段的偏好</para>
        /// </summary>
        [Display(Name = "way_tactics")]
        [EnumListConverter(EnumListConverterAttribute.GetValueMethod.FieldValue)]
        public List<Models.Enums.LogisticsDirectionTruckTactics> WayTactics { get; set; }

        /// <summary>
        /// 是否返回备选路线
        /// <para>false：返回一条推荐路线 （默认）</para>
        /// <para>true：返回1到3条备选路线</para>
        /// </summary>
        [Display(Name = "alternatives")]
        [BoolToNumConverter]
        public bool? AlterNatives { get; set; }

        /// <summary>
        /// 用户标识
        /// <para>规避自定义区域时的特殊字段</para>
        /// <para>格式：大小写字母、数字、英文逗号、英文分号</para>
        /// </summary>
        [Display(Name = "user_mark")]
        public string UserMark { get; set; }

        /// <summary>
        /// 百公里油耗
        /// <para>单位:mL</para>
        /// </summary>
        [Display(Name = "displacement")]
        public int? Displacement { get; set; }

        /// <summary>
        /// 动力类型
        /// <para>默认汽油</para>
        /// </summary>
        [Display(Name = "动力类型")]
        [EnumValue]
        public Models.Enums.PowerType? PowerType { get; set; }

        /// <summary>
        /// 卡车类型
        /// </summary>
        [Display(Name = "truck_type")]
        [EnumValue]
        public Models.Enums.TruckType? TruckType { get; set; }

        /// <summary>
        /// 排放标准
        /// <para>取值范围1-6，对应国1-国6标准</para>
        /// </summary>
        [Display(Name = "emission_limit")]
        public int? EmissionLimit { get; set; }

        /// <summary>
        /// 核定载重
        /// <para>单位:吨</para>
        /// <para>取值范围：[0,1000]</para>
        /// </summary>
        [Display(Name = "load_weight")]
        public int? LoadWeight { get; set; }

        /// <summary>
        /// 禁用性能模式
        /// <para>在性能模式下，服务耗时会明显缩减，但路线不会考虑当天上线的新交规数据</para>
        /// </summary>
        [Display(Name = "multi")]
        [BoolToNumConverter]
        public bool? DisableMulti { get; set; }

        /// <summary>
        /// 货车政策交规
        /// <para>如交通部门发布的分时段区域限行政策</para>
        /// </summary>
        [Display(Name = "avoid_type")]
        [EnumValue]
        public Models.Enums.AvoidType AvoidType { get; set; }

        /// <summary>
        /// 用户指定经验轨迹
        /// <para>如无时间戳可设置为0，所有轨迹点个数 小于2000。坐标类型受参数coord_type约定</para>
        /// <para>注意：该功能为高级付费服务，需通过反馈平台联系工作人员开通</para>
        /// </summary>
        [Display(Name = "experience_track")]
        public List<TruckExperienceTrack> ExperienceTrack { get; set; }

        public override Task<TruckResult> GetResultAsync(string AK, string SK)
        {
            if (ExperienceTrack == null || ExperienceTrack.Count == 0)
                return base.GetResultAsync(AK, SK);
            else
                return this.PostFormAsync(AK, SK);//实现表单模式提交
        }
    }

    public class TruckExperienceTrack
    {
        /// <summary>
        /// 坐标点
        /// </summary>
        public Models.Location Location { get; set; }

        /// <summary>
        /// 经过时间
        /// </summary>
        public DateTime? Datetime { get; set; }

        public override string ToString()
        {
            return $"{Location.Lat},{Location.Lng},{(Datetime.HasValue ? Datetime.ToTimestamp() : "0")}";
        }
    }
}
