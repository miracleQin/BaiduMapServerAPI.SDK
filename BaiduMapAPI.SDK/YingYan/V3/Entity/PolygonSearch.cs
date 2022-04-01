using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Entity
{
    /// <summary>
    /// 搜索多边形范围内的entity
    /// </summary>
    public class PolygonSearch : SearchBase
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/entity/polygonsearch";

        /// <summary>
        /// 多边形边界点(必填)
        /// <para>规则： 经纬度顺序为：纬度,经度； 顶点顺序可按顺时针或逆时针排列。 多边形外接矩形面积不超过3000平方公里</para>
        /// </summary>
        [Display(Name = "vertexes")]
        [Models.Attributes.LocationListConverter(spliteChar: ";")]
        public List<Models.Location> Vertexes { get; set; }
    }
}
