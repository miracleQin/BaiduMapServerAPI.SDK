using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 创建行政区划围栏
    /// <para>以行政区划关键字创建围栏。<br/>
    /// 1. 若关键字匹配至唯一的行政区划，则将创建该围栏<br/>
    /// 2. 若关键字匹配至多个行政区划，则围栏创建失败，将返回匹配的行政区划名称列表
    /// </para>
    /// <para>支持三种监控模式：<br/>
    /// 1、监控一个entity的围栏<br/>
    /// 2、监控多个entity的围栏<br/>
    /// 3、监控service下的所有entity围栏
    /// </para>
    /// </summary>
    internal class CreateDistrictFence : Models.FormDataPostWithoutSNRequest<CreateDistrictFenceResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/createdistrictfence";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 围栏名称
        /// </summary>
        [Display(Name = "fence_name")]
        public string FenceName { get; set; }

        /// <summary>
        /// 监控对象
        /// <para>监控对象的entity_name，使用说明：<br/>
        /// 1、监控一个entity（私有围栏：一个entity最多创建100个私有围栏，service总私有围栏个数无限制）<br/>
        /// 规则：monitored_person=entity_name<br/>
        /// 示例：monitored_person=张三<br/>
        /// 2、监控多个entity（公共围栏：一个service默认最多创建1000个公共围栏，若需更高围栏限额可通过反馈平台联系购买，一个service支持公共围栏个数上限为10万个）<br/>
        /// <![CDATA[http://lbsyun.baidu.com/apiconsole/fankui]]><br/>
        /// 首先按照监控一个entity的方法创建围栏，再调用geofence/addmonitoredperson接口添加其他entity<br/>
        /// <![CDATA[http://lbsyun.baidu.com/index.php?title=yingyan/api/v3/geofence#service-page-anchor13]]><br/>
        /// 3、监控service下全部entity（公共围栏：一个service默认最多创建1000个公共围栏，若需更高围栏限额可通过反馈平台联系购买，一个service支持公共围栏个数上限为10万个）<br/>
        /// <![CDATA[http://lbsyun.baidu.com/apiconsole/fankui]]><br/>
        /// 规则：monitored_person=#allentity<br/>
        /// "#allentity"为监控全部entity的特殊字符<br/>
        /// </para>
        /// </summary>
        [Display(Name = "monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 行政区划关键字(必填)
        /// <para>支持中国国家、省、市、区/县、乡镇名称。请尽量输入完整的行政区层级和名称，保证名称的唯一性。若输入的行政区名称匹配多个行政区，围栏将创建失败。</para>
        /// <para>示例： 中国 北京市 湖南省长沙市 湖南省长沙市雨花区</para>
        /// </summary>
        [Display(Name = "keyword")]
        public string Keywrod { get; set; }

        /// <summary>
        /// 围栏去噪参数
        /// <para>单位：米</para>
        /// <para>每个轨迹点都有一个定位误差半径radius，这个值越大，代表定位越不准确，可能是噪点。围栏计算时，如果噪点也参与计算，会造成误报的情况。设置denoise可控制，当轨迹点的定位误差半径大于设置值时，就会把该轨迹点当做噪点，不参与围栏计算。denoise默认值为0，不去噪。</para>
        /// </summary>
        [Display(Name = "denoise")]
        public int? Denoise { get; set; }
    }
}
