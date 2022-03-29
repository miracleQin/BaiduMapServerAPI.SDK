using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class JsonPutWithoutSNNoResponse: RequestWithoutSN<Models.Response>
    {

        public override async Task<Models.Response> GetResultAsync(string AK)
        {
            return await this.PutJsonNoResponseAsync(AK);
        }

    }
}
