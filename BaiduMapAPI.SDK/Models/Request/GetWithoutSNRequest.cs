using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// Get 请求
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class GetWithoutSNRequest<TResponse> : RequestWithoutSN<TResponse>
        where TResponse : Models.Response
    {
        /// <summary>
        /// 获取请求结果
        /// </summary>
        /// <param name="AK"></param>
        /// <returns></returns>
        public override async Task<TResponse> GetResultAsync(string AK)
        {
            return await this.GetWithoutSNAsync(AK);
        }
    }
}
