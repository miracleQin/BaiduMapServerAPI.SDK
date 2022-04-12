using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Toll
{
    /// <summary>
    /// 计算货车ETC 结果
    /// </summary>
    public class TruckResult : Models.ResponseOld
    {

        /// <summary>
        /// 总ETC费用
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public double? Toll { get; set; }

        /// <summary>
        /// 收费区间数量
        /// <para>收费区间包括：<br/>
        /// 1. 一段以收费站入口开始和收费站出口结束的高速区间<br/>
        /// 2. 只在入口收费或只在出口收费的高速区间<br/>
        /// 3. 收费的桥梁
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_section_num")]
        public int? TollSectionNumber { get; set; }


        /// <summary>
        /// 分段收费信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_sections")]
        public List<TollSection> TollSections { get; set; }
    }

    /// <summary>
    /// 分段收费信息
    /// </summary>
    public class TollSection
    {
        /// <summary>
        /// 分段收费
        /// <para>单位：元</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public double? Toll { get; set; }

        /// <summary>
        /// 收费类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_type")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TollType? TollType { get; set; }

        /// <summary>
        /// 道路等级
        /// <para>可选值：高速路；都市高速路；国道；省道；县道；乡镇道路；其他道路；九级路；轮渡；</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_grade")]
        public string RoadGrade { get; set; }

        /// <summary>
        /// 道路名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("road_name")]
        public string RoadName { get; set; }

        /// <summary>
        /// 区间起点收费站信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("start_toll_station")]
        public TollStation StartTollStation { get; set; }

        /// <summary>
        /// 区间结束收费站信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("end_toll_station")]
        public TollStation EndTollStation { get; set; }
    }

    /// <summary>
    /// 收费类型
    /// </summary>
    public enum TollType
    {
        /// <summary>
        /// 高速ETC门架费
        /// </summary>
        [Description("高速ETC门架费")]
        TOLL_TYPE_ETC = 0,
        /// <summary>
        /// 过桥费
        /// </summary>
        [Description("过桥费")]
        TOLL_TYPE_BRIDGE = 1,
    }

    /// <summary>
    /// 收费站信息
    /// </summary>
    public class TollStation
    {

        /// <summary>
        /// 收费站坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("coord")]
        public Models.LocationDetail Coord { get; set; }

        /// <summary>
        /// 收费站名称
        /// <para>若有实际收费站，则使用收费站名称。</para>
        /// <para>若无实际收费站，则用收费结束点“行政区名称+道路名称”标识。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
    }

}
