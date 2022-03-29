using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.ReverseGeocoding.V3
{
    /// <summary>
    /// 
    /// </summary>
    public class GetResultPoi
    {
        /// <summary>
        /// 地址信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("addr")]
        public string Address { get; set; }

        /// <summary>
        /// 数据来源（已废弃）
        /// </summary>
        [Newtonsoft.Json.JsonProperty("cp")]
        public string CP { get; set; }

        /// <summary>
        /// 和当前坐标点的方向
        /// </summary>
        [Newtonsoft.Json.JsonProperty("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// 离坐标点距离
        /// </summary>
        [Newtonsoft.Json.JsonProperty("distance")]
        public int? Distance { get; set; }

        /// <summary>
        /// poi名称
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// poi类型
        /// <para>如’美食;中餐厅’。tag与poiType字段均为poi类型，建议使用tag字段，信息更详细。</para>
        /// <para>poi详细类别: http://lbsyun.baidu.com/index.php?title=lbscloud/poitags </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// poi坐标{x,y}
        /// </summary>
        [Newtonsoft.Json.JsonProperty("point")]
        public Models.Point Point { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tel")]
        public string Telephone { get; set; }

        /// <summary>
        /// poi唯一标识
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid")]
        public string UID { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [Newtonsoft.Json.JsonProperty("zip")]
        public string ZIP { get; set; }

        /// <summary>
        /// poi对应的主点poi
        /// <para>海底捞的主点为上地华联，该字段则为上地华联的poi信息。如无，该字段为空</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("parent_poi")]
        public GetResultPoi ParentPoi { get; set; }

        /// <summary>
        /// 是否有父级信息
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public bool HasParentInfo { get { return ParentPoi != null ? !string.IsNullOrEmpty(ParentPoi.UID) : false; } }
    }
}
