using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 查询某 entity 的实时位置，支持纠偏
    /// </summary>
    public class GetLatestPoint : Models.GetWithoutSNRequest<GetLatestPointResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/track/getlatestpoint";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// entity唯一标识(必填)
        /// <para>标识轨迹点所属的 entity</para>
        /// </summary>
        [Display(Name = "entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// 纠偏选项
        /// </summary>
        [Display(Name = "process_option")]
        [FilterConverter(",", "=")]
        public ProcessOption ProcessOption { get; set; }

        /// <summary>
        /// 返回的坐标类型
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于控制返回结果中的坐标类型。可选值为：<br/>
        /// gcj02：国测局加密坐标<br/>
        /// bd09ll：百度经纬度坐标
        /// </para>
        /// <para>该参数仅对国内（包含港、澳、台）轨迹有效，海外区域轨迹均返回 wgs84坐标系</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }
    }

    /// <summary>
    /// 纠偏选项
    /// </summary>
    public class ProcessOption
    {
        /// <summary>
        /// 去噪
        /// <para>（去噪力度）取值范围[0,5]</para>
        /// <para>数值越大去噪力度越大，代表越多的点会被当做噪点去除。若取值0，则代表不去噪。</para>
        /// </summary>
        [Display(Name = "denoise_grade")]
        [EnumValue]
        public DenoiseGrade? DenoiseGrade { get; set; }

        /// <summary>
        /// 绑路
        /// </summary>
        [Display(Name = "need_mapmatch")]
        [BoolToNumConverter]
        public bool? NeedMapMatch { get; set; }

        /// <summary>
        /// 交通方式
        /// <para>鹰眼将根据不同交通工具选择不同的纠偏策略，目前支持：自动（即鹰眼自动识别的交通方式）、驾车、骑行和步行</para>
        /// </summary>
        [Display(Name = "transport_mode")]
        [EnumName]
        public TransportMode? TransportMode { get; set; }

        /// <summary>
        /// 抽稀
        /// <para>取值范围[0,5]，数值越大抽稀度力度越大，代表轨迹会越稀疏。若取值0，则代表不抽稀。</para>
        /// </summary>
        [Display(Name = "vacuate_grade")]
        [EnumValue]
        public Models.Enums.VacuateGrade? VacuateGrade { get; set; }
    }

    /// <summary>
    /// 去噪力度
    /// </summary>
    public enum DenoiseGrade
    {
        /// <summary>
        /// 不去噪
        /// </summary>
        [Description("不去噪")]
        None = 0,

        /// <summary>
        /// 系统默认去噪1
        /// </summary>
        [Description("系统默认去噪1")]
        Default1 = 1,

        /// <summary>
        /// 系统默认去噪2
        /// <para>同时去除定位精度低于500的轨迹点，相当于保留GPS定位点、大部分Wi-Fi定位点和精度较高的基站定位点</para>
        /// </summary>
        [Description("系统默认去噪2")]
        Default2 = 2,

        /// <summary>
        /// 系统默认去噪2
        /// <para>同时去除定位精度低于100的轨迹点，相当于保留GPS定位点和大部分Wi-Fi定位点</para>
        /// </summary>
        [Description("系统默认去噪3")]
        Default3 = 3,

        /// <summary>
        /// 系统默认去噪2
        /// <para>同时去除定位精度低于50的轨迹点，相当于保留GPS定位点和精度较高的Wi-Fi定位点</para>
        /// </summary>
        [Description("系统默认去噪4")]
        Default4 = 4,

        /// <summary>
        /// 系统默认去噪2
        /// <para>同时去除定位精度低于20的轨迹点，相当于仅保留GPS定位点</para>
        /// </summary>
        [Description("系统默认去噪5")]
        Default5 = 5,
    }

    /// <summary>
    /// 交通方式
    /// </summary>
    public enum TransportMode
    {
        /// <summary>
        /// 根据轨迹鹰眼自动识别交通方式
        /// </summary>
        [Description("根据轨迹鹰眼自动识别交通方式")]
        auto = 0,
        /// <summary>
        /// 驾车
        /// </summary>
        [Description("驾车")]
        driving = 1,
        /// <summary>
        /// 骑行
        /// </summary>
        [Description("骑行")]
        riding = 2,
        /// <summary>
        /// 步行
        /// </summary>
        [Description("步行")]
        walking = 3,
    }
}
