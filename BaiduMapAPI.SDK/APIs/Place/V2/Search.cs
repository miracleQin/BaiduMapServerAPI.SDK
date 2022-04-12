using BaiduMapAPI.Models;
using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点检索基础请求
    /// </summary>
    public class SearchBase : Models.GetRequest<SearchResult>
    {
        /// <summary>
        /// 地点检索基础请求
        /// </summary>
        public SearchBase()
        {
            this.Output = "json";
            this.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/place/v2/search";

        /// <summary>
        /// 检索关键字。
        /// <para>必填</para>
        /// <para>行政区划区域检索不支持多关键字检索。如果需要按POI分类进行检索，请将分类通过query参数进行设置，如query=美食</para>
        /// </summary>
        [Display(Name = "query"), Required]
        public string Query { get; set; }

        /// <summary>
        /// 检索分类偏好
        /// <para>http://lbsyun.baidu.com/index.php?title=lbscloud/poitags</para>
        /// <para>与q组合进行检索，多个分类以","分隔（POI分类），如果需要严格按分类检索，请通过query参数设置</para>
        /// </summary>
        [Display(Name = "tag")]
        [ListConverter]
        public List<string> Tag { get; set; }

        /// <summary>
        /// 检索过滤条件
        /// </summary>
        [Display(Name = "filter")]
        [FilterConverter]
        public Filter Filter { get; set; }

        /// <summary>
        /// 检索结果详细程度
        /// <para>取值为1 或空，则返回基本信息；取值为2，返回检索POI详细信息</para>
        /// </summary>
        [Display(Name = "scope")]
        [EnumValue]
        public Scope? Scope { get; set; }

        /// <summary>
        /// 返回数据格式，可选json、xml两种
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; private set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [Display(Name = "timestamp")]
        [Models.Attributes.ToTimestamp]
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 是否召回国标行政区划编码
        /// </summary>
        [Display(Name = "extensions_adcode")]
        public bool? ExtensionsAdcode { get; set; }


        /// <summary>
        /// 可选参数，用于标注请求中「location」参数使用的坐标类型
        /// <para>坐标类型：                    </para>
        /// <para>1（WGS84ll即GPS经纬度）       </para>
        /// <para>2（GCJ02ll即国测局经纬度坐标）</para>
        /// <para>3（BD09ll即百度经纬度坐标）   </para>
        /// <para>4（BD09mc即百度米制坐标）</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [Models.Attributes.EnumValue]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 可选参数，添加后POI返回国测局经纬度坐标
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        [Models.Attributes.EnumName]
        public Models.Enums.CoordType? RetCoordType { get; set; }

        /// <summary>
        /// 单次召回POI数量
        /// <para>默认为10条记录，最大返回20条。多关键字检索时，返回的记录数为关键字个数*page_size</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 分页页码
        /// <para>默认为0,0代表第一页，1代表第二页，以此类推。常与page_size搭配使用，仅当返回结果为poi时可以翻页。</para>
        /// </summary>
        [Display(Name = "page_num")]
        public int? PageNum { get; set; }

    }
}
