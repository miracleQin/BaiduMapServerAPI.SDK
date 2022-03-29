using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Geocoding.V3
{
    /// <summary>
    /// 地理编码
    /// </summary>
    public class GetResult : Models.ResponseOld
    {
        /// <summary>
        /// 地理编码结果
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public GetResultResult Result { get; set; }
    }

    /// <summary>
    /// 地理编码结果
    /// </summary>
    public class GetResultResult
    {
        /// <summary>
        /// 经纬度坐标
        /// </summary>
        [Newtonsoft.Json.JsonProperty("location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 位置的附加信息，是否精确查找
        /// </summary>
        [Newtonsoft.Json.JsonProperty("precise")]
        public bool? Precise { get; set; }

        /// <summary>
        /// 描述打点绝对精度（即坐标点的误差范围）
        /// <para>confidence=100，解析误差绝对精度小于20m；</para>
        /// <para>confidence≥90，解析误差绝对精度小于50m；</para>
        /// <para>confidence≥80，解析误差绝对精度小于100m；</para>
        /// <para>confidence≥75，解析误差绝对精度小于200m；</para>
        /// <para>confidence≥70，解析误差绝对精度小于300m；</para>
        /// <para>confidence≥60，解析误差绝对精度小于500m；</para>
        /// <para>confidence≥50，解析误差绝对精度小于1000m；</para>
        /// <para>confidence≥40，解析误差绝对精度小于2000m；</para>
        /// <para>confidence≥30，解析误差绝对精度小于5000m；</para>
        /// <para>confidence≥25，解析误差绝对精度小于8000m；</para>
        /// <para>confidence≥20，解析误差绝对精度小于10000m；</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("confidence")]
        public int? Confidence { get; set; }

        /// <summary>
        /// 描述地址理解程度
        /// <para>分值范围0-100，分值越大，服务对地址理解程度越高（建议以该字段作为解析结果判断标准）</para>
        /// <para>当comprehension值为以下值时，对应的准确率如下：</para>
        /// <para>comprehension=100，解析误差100m内概率为91%，误差500m内概率为96%；</para>
        /// <para>comprehension≥90，解析误差100m内概率为89%，误差500m内概率为96%；</para>
        /// <para>comprehension≥80，解析误差100m内概率为88%，误差500m内概率为95%；</para>
        /// <para>comprehension≥70，解析误差100m内概率为84%，误差500m内概率为93%；</para>
        /// <para>comprehension≥60，解析误差100m内概率为81%，误差500m内概率为91%；</para>
        /// <para>comprehension≥50，解析误差100m内概率为79%，误差500m内概率为90%；</para>
        /// <para>解析误差：地理编码服务解析地址得到的坐标位置，与地址对应的真实位置间的距离。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("comprehension")]
        public int? Comprehension { get; set; }

        /// <summary>
        /// 描述打点绝对精度（即坐标点的误差范围）
        /// <para>包含：UNKNOWN、国家、省、城市、区县、乡镇、村庄、道路、地产小区、商务大厦、政府机构、交叉路口、商圈、生活服务、休闲娱乐、餐饮、宾馆、购物、金融、教育、医疗 、工业园区 、旅游景点 、汽车服务、火车站、长途汽车站、桥 、停车场/停车区、港口/码头、收费区/收费站、飞机场 、机场 、收费处/收费站 、加油站、绿地、门址</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("level")]
        public string Level { get; set; }
    }
}
