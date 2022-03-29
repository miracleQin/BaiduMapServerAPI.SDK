using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 转向类型
    /// </summary>
    public enum TurnType
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        NONE = 0,

        /// <summary>
        /// 直行
        /// </summary>
        [Description("直行")]
        GoStraightAhead = 1,
        /// <summary>
        /// 右前方转弯
        /// </summary>
        [Description("右前方转弯")]
        RightFrontTurn = 2,
        /// <summary>
        /// 右转
        /// </summary>
        [Description("右转")]
        TurnRight = 3,
        /// <summary>
        /// 右后方转弯
        /// </summary>
        [Description("右后方转弯")]
        RightRearTurn = 4,
        /// <summary>
        /// 掉头
        /// </summary>
        [Description("掉头")]
        TurnAround = 5,
        /// <summary>
        /// 左后方转弯
        /// </summary>
        [Description("左后方转弯")]
        LeftRearTurn = 6,
        /// <summary>
        /// 左转
        /// </summary>
        [Description("左转")]
        TurnLeft = 7,
        /// <summary>
        /// 左前方转弯
        /// </summary>
        [Description("左前方转弯")]
        LeftFrontTurn = 8,
        /// <summary>
        /// 左侧
        /// </summary>
        [Description("左侧")]
        Left = 9,
        /// <summary>
        /// 右侧
        /// </summary>
        [Description("右侧")]
        Right = 10,
        /// <summary>
        /// 分歧-左
        /// </summary>
        [Description("分歧-左")]
        DivergentLeft = 11,
        /// <summary>
        /// 分歧中央
        /// </summary>
        [Description("分歧中央")]
        DivergentCenter = 12,
        /// <summary>
        /// 分歧右
        /// </summary>
        [Description("分歧右")]
        DivergentRight = 13,
        /// <summary>
        /// 环岛
        /// </summary>
        [Description("环岛")]
        Roundabout = 14,
        /// <summary>
        /// 进渡口
        /// </summary>
        [Description("进渡口")]
        EntranceFerry = 15,
        /// <summary>
        /// 出渡口
        /// </summary>
        [Description("出渡口")]
        ExitFerry = 16,

    }
}
