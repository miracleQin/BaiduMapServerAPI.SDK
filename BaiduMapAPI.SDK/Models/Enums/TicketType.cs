﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 票类型
    /// </summary>
    public enum TicketType
    {
        /// <summary>
        /// 公交票价
        /// </summary>
        [Description("公交票价")]
        Bus=0,

        /// <summary>
        /// 地铁票价
        /// </summary>
        [Description("地铁票价")]
        Metro =1,
    }
}
