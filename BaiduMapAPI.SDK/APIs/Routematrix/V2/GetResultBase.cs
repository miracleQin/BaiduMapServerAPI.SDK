using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Routematrix.V2
{
    /// <summary>
    /// 批量算路结果
    /// </summary>
    public class GetResultBase : Models.ResponseOld
    {
        /// <summary>
        /// 返回的结果
        /// <para>数组形式。数组中的每个元素代表一个起点和一个终点的检索结果。</para>
        /// <para>顺序依次为（以2起点2终点为例）：</para>
        /// <para>origin1-destination1</para>
        /// <para>origin1-destination2</para>
        /// <para>origin2-destination1</para>
        /// <para>origin2-destination2</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("result")]
        public List<GetResultBaseResult> Result { get; set; }
    }

    /// <summary>
    /// 结果集
    /// </summary>
    public class GetResultBaseResult
    {

        /// <summary>
        /// 路线距离
        /// <para>文本描述的单位有米、公里两种</para>
        /// <para>数值的单位为米。若没有计算结果，值为0</para>
        /// <para>Text : 线路距离的文本描述</para>
        /// <para>Value : 线路距离的数值</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public Models.TextValue Distance { get; set; }

        /// <summary>
        /// 路线耗时
        /// <para>文本描述的单位有分钟、小时两种</para>
        /// <para>数值的单位为秒。若没有计算结果，值为0</para>
        /// <para>Text : 路线耗时的文本描述</para>
        /// <para>Value : 路线耗时的数值</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("duration")]
        public Models.TextValue Duration { get; set; }

    }

}
