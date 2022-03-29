using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 矩形坐标信息
    /// </summary>
    public class Bound
    {
        /// <summary>
        /// 左上角坐标
        /// </summary>        
        public Location TopLeft { get; set; }

        /// <summary>
        /// 右下角坐标
        /// </summary>
        public Location BottonRight { get; set; }
    }
}
