using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Routematrix.V2
{
    /// <summary>
    /// 批量算路-驾车
    /// </summary>
    public class Driving : GetBase<DrivingResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/routematrix/v2/driving";
    }
}
