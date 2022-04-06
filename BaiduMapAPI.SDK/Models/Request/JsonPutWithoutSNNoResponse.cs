using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// PUT 提交 JSON (非 SN 模式)
    /// </summary>
    public abstract class JsonPutWithoutSNNoResponse: RequestWithoutSN<Models.Response>
    {
        /// <summary>
        /// 获取请求结果
        /// </summary>
        /// <param name="AK"></param>
        /// <returns></returns>
        public override async Task<Models.Response> GetResultAsync(string AK)
        {
            return await this.PutJsonNoResponseAsync(AK);
        }

    }
}
