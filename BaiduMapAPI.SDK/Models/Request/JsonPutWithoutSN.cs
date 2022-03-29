using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// JSON put 请求
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class JsonPutWithoutSN<TResponse> : RequestWithoutSN<TResponse>
        where TResponse : Response
    {
        public override async Task<TResponse> GetResultAsync(string AK)
        {
            return await this.PutJsonAsync(AK);
        }
    }
}
