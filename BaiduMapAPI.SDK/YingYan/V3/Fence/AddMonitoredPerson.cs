using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 增加围栏需监控的entity
    /// <para>针对某一个地理围栏增加entity</para>
    /// </summary>
    public class AddMonitoredPerson : Models.FormDataPostWithoutSNRequest<AddMonitoredPersonResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/addmonitoredperson";

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
        /// <para>支持通过entity列表向围栏添加entity。 每次添加entity上限为100个。<br/>
        /// 示例：monitored_person =entity_name1, entity_name2, entity_name3 <br/>
        /// 多个entity_name使用英文逗号分隔</para>
        /// </summary>
        [Display(Name = "monitored_person")]
        [ListObjectConverter(",")]
        public List<string> MonitoredPerson { get; set; }
    }
}
