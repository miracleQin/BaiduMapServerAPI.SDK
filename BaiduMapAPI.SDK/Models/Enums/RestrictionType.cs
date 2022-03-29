using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 限行类型
    /// </summary>
    public enum RestrictionType
    {
        /// <summary>
        /// 不限行
        /// </summary>
        [Description("不限行")]
        UnrestrictedAccess = 0,

        /// <summary>
        /// 本地车限行
        /// </summary>
        [Description("本地车限行")]
        LocalLicensePlateRestrictions = 1,

        /// <summary>
        /// 外地车限行
        /// </summary>
        [Description("外地车限行")]
        ForeignLicensePlateRestrictions = 2,

        /// <summary>
        /// 本地车尾号限行
        /// </summary>
        [Description("本地车尾号限行")]
        TrafficIsRestrictedByTheTailNumberOfLocalLicensePlate = 3,

        /// <summary>
        /// 外地车尾号限行
        /// </summary>
        [Description("外地车尾号限行")]
        TrafficIsRestrictedByTheTailNumberOfForeignLicensePlates=4,

        /// <summary>
        /// 其他限行
        /// </summary>
        [Description("其他限行")]
        RestrictionOfAccessForOtherReasons=5,
    }
}
