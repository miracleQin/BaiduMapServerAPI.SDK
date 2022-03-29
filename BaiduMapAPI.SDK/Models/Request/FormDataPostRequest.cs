using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    public abstract class FormDataPostRequest<TResponse> : RequestWithSN<TResponse>
        where TResponse : Response
    {
        public override async Task<TResponse> GetResultAsync(string AK, string SK)
        {
            return await this.PostFormAsync(AK, SK);
        }
    }
}
