using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 根据矩形范围搜索entity
    /// </summary>
    public class BoundSearch : SearchBase
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/boundsearch";


        /// <summary>
        /// 矩形区域(必填)
        /// <para>左下角和右上角的经纬度坐标点</para>
        /// <para>坐标点顺序为"左下;右上"，坐标对间使用;号分隔，格式为：纬度,经度;纬度,经度</para>
        /// <para>示例：36.20,116.30;37.20,117.30</para>
        /// </summary>
        [Display(Name= "bounds")]
        public APIs.Traffic.V1.Bound Bounds { get; set; }
    }
}
