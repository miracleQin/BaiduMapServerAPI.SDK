using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.APIs.Location
{
    /// <summary>
    /// 普通IP定位
    /// </summary>
    public class IP : Models.GetRequest<IPResult>
    {
        public override string URL => "https://api.map.baidu.com/location/ip";

        /// <summary>
        /// 用户上网的IP地址，请求中如果不出现或为空，会针对发来请求的IP进行定位。
        /// </summary>
        [Display(Name = "ip")]
        public string IPAddress { get; set; }

        /// <summary>
        /// 设置返回位置信息中，经纬度的坐标类型
        /// </summary>
        [Display(Name = "coor")]
        public Models.Enums.CoordType? Coor { get; set; }
    }
}
