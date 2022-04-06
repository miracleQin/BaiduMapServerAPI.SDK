using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Track
{
    /// <summary>
    /// 上传单个轨迹点
    /// </summary>
    public class AddPoint : Models.FormDataPostWithoutSNRequest<AddPointResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/track/addpoint";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// entity唯一标识(必填)
        /// <para>标识轨迹点所属的 entity</para>
        /// </summary>
        [Display(Name = "entity_name")]
        public string EntityName { get; set; }

        /// <summary>
        /// 纬度(必填)
        /// </summary>
        [Display(Name = "latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 经度(必填)
        /// </summary>
        [Display(Name = "longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 定位时设备的时间(必填)
        /// <para>输入的loc_time不能大于当前服务端时间10分钟以上，即不支持存未来的轨迹点。</para>
        /// <para>且输入的loc_time不能小于当前服务端时间1年以上，即不支持存1年以前的轨迹点。</para>
        /// </summary>
        [Display(Name = "loc_time")]
        [UnixDateTimeConverter]
        public DateTime? LocationTime { get; set; }

        /// <summary>
        /// 坐标类型(必填)
        /// <para>默认值：bd09ll</para>
        /// <para>该字段用于描述上传的坐标类型。可选值为：</para>
        /// <para>wgs84：GPS 坐标</para>
        /// <para>gcj02：国测局加密坐标</para>
        /// <para>bd09ll：百度经纬度坐标</para>
        /// </summary>
        [Display(Name = "coord_type_input")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeInput { get; set; }

        /// <summary>
        /// 速度
        /// <para>单位：km/h</para>
        /// </summary>
        [Display(Name = "speed")]
        public double? Speed { get; set; }

        /// <summary>
        /// 方向
        /// <para>范围为[0,359]，0度为正北方向，顺时针</para>
        /// </summary>
        [Display(Name = "direction")]
        public int? Direction { get; set; }

        /// <summary>
        /// 高度
        /// <para>单位：米</para>
        /// </summary>
        [Display(Name = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// 定位精度，GPS或定位SDK返回的值
        /// <para>单位：米</para>
        /// </summary>
        [Display(Name = "radius")]
        public double? Radius { get; set; }
        /// <summary>
        /// 对象数据名称
        /// <para>通过鹰眼 SDK 上传的图像文件名称</para>
        /// </summary>
        [Display(Name = "object_name")]
        public string ObjectName { get; set; }

        /// <summary>
        /// track的自定义字段
        /// <para>此处值的类型须与用户自定义的column的类型一致</para>
        /// <para>随轨迹点上传开发者自定义字段的值</para>
        /// </summary>
        public Dictionary<string, string> ColumnDatas { get; set; }
    }
}
