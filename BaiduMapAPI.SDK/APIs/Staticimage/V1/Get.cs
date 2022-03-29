
using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.APIs.Staticimage.V1
{
    /// <summary>
    /// 获取静态地图第一版
    /// </summary>
    public class Get : V2.Get
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public override string URL => "https://api.map.baidu.com/staticimage";

        public override async Task<V2.GetResult> GetResultAsync(string AK, string SK)
        {
            string url = "";

            await Task.Run(() =>
            {
                NameValueCollection querys = this.GetPropertyStringValue();
                querys.Add("ak", AK);
                url = BaiduHelper.GetUrl(URL, querys, false);
            });

            return new V2.GetResult() { ImageURL = url };
        }
    }
}
