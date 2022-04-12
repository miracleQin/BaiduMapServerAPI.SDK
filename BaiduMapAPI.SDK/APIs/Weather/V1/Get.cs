using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.Weather.V1
{
    /// <summary>
    /// 国内经纬度天气查询
    /// <para>注意：如果district_id和location同时传，默认以district_id为准；下列返回结果参数中，字段类型为高级字段的，仅在开通高级权限之后才会展示，否则不展示。</para>
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/weather/v1/";

        /// <summary>
        /// 区县的行政区划编码
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
        public WeatherDataType? DataType { get; set; }

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

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        public override async Task<GetResult> GetResultAsync(string AK, string SK)
        {
            if (!string.IsNullOrEmpty(LocationName) && Location != null)
                LocationName = null;
            return await base.GetResultAsync(AK, SK);
        }
    }

    /// <summary>
    /// 天气请求数据类型
    /// </summary>
    public enum WeatherDataType
    {
        /// <summary>
        /// 实况数据
        /// </summary>
        [Description("实况数据")]
        now = 0,

        /// <summary>
        /// 预报数据
        /// </summary>
        [Description("预报数据")]
        fc = 1,

        /// <summary>
        /// 生活指数数据
        /// </summary>
        [Description("生活指数数据")]
        index = 2,

        /// <summary>
        /// 气象预警数据
        /// </summary>
        [Description("气象预警数据")]
        alert = 3,

        /// <summary>
        /// 未来24小时预报数据
        /// </summary>
        [Description("未来24小时预报数据")]
        fc_hour = 4,

        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        all = 5
    }


}
