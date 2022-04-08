using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Toll
{
    /// <summary>
    /// 计算乘用车ETC费用 结果
    /// </summary>
    public class CarResult : Models.ResponseOld
    {
        /// <summary>
        /// 总ETC费用
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll")]
        public double? Toll { get; set; }

        /// <summary>
        /// 收费区间数量
        /// <para>收费区间包括：<br/>
        /// 1. 一段以收费站入口开始和收费站出口结束的高速区间<br/>
        /// 2. 只在入口收费或只在出口收费的高速区间<br/>
        /// 3. 收费的桥梁
        /// </para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_section_num")]
        public int? TollSectionNumber { get; set; }


        /// <summary>
        /// 分段收费信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("toll_sections")]
        public List<TollSection> TollSections { get; set; }
    }
}
