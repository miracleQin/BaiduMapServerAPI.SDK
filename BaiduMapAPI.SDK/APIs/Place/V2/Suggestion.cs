using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 地点输入提示服务
    /// </summary>
    public class Suggestion : Models.GetRequest<SuggestionResult>
    {
        public Suggestion()
        {
            this.Timestamp = DateTime.Now;
            this.Output = "json";
        }
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/place/v2/suggestion";

        /// <summary>
        /// 时间戳
        /// </summary>
        [Display(Name="timestamp")]
        [Models.Attributes.ToTimestamp]
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 返回数据格式，可选json、xml两种
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; private set; }

        /// <summary>
        /// 输入建议关键字（支持拼音）
        /// </summary>
        [Display(Name ="query")]
        public string Query { get; set; }

        /// <summary>
        /// 支持全国、省、城市及对应百度编码
        /// <para>http://wiki.lbsyun.baidu.com/cms/citycode/BaiduMap_cityCode_1102.zip</para>
        /// <para>指定的区域的返回结果加权，可能返回其他城市高权重结果。若要对返回结果区域严格限制，请使用city_limit参数</para>
        /// </summary>
        [Display(Name = "region")]
        
        public string Region { get; set; }

        /// <summary>
        /// 取值为"true"，仅返回region中指定城市检索结果
        /// </summary>
        [Display(Name = "city_limit")]
        public bool? CityLimit { get; set; }

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
    }
}
