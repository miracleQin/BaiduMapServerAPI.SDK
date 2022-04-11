using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询监控对象相对围栏的状态
    /// <para>查询被监控对象在指定围栏内或外，也支持查询被监控对象目前相对于所有围栏的状态</para>
    /// </summary>
    public class QueryStatus : Models.GetWithoutSNRequest<QueryStatusResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/querystatus";

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
