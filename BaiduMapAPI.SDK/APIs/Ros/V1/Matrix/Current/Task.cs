using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Matrix.Current
{
    /// <summary>
    /// 路网任务执行时间查询接口
    /// </summary>
    public class Task : Models.GetWithoutSNRequest<PostResult>
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/ros/v1/matrix/current/task";


    }
}
