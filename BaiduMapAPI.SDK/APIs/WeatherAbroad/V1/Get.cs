using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.WeatherAbroad.V1
{
    /// <summary>
    /// 海外经纬度天气查询
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        public override string URL => "https://api.map.baidu.com/weather_abroad/v1/";

        /// <summary>
        /// 行政区划编码
        /// <para>https://mapopen-website-wiki.cdn.bcebos.com/cityList/weather_district_id.csv</para>
        /// <para>和location二选一</para>
        /// </summary>
        [Display(Name = "district_id")]
        public string DistrictID { get; set; }

        /// <summary>
        /// 经纬度
        /// <para>经度在前纬度在后，逗号分隔</para>
        /// <para>开通高级权限后才能使用</para>
        /// </summary>
        [Display(Name = "location")]
        public Models.Location Location { get; set; }


        /// <summary>
        /// 地址名称
        /// <para>与 Location 只能二选一，若两个都填了，则默认取 Location 的值</para>
        /// </summary>
        [Display(Name = "location")]
        public string LocationName { get; set; }

        /// <summary>
        /// 请求数据类型(必填)
        /// </summary>
        [Display(Name = "data_type")]
        [EnumName]
        public Weather.V1.WeatherDataType? DataType { get; set; }

        /// <summary>
        /// 返回格式
        /// <para>目前支持json/xml</para>
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";

        /// <summary>
        /// 坐标类型
        /// </summary>
        [Display(Name = "coordtype")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        public override async Task<GetResult> GetResultAsync(string AK, string SK)
        {
            if (!string.IsNullOrEmpty(LocationName) && Location != null)
                LocationName = null;
            return await base.GetResultAsync(AK, SK);
        }
    }
}
