using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 有或没有
    /// </summary>
    public enum HasOrNot
    {
        /// <summary>
        /// 有
        /// </summary>
        [Description("有")]
        Have=1,
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        NotHave=0,
    }
}
