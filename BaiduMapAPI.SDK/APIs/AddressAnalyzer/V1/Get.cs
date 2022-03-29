using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.AddressAnalyzer.V1
{
    /// <summary>
    /// 地址解析聚合
    /// <para>该功能为高级付费服务，用户不能直接在官网付费入口中直接购买，如有采买需求，请提交工单联系我们，将有商务与您取得联系。</para>
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/address_analyzer/v1";

        /// <summary>
        /// 需要解析的地址文本
        /// </summary>
        [Display(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 需聚合的POI分类
        /// <para>小区、写字楼、all</para>
        /// <para>默认值：住宅区|园区|政府机构|高等院校|购物中心等大型聚居区</para>
        /// <para>仅针对POI,"|"分隔。当设置为"all"时，聚合目标为全量 poi</para>
        /// </summary>
        [Display(Name = "output_tag")]
        [Models.Attributes.ListConverter("|")]
        public List<string> OutputTag { get; set; }


        /// <summary>
        /// 聚合AOI单位外扩范围
        /// <para>(0-1000m)</para>
        /// <para>若地址在AOI外扩范围内，同样会聚合到该AOI对应的POI上</para>
        /// </summary>
        [Display(Name = "aoi_radius")]
        public int? AoiRadius { get; set; }

        /// <summary>
        /// POI聚合精度
        /// <para>取值范围“0-100”，数值越大，精度越高(但召回会降低)</para>
        /// <para>该字段取值较高时，仅在服务认为聚合精度较高的前提下，才会召回POI字段数据</para>
        /// </summary>
        [Display(Name = "poi_score")]
        public int? PoiScore { get; set; }

        /// <summary>
        /// 对应召回字段中的confidence
        /// <para>取值100-0。该字段用于触发补充解析策略，对置信度在配置值以下的结果，进行补充解析，以提高结果精度</para>
        /// <para>该字段配置会增加服务耗时。经评测，在保证准确率提升效果的前提下，取值=50，服务平响增长相对较小。也可根据业务数据评测，决定取值。</para>
        /// </summary>
        [Display(Name = "confidence")]
        public int? Confidence { get; set; }

        /// <summary>
        /// 是否使用标准化模式
        /// <para>1（使用）</para>
        /// </summary>
        [Display(Name ="model")]
        [Models.Attributes.BoolToNumConverter]
        public bool? Model { get; set; }

        /// <summary>
        /// 召回坐标的类型
        /// <para>bd09ll(百度经纬度坐标系); bd09mc(百度墨卡托米制坐标);</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        public Models.Enums.CoordType RetCoordType { get; set; }

        /// <summary>
        /// 是否触发异常地址识别功能
        /// <para>注意：该功能为高级付费服务，用户不能直接在官网付费入口中直接购买，如有采买需求，请提交工单联系我们，将有商务与您取得联系。</para>
        /// </summary>
        [Display(Name = "addr_verify")]
        [Models.Attributes.BoolToNumConverter]
        public bool? AddressVerify { get; set; }
    }
}
