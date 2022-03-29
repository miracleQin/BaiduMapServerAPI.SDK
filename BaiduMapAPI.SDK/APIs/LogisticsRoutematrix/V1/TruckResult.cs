using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.LogisticsRoutematrix.V1
{
    /// <summary>
    /// 物流批量算路结果
    /// </summary>
    public class TruckResult : Models.ResponseOld
    {
        /// <summary>
        /// 返回的结果
        /// <para>数组中的每个元素代表一个起点和一个终点的检索结果。</para>
        /// <para>（以2起点2终点为例）：</para>
        /// <para>origin1-destination1,</para>
        /// <para>origin1-destination2,</para>
        /// <para>origin2-destination1,</para>
        /// <para>origin2-destination2</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public List<TruckResultResult> Result { get; set; }
    }

    /// <summary>
    /// 算路结果
    /// </summary>
    public class TruckResultResult
    {
        /// <summary>
        /// 车牌限行
        /// </summary>
        [Newtonsoft.Json.JsonProperty("restriction")]
        public Restriction Restriction { get; set; }

        /// <summary>
        /// 路线距离
        /// <para>文本描述的单位有米、公里两种</para>
        /// <para>单位为米。如果值为0：算路请求正常，但两点间无路线如果值为-1：算路请求异常，可以重试一次</para>
        /// <para>Text : 线路距离的文本描述</para>
        /// <para>Value : 线路距离的数值</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public Models.TextValue Distance { get; set; }

        /// <summary>
        /// 路线耗时
        /// <para>文本描述的单位有分钟、小时两种</para>
        /// <para>单位为秒 如果值为0：算路请求正常，但两点间无路线 如果值为-1：算路请求异常，可以重试一次</para>
        /// <para>Text : 路线耗时的文本描述</para>
        /// <para>Value : 路线耗时的数值</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public Models.TextValue Duration { get; set; }
    }

    /// <summary>
    /// 车牌限行信息
    /// </summary>
    public class Restriction
    {
        /// <summary>
        /// 限制类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public Models.Enums.RestrictionType? Type { get; set; }


        /// <summary>
        /// 限制详情
        /// </summary>
        [Newtonsoft.Json.JsonProperty("info")]
        public string Info { get; set; }
    }

}
