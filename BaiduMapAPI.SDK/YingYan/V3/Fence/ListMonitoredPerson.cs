using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询围栏监控的所有entity
    /// <para>查询某service下的某一个围栏下的所有entity，方便开发者管理查询entity</para>
    /// </summary>
    public class ListMonitoredPerson : Models.GetWithoutSNRequest<ListMonitoredPersonResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/listmonitoredperson";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 围栏id(必填)
        /// </summary>
        [Display(Name = "fence_id")]
        public int? FenceID { get; set; }


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
