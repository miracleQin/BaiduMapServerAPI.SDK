using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 以 JSON 格式发起 POST 请求
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class JsonPostWithoutSN<TResponse> : RequestWithoutSN<TResponse>
        where TResponse : Response
    {
        public override async Task<TResponse> GetResultAsync(string AK)
        {
            return await this.PostJsonAsync(AK);
        }
    }
}
