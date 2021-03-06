using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.HistorySearch
{
    /// <summary>
    /// 查询搜索
    /// <para>查询任务池中的任务，任务池中包括以下几类任务：<br/>
    /// 1. 已创建尚未开始执行的任务<br/>
    /// 2. 正在执行的任务<br/>
    /// 3. 已完成的任务，但完成时间不超过48小时（注：已完成的任务会在48小时之后自动清理）已完成的任务会返回file_url，将地址粘贴至浏览器或使用其他下载方  法，即可获得结果文件。当file_url显示no result的时候，表明没有查询到entity。</para>
    /// </summary>
    public class GetJob : Models.GetWithoutSNRequest<GetJobResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://yingyan.baidu.com/api/v3/historysearch/getjob";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识。</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }
    }
}
