using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// Form 表单 POST 提交
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class FormDataPostRequest<TResponse> : RequestWithSN<TResponse>
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
            return await this.PostFormAsync(AK, SK);
        }
    }
}
