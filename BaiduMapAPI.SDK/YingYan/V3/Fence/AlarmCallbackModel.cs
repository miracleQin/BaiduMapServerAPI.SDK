using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.YingYan.V3.Fence
{
    /// <summary>
    /// 电子围栏报警回调信息
    /// </summary>
    public class AlarmCallbackModel
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [Newtonsoft.Json.JsonProperty("type")]
        public CallbackType? Type { get; set; }

        /// <summary>
        /// service的唯一标识
        /// <para>当前报警信息所属的鹰眼服务ID</para>
        /// <para>在轨迹管理台创建鹰眼服务时，系统返回的 service_id</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("service_id")]
        public int? ServiceID { get; set; }

        /// <summary>
        /// 报警信息数组
        /// <para>当type为1时，content为空或不存在。</para>
        /// <para>该字段为数组格式，数组的每个内容都是一个推送信息。</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("content")]
        public List<AlarmInfo> Content { get; set; }
    }

    /// <summary>
    /// 回调类型
    /// </summary>
    public enum CallbackType
    {
        /// <summary>
        /// 校验该URL为有效URL
        /// <para>校验该URL为有效URL。此时，content为空或不存在。开发者无需对消息内容做任何处理，只需正常返回即可。</para>
        /// </summary>
        [Description("校验URL")]
        URLValid = 1,

        /// <summary>
        /// 推送报警信息
        /// <para>开发者可取content中的内容做其他业务处理。</para>
        /// </summary>
        [Description("报警推送")]
        Alarm=2,
    }
}
