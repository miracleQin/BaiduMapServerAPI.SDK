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
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/location/ip";

        /// <summary>
        /// 用户上网的IP地址
        /// <para>请求中如果不出现或为空，会针对发来请求的IP进行定位。</para>
        /// <para>如您需要通过IPv6来获取位置信息，请提交工单申请。</para>
        /// <para><![CDATA[http://lbsyun.baidu.com/apiconsole/fankui]]></para>
        /// </summary>
        [Display(Name = "ip")]
        public string IPAddress { get; set; }

        /// <summary>
        /// 返回位置信息的坐标类型
        /// <para>设置返回位置信息中，经纬度的坐标类型</para>
        /// <para>坐标类型，分别如下：</para>
        /// <list type="number">
        /// <item>bd09ll <c>百度经纬度坐标，在国测局坐标基础之上二次加密而来</c></item>
        /// <item>gcj02 <c>国测局02坐标，在原始GPS坐标基础上，按照国家测绘行业统一要求，加密后的坐标</c></item>
        /// </list>
        /// <para><c>注意：百度地图的坐标类型为bd09ll，如果结合百度地图使用，请注意坐标选择</c></para>
        /// </summary>
        [Display(Name = "coor")]
        public Models.Enums.CoordType? Coor { get; set; }
    }
}
