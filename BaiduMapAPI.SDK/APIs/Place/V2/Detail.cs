using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点详情检索服务
    /// </summary>
    public class Detail : Models.GetRequest<DetailResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/place/v2/detail";
        /// <summary>
        /// 地点详情检索服务
        /// </summary>
        public Detail() 
        {
            this.Timestamp = DateTime.Now;
            this.Output = "json";
        }

        /// <summary>
        /// poi的uid
        /// </summary>
        [Display(Name = "uid")]
        public string UID { get; set; }

        /// <summary>
        /// uid的集合
        /// <para>最多可以传入10个uid，多个uid之间用英文逗号分隔</para>
        /// </summary>
        [Display(Name ="uids")]
        [Models.Attributes.ListConverter]
        public List<string> UIDs { get; set; }


        /// <summary>
        /// 可选参数，添加后POI返回国测局经纬度坐标
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        [Models.Attributes.EnumName]
        public Models.Enums.CoordType? RetCoordType { get; set; }

        /// <summary>
        /// 是否召回国标行政区划编码
        /// </summary>
        [Display(Name = "extensions_adcode")]
        public bool? ExtensionsAdcode { get; set; }

        /// <summary>
        /// 检索结果详细程度
        /// <para>取值为1 或空，则返回基本信息；取值为2，返回检索POI详细信息</para>
        /// </summary>
        [Display(Name = "scope")]
        [Models.Attributes.EnumValue]
        public Models.Enums.Scope? Scope { get; set; }

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


    }
}
