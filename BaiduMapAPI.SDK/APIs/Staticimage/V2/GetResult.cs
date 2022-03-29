using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Staticimage.V2
{
    /// <summary>
    /// 静态地图结果
    /// </summary>
    public class GetResult : Models.Response
    {
        /// <summary>
        /// 静态地图图片地址
        /// </summary>
        public string ImageURL { get; set; }
    }
}
