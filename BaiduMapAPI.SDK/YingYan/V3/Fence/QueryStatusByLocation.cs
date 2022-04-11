using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 根据坐标查询监控对象相对围栏的状态
    /// <para>简介：传入坐标，计算该坐标在围栏内/外。</para>
    /// <para>适用场景：由于querystatus接口需要保证到轨迹点的顺序性，因此查询状态会有15s的延迟。若开发者对即时性要求甚高，如共享汽车、共享单车落锁时对于是否停在规定围栏内的判断，可使用querystatusbylocation接口：传入当下定位的坐标，则鹰眼将计算该坐标相对于围栏的状态（内/外）。</para>
    /// </summary>
    public class QueryStatusByLocation : Models.GetWithoutSNRequest<QueryStatusByLocationResult>
    {
        /// <summary>
        /// 接口地址i
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/querystatusbylocation";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 监控对象(必填)
        /// <para>监控对象的 entity_name</para>
        /// </summary>
        [Display(Name = "monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏id列表
        /// <para>若填写，则按照指定的id全部返回围栏状态，此时page_index和page_size不生效。</para>
        /// <para>若不填，则查询监控对象上的所有围栏状态。<br/>
        /// fence_ids中最多填写1000个id。</para>
        /// </summary>
        [Display(Name = "fence_ids")]
        [ListObjectConverter(",")]
        public List<int> FenceIDs { get; set; }

        /// <summary>
        /// 经度(必填)
        /// <para>指定监控对象所在坐标的经度</para>
        /// </summary>
        [Display(Name = "longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 纬度(必填)
        /// <para>指定监控对象所在坐标的纬度</para>
        /// </summary>
        [Display(Name = "latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 坐标类型(必填)
        /// <para>坐标类型定义如下：<br/>
        /// wgs84：GPS经纬度<br/>
        /// gcj02：国测局经纬度<br/>
        /// bd09ll：百度经纬度<br/>
        /// </para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 分页索引
        /// <para>默认值：1</para>
        /// <para>与page_size一起计算从第几条结果返回，代表返回第几页</para>
        /// </summary>
        [Display(Name = "page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页返回数据量
        /// <para>默认值：1000</para>
        /// <para>返回结果最大个数与page_index一起计算从第几条结果返回，代表返回结果中每页的围栏个数</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }
    }
}
