using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// Form 表单提交(非 SN 模式)
    /// </summary>
    public abstract class FormDataPostWithoutSNRequest<TResponse> : RequestWithoutSN<TResponse>
        where TResponse : Response
    {
        /// <summary>
        /// 获取请求结果
        /// </summary>
        /// <param name="AK"></param>
        /// <returns></returns>
        public override async Task<TResponse> GetResultAsync(string AK)
        {
            return await this.PostFormAsync(AK);
        }
    }
}
