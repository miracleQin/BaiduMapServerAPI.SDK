using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Place.V2
{
    /// <summary>
    /// 圆形检索
    /// </summary>
    public class SearchByRadius : SearchBase
    {
        /// <summary>
        /// 圆形区域检索中心点
        /// <para>不支持多个点</para>
        /// </summary>
        [Display(Name = "location")]
        public Models.Location Location { get; set; }

        /// <summary>
        /// 圆形区域检索半径(单位为米)
        /// <para>（增加区域内数据召回权重，如需严格限制召回数据在区域内，请搭配使用radius_limit参数），当半径过大，超过中心点所在城市边界时，会变为城市范围检索，检索范围为中心点所在城市</para>
        /// </summary>
        [Display(Name = "radius")]
        public int? Radius { get; set; }

        /// <summary>
        /// 是否严格限定召回结果在设置检索半径范围内
        /// <para>设置为true时会影响返回结果中total准确性及每页召回poi数量， 设置为false时可能会召回检索半径外的poi。</para>
        /// </summary>
        [Display(Name = "raidus_limit")]
        public bool? RadiusLimit { get; set; }
    }
}
