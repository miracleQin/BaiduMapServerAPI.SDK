using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 检索结果详细程度
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// 基本信息
        /// </summary>
        [Description("基本信息")]
        BaseInfo =1,
        /// <summary>
        /// 详细信息
        /// </summary>
        [Description("详细信息")]
        DetailInfo=2,
    }
}
