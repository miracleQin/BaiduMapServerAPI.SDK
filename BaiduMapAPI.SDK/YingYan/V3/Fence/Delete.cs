using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 删除围栏
    /// </summary>
    public class Delete : Models.FormDataPostWithoutSNRequest<DeleteResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/delete";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 监控对象
        /// <para>二个字段至少填写一个</para>
        /// <para>仅填写monitored_person字段：根据监控对象删除围栏，仅适用于删除“指定entity创建的围栏”，并删除该entity上的所有围栏（兼容旧版本）。</para>
        /// <para>二字段均填写：根据该监控对象上的指定围栏删除</para>
        /// </summary>
        [Display(Name = "monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏id列表
        /// <para>二个字段至少填写一个</para>
        /// <para>仅填写fence_ids字段：根据围栏id删除（针对该service下所有entity创建的围栏，使用此方法删除）</para>
        /// <para>二字段均填写：根据该监控对象上的指定围栏删除</para>
        /// </summary>
        [Display(Name = "fence_ids")]
        [ListObjectConverter(",")]
        public List<int> FenceIDs { get; set; }


    }
}
