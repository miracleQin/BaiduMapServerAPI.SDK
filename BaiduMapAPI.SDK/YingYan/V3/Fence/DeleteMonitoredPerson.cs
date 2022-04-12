using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 删除围栏可去除监控的entity
    /// <para>删除某一个围栏下的一些entity</para>
    /// </summary>
    public class DeleteMonitoredPerson : Models.FormDataPostWithoutSNRequest<DeleteMonitoredPersonResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/deletemonitoredperson";

        /// <summary>
        /// service的ID(必填)
        /// <para>该围栏实体所属的轨迹服务ID</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 围栏的唯一标识(必填)
        /// </summary>
        [Display(Name = "fence_id")]
        public int? FenceID { get; set; }

        /// <summary>
        /// 监控对象(必填)
        /// <para>轨迹服务中的entity_name。</para>
        /// <para>支持通过entity列表向围栏删除entity。<br/>
        /// 1、通过围栏列表删除：每次删除entity上限为100个，多个entity_name使用英文逗号分隔<br/>
        /// 示例： monitored_person =entity_name1, entity_name2, entity_name3。<br/>
        /// 2、删除围栏所有监控对象：#clearentity<br/>
        /// 示例：monitored_person=#clearentity
        /// </para>
        /// </summary>
        [Display(Name = "monitored_person")]
        [ListObjectConverter(",")]
        public List<string> MonitoredPerson { get; set; }
    }
}
