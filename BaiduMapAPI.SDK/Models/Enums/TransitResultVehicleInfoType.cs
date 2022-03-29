using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 路线规划交通方式的类型
    /// </summary>
    public enum TransitResultVehicleInfoType
    {

        /// <summary>
        /// 火车
        /// </summary>
        [Description("火车")]
        Train=1,

        /// <summary>
        /// 飞机
        /// </summary>
        [Description("飞机")]
        Airplane = 2,

        /// <summary>
        /// 公交
        /// </summary>
        [Description("公交")]
        OrdinaryDailyBus = 3,

        /// <summary>
        /// 驾车
        /// </summary>
        [Description("驾车")]
        Drivering = 4,

        /// <summary>
        /// 步行
        /// </summary>
        [Description("步行")]
        Walk=4,

        /// <summary>
        /// 大巴
        /// </summary>
        [Description("大巴")]
        Bus = 4,

    }

}
