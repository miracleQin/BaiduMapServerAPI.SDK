using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.HistorySearch
{
    /// <summary>
    /// 删除任务
    /// <para>根据job_id删除任务</para>
    /// </summary>
    public class DeleteJob:Models.FormDataPostWithoutSNRequest<DeleteJobResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://yingyan.baidu.com/api/v3/historysearch/deletejob";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识。</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 任务id(必填)
        /// <para>每个任务的唯一标识</para>
        /// </summary>
        [Display(Name = "job_id")]
        public int? JobID { get; set; }
    }
}
