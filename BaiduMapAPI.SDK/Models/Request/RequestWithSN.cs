using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 基础请求信息
    /// <para>需要提交 SN 参数</para>
    /// </summary>
    public abstract class RequestWithSN<TResponse> : Request<TResponse>
        where TResponse : Response
    {
        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        public TResponse GetResult(string AK, string SK) 
        {
            return GetResultAsync(AK, SK).Result;
        }

        /// <summary>
        /// 以异步方式获取结果
        /// </summary>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        public abstract Task<TResponse> GetResultAsync(string AK, string SK);
    }
}
