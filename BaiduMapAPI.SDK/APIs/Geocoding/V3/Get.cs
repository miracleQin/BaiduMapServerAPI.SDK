using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Geocoding.V3
{
    /// <summary>
    /// 地理编码
    /// </summary>
    public class Get : Models.GetRequest<GetResult>
    {
        /// <summary>
        /// 地理编码
        /// </summary>
        public Get()
        {
            this.Output = "json";
        }
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/geocoding/v3/";

        /// <summary>
        /// 待解析的地址
        /// <para>最多支持84个字节</para>
        /// <para>可以输入两种样式的值，分别是： 1、标准的结构化地址信息，如北京市海淀区上地十街十号 【推荐，地址结构越完整，解析精度越高】2、支持“*路与* 路交叉口”描述方式，如北一环路和阜阳路的交叉路口。第二种方式并不总是有返回结果，只有当地址库中存在该地址描述时才有返回。</para>
        /// </summary>
        [Display(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 地址所在的城市名
        /// <para>用于指定上述地址所在的城市，当多个城市都有上述地址时，该参数起到过滤作用，但不限制坐标召回城市。</para>
        /// </summary>
        [Display(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// 可选参数，添加后返回国测局经纬度坐标或百度米制坐标
        /// <para>http://lbsyun.baidu.com/index.php?title=coordinate</para>
        /// </summary>
        [Display(Name = "ret_coordtype")]
        public Models.Enums.CoordType? RetCoordtype { get; set; }

        /// <summary>
        /// 输出格式为json或者xml
        /// </summary>
        [Display(Name = "output")]
        public string Output { get; private set; }

    }
}
