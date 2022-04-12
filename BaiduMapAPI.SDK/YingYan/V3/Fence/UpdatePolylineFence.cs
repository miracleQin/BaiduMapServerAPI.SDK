using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 更新线型围栏
    /// </summary>
    public class UpdatePolylineFence : Models.FormDataPostWithoutSNRequest<UpdatePolylineFenceResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/updatepolylinefence";


        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 围栏的唯一标识(必填)
        /// <para>用于指定所更新的围栏</para>
        /// </summary>
        [Display(Name = "fence_id")]
        public int? FenceID { get; set; }

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
        /// 线型围栏坐标点
        /// <para>经纬度顺序为：纬度,经度；</para>
        /// <para>顶点顺序可按顺时针或逆时针排列；</para>
        /// <para>1. 普通地理围栏：坐标点个数在2-100个之间，路线长度&lt;500公里。若传入坐标点个数大于100，则鹰眼将自动对坐标进行适当抽稀，若抽稀后点数仍 &gt;100，则创建围栏将会失败，请开发者自行降低原始坐标点个数。<br/>
        /// 2. 大范围地理围栏：坐标点个数在2-500个之间，路线长度&lt;500公里。若传入坐标点个数大于500，则鹰眼将自动对坐标进行适当抽稀，若抽稀后点数仍&gt;500，则创建围栏将会失败，请开发者自行降低原始坐标点个数。</para>
        /// <para>注：如需试用大范围地理围栏，可通过反馈平台联系开通试用。<br/>
        /// http://lbsyun.baidu.com/apiconsole/fankui</para>
        /// </summary>
        [Display(Name = "vertexes")]
        [LocationListConverter(";")]
        public List<Models.Location> Vertexes { get; set; }

        /// <summary>
        /// 偏离距离
        /// <para>单位：米</para>
        /// <para>取值范围(0,200]</para>
        /// <para>偏移距离（若偏离折线距离超过该距离即报警）</para>
        /// </summary>
        [Display(Name = "offset")]
        public int? Offset { get; set; }

        /// <summary>
        /// 坐标类型
        /// <para>若更新线型围栏坐标点，则必填</para>
        /// <para>坐标类型定义如下：<br/>
        /// wgs84：GPS经纬度<br/>
        /// gcj02：国测局经纬度<br/>
        /// bd09ll：百度经纬度<br/>
        /// </para>
        /// </summary>
        [Display(Name = "coord_type")]
        [EnumName]
        public Models.Enums.CoordType? CoordType { get; set; }

        /// <summary>
        /// 围栏去噪参数
        /// <para>单位：米</para>
        /// <para>每个轨迹点都有一个定位误差半径radius，这个值越大，代表定位越不准确，可能是噪点。围栏计算时，如果噪点也参与计算，会造成误报的情况。设置denoise可控制，当轨迹点的定位误差半径大于设置值时，就会把该轨迹点当做噪点，不参与围栏计算。denoise默认值为0，不去噪。</para>
        /// </summary>
        [Display(Name = "denoise")]
        public int? Denoise { get; set; }
    }
}
