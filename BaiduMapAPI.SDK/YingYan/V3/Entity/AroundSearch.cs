using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 周边搜索，根据圆心和半径搜索 entity
    /// </summary>
    public class AroundSearch : SearchBase
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/aroundsearch";

        /// <summary>
        /// 中心点经纬度(必填)
        /// <para>格式为：纬度,经度</para>
        /// <para>示例：36.20,116.30</para>
        /// </summary>
        [Display(Name = "center")]
        public Models.Location Center { get; set; }

        /// <summary>
        /// 搜索半径(必填)
        /// <para>单位：米</para>
        /// <para>取值范围[1,5000]</para>
        /// </summary>
        [Display(Name = "radius")]
        public int? Radius { get; set; }
    }
}
