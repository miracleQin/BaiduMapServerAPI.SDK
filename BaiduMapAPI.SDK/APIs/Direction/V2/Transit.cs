using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Direction.V2
{
    /// <summary>
    /// 公交规划
    /// </summary>
    public class Transit : Models.GetRequest<TransitResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/direction/v2/transit";

        /// <summary>
        /// 起点经纬度
        /// <para>格式为：纬度,经度</para>
        /// <para>小数点后不超过6位</para>
        /// </summary>
        [Display(Name = "origin")]
        public Models.Location Origin { get; set; }

        /// <summary>
        /// 终点
        /// <para>格式为：纬度,经度</para>
        /// <para>小数点后不超过6位</para>
        /// </summary>
        [Display(Name = "destination")]
        public Models.Location Destination { get; set; }

        /// <summary>
        /// 起点uid
        /// <para>POI 的 uid</para>
        /// <para>在已知起点POI 的 uid 情况下，请尽量填写uid，将提升路线规划的准确性</para>
        /// </summary>
        [Display(Name = "origin_uid")]
        public string OriginUid { get; set; }

        /// <summary>
        /// 终点uid
        /// <para>POI 的 uid</para>
        /// <para>在已知起点POI 的 uid 情况下，请尽量填写uid，将提升路线规划的准确性</para>
        /// </summary>
        [Display(Name = "destination_uid")]
        public string DestinationUid { get; set; }

        /// <summary>
        /// 起终点的坐标类型
        /// <para>默认为bd09ll</para>
        /// <para>可选值：bd09ll（百度经纬度坐标）;gcj02（国测局加密坐标）;wgs84（gps 设备获取的坐标）;</para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 出发日期
        /// <para>可指定出发日期，若不填默认规则如下：</para>
        /// <para>1. 若为起终点为同城：则默认为当天</para>
        /// <para>2. 若为起终点为跨城：则默认第二天</para>
        /// </summary>
        [Display(Name = "departure_date")]
        public DateTime? DepartureDate { get; set; }

        /// <summary>
        /// 出发时间区间
        /// <para>出发时间区间，格式为：</para>
        /// <para>1. hh:mm-hh:mm，如”08:00-14:00”：表示只查询发车时间在8点至14点之间的方案</para>
        /// <para>2. hh:mm，如”08:00” ：表示只查询发车时间在8点至24点的方案</para>
        /// </summary>
        [Display(Name = "departure_time")]
        [TransitDepartureTimeConverter]
        public TransitDepartureTime DepartureTime { get; set; }

        /// <summary>
        /// 市内公交换乘策略
        /// </summary>
        [Display(Name = "tactics_incity")]
        [EnumValue]
        public TacticsIncity? TacticsIncity { get; set; }


        /// <summary>
        /// 跨城交通方式策略
        /// <para>默认为 火车优先</para>
        /// </summary>
        [Display(Name = "trans_type_intercity")]
        [EnumValue]
        public TransTypeIntercity? TransTypeIntercity { get; set; }

        /// <summary>
        /// 输出坐标类型
        /// <para>返回值的坐标类型，默认为百度经纬度坐标：bd09ll</para>
        /// <para>可选值： bd09ll：百度经纬度坐标;gcj02：国测局加密坐标</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        [EnumName]
        public Models.Enums.CoordType? RetCoordType { get; set; }


        /// <summary>
        /// 返回每页几条路线
        /// <para>默认为10</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 返回第几页
        /// <para>默认为1</para>
        /// </summary>
        [Display(Name = "page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 时间戳，与SN配合使用
        /// <para>SN存在时必填</para>
        /// </summary>
        [Models.Attributes.UnixDateTimeConverter]
        [Display(Name = "timestamp")]
        public DateTime? Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// 输出类型
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; set; } = "json";
    }

    /// <summary>
    /// 时间区间
    /// </summary>
    public class TransitDepartureTime
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public TimeSpan? Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public TimeSpan? End { get; set; }
    }

}
