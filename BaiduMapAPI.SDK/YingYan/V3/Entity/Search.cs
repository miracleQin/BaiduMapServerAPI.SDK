using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 根据关键字搜索entity
    /// </summary>
    public class Search : SearchBase
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/search";

        /// <summary>
        /// 搜索关键字
        /// <para>默认为空，检索全部数据支持 entity_name + entity_desc 的联合模糊检索</para>
        /// </summary>
        [Display(Name="query")]
        public string Query { get; set; }
    }
}
