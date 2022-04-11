using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 查询围栏
    /// </summary>
    public class List : Models.GetWithoutSNRequest<ListResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "http://yingyan.baidu.com/api/v3/fence/list";

        /// <summary>
        /// service的ID(必填)
        /// <para>service 的唯一标识</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Display(Name = "service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 监控对象
        /// <para>二个字段至少填写一个</para>
        /// <para>二字段均填写：根据该监控对象上的指定围栏查询</para>
        /// <para>仅填写monitored_person字段：根据监控对象查询围栏，支持3种查询方式：<br/>
        /// 1）输入某个entity_name查询该监控对象上的所有围栏；<br/>
        /// 2）输入#allentity，查询监控全部entity的公共围栏；<br/>
        /// 3）输入#partofentity，查询监控部分entity的公共围栏。</para>
        /// </summary>
        [Display(Name = "monitored_person")]
        public string MonitoredPerson { get; set; }

        /// <summary>
        /// 围栏id列表
        /// <para>二个字段至少填写一个</para>
        /// <para>二字段均填写：根据该监控对象上的指定围栏查询</para>
        /// <para>仅填写fence_ids字段：则根据围栏id查询，此时page_size和page_index不生效</para>
        /// </summary>
        [Display(Name = "fence_ids")]
        [ListObjectConverter(",")]
        public List<int> FenceIDs { get; set; }

        /// <summary>
        /// 输出坐标类型
        /// <para>默认为 bd09ll。</para>
        /// <para>用于控制返回信息的坐标类型，可选值如下：<br/>
        /// bd09ll：百度经纬度<br/>
        /// gcj02：国测局经纬度
        /// </para>
        /// <para>注：在国内（包括港、澳、台）以外区域，无论设置何种坐标系，均返回 wgs84坐标</para>
        /// </summary>
        [Display(Name = "coord_type_output")]
        [EnumName]
        public Models.Enums.CoordType? CoordTypeOutput { get; set; }

        /// <summary>
        /// 分页索引
        /// <para>默认值：1</para>
        /// <para>与page_size一起计算从第几条结果返回，代表返回第几页</para>
        /// </summary>
        [Display(Name = "page_index")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页返回数据量
        /// <para>默认值：1000</para>
        /// <para>返回结果最大个数与page_index一起计算从第几条结果返回，代表返回结果中每页的围栏个数</para>
        /// </summary>
        [Display(Name = "page_size")]
        public int? PageSize { get; set; }
    }
}
