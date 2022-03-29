using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Enums
{
    /// <summary>
    /// 排序字段
    /// <para>根据industry_type字段的值而定</para>
    /// </summary>
    public enum SortName
    {
        /// <summary>
        /// 默认
        /// </summary>
        [Description("默认")]
        Default,
        /// <summary>
        /// 价格
        /// </summary>
        [Description("价格")]
        price,
        /// <summary>
        /// 好评
        /// </summary>
        [Description("好评")]
        overall_rating,
        /// <summary>
        /// 距离排序，只有圆形区域检索有效
        /// </summary>
        [Description("距离排序，只有圆形区域检索有效")]
        distance,


       


        /// <summary>
        /// 星级
        /// <para>industry_type为hotel时</para>
        /// </summary>
        [Description("星级")]
        level,
        /// <summary>
        /// 卫生
        /// <para>industry_type为hotel时</para>
        /// </summary>
        [Description("卫生")]
        health_score,

        

        /// <summary>
        /// 口味
        /// <para>industry_type为cater时</para>
        /// </summary>
        [Description("口味")]
        taste_rating,

        
        /// <summary>
        /// 服务
        /// <para>industry_type为cater时</para>
        /// </summary>
        [Description("服务")]
        service_rating,

        /// <summary>
        /// 服务
        /// <para>industry_type为life时</para>
        /// </summary>
        [Description("服务")]
        comment_num,

    }
}
