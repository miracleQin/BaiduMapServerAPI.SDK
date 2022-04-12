using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 删除entity
    /// </summary>
    public class Delete : Models.FormDataPostWithoutSNRequest<DeleteResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/delete";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// entity名称(必填)
        /// <para>作为其唯一标识</para>
        /// <para>同一service服务中entity_name不可重复。一旦创建entity_name 不可更新。</para>
        /// <para>命名规则：仅支持中文、英文大小字母、英文下划线"_"、英文横线"-"和数字。 entity_name 和 entity_desc 支持联合模糊检索。</para>
        /// <para>注意：一个service最多创建100万个entity，达到上限后将无法再创建新的entity。</para>
        /// </summary>
        [Display(Name = "entity_name")]
        public string EntityName { get; set; }
    }
}
