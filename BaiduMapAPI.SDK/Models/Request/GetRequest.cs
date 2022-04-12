using BaiduMapAPI.Models.Attributes;
using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 以 GET 形式发起的请求
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class GetRequest<TResponse> : RequestWithSN<TResponse>
        where TResponse : Response
    {
        /// <summary>
        /// 获取请求结果
        /// </summary>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        public override async Task<TResponse> GetResultAsync(string AK, string SK)
        {
            return await this.GetAsync(AK,SK);
        }
    }
}
