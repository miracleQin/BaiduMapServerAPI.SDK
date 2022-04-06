using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Utilities
{
    /// <summary>
    /// HTTP 请求辅助类
    /// </summary>
    internal static class HttpHelper
    {
        /// <summary>
        /// 创建连接对象
        /// </summary>
        /// <returns></returns>
        internal static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "BaiduMapAPISDK");
            return client;
        }

        /// <summary>
        /// 以 POST 形式提交表单
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        internal static async Task<TResponse> PostFormAsync<TResponse>(this Models.Request<TResponse> request, string AK, string SK)
            where TResponse : Models.Response
        {
            TResponse result = default;
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

            System.Collections.Specialized.NameValueCollection qc = new System.Collections.Specialized.NameValueCollection();
            qc.Add("ak", AK);
            var tmp = request.GetPropertyStringValue();
            foreach (var ky in tmp.AllKeys) qc.Add(ky, tmp[ky]);
            var uri = new Uri(request.URL);
            var sn = BaiduHelper.CaculateAKSN(AK, SK, uri.AbsolutePath, qc, true);

            qc.Add("sn", sn);
            var url = request.URL;


            foreach (var key in qc.AllKeys)
            {
                data.Add(new KeyValuePair<string, string>(key, qc[key]));
            }



            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {

                requestMsg.RequestUri = new Uri(url);
                requestMsg.Method = HttpMethod.Post;
                requestMsg.Content = new FormUrlEncodedContent(data);

                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }
            return result;
        }

        /// <summary>
        /// 表单提交
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <returns></returns>
        internal static async Task<TResponse> PostFormAsync<TResponse>(this Models.Request<TResponse> request, string AK)
            where TResponse : Models.Response
        {
            TResponse result = default;
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

            System.Collections.Specialized.NameValueCollection qc = new System.Collections.Specialized.NameValueCollection();
            qc.Add("ak", AK);
            var tmp = request.GetPropertyStringValue();
            foreach (var ky in tmp.AllKeys) qc.Add(ky, tmp[ky]);

            var url = request.URL;


            foreach (var key in qc.AllKeys)
            {
                data.Add(new KeyValuePair<string, string>(key, qc[key]));
            }

            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {
                requestMsg.RequestUri = new Uri(url);
                requestMsg.Method = HttpMethod.Post;
                requestMsg.Content = new FormUrlEncodedContent(data);

                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }

            return result;
        }

        /// <summary>
        /// 以 POST 形式请求接口
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <returns></returns>
        internal static async Task<TResponse> PostJsonAsync<TResponse>(this Models.Request<TResponse> request, string AK)
            where TResponse : Models.Response
        {
            TResponse result = default;



            var url = $"{request.URL}{(request.URL.Contains("?") ? "&" : "?")}ak={AK}";
            url = request.GetUrl(url);
            var requestBody = request.ToJson();

            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {
                requestMsg.Method = HttpMethod.Post;
                requestMsg.RequestUri = new Uri(url);
                requestMsg.Content = new StringContent(requestBody, Encoding.Default, "application/json");

                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }
            return result;
        }

        /// <summary>
        /// 以 POST 形式请求接口
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <returns></returns>
        internal static async Task<TResponse> PutJsonAsync<TResponse>(this Models.Request<TResponse> request, string AK)
            where TResponse : Models.Response
        {
            TResponse result = default;

            var url = $"{request.URL}{(request.URL.Contains("?") ? "&" : "?")}ak={AK}";
            url = request.GetUrl(url);

            var requestBody = request.ToJson();

            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {
                requestMsg.Method = HttpMethod.Put;
                requestMsg.RequestUri = new Uri(url);
                requestMsg.Content = new StringContent(requestBody, Encoding.Default, "application/json");

                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }
                
            return result;
        }

        /// <summary>
        /// 以 POST 形式请求接口
        /// </summary>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <returns></returns>
        internal static async Task<Models.Response> PutJsonNoResponseAsync(this Models.Request<Models.Response> request, string AK)
        {
            Models.Response result = new Models.Response();



            var url = $"{request.URL}{(request.URL.Contains("?") ? "&" : "?")}ak={AK}";
            url = request.GetUrl(url);

            var requestBody = request.ToJson();

            HttpRequestMessage requestMsg = new HttpRequestMessage();
            requestMsg.Method = HttpMethod.Post;
            requestMsg.RequestUri = new Uri(url);
            requestMsg.Content = new StringContent(requestBody, Encoding.Default, "application/json");

            Exception exception = null;
            HttpResponseMessage response = null;
            using (var client = CreateClient())
            {
                try
                {
                    response = await client.SendAsync(requestMsg);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    exception.Data.Add("API", requestMsg.RequestUri);
                    exception.Data.Add("Method", requestMsg.Method.Method);
                }
            }

            if (exception != null)
                throw new Exception("请求API的过程中发生异常！", exception);

            result = new Models.Response();
            try
            {
                result.OriginData = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                exception = ex;
                exception.Data.Add("API", requestMsg.RequestUri);
                exception.Data.Add("Status", response.StatusCode);
                exception.Data.Add("ContentType", response.Content.Headers.ContentType);
                exception.Data.Add("ContentLength", response.Content.Headers.ContentLength);
            }


            if (exception != null)
                throw new Exception("获取接口返回内容时发生异常！", exception);

            return result;
        }

        private static string GetUrl<TResponse>(this Models.Request<TResponse> request, string url) where TResponse : Models.Response
        {
            var nvs = request.GetPropertyStringValue(true);
            if (nvs.Count > 0)
            {
                foreach (var key in nvs.AllKeys)
                {
                    url += $"{url}&{key}={BaiduHelper.UrlEncode(nvs[key])}";
                }
            }

            return url;
        }

        /// <summary>
        /// 以 Get 形式请求接口
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="AK"></param>
        /// <param name="SK"></param>
        /// <returns></returns>
        internal static async Task<TResponse> GetAsync<TResponse>(this Models.Request<TResponse> request, string AK, string SK)
            where TResponse : Models.Response
        {
            TResponse result = default;

            NameValueCollection querys = request.GetPropertyStringValue();
            querys.Add("ak", AK);
            var url = BaiduHelper.GetSNUrl(request.URL, AK, SK, querys);

            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {
                requestMsg.Method = HttpMethod.Get;
                requestMsg.RequestUri = new Uri(url);
                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }

            return result;
        }


        internal static async Task<TResponse> GetWithoutSNAsync<TResponse>(this Models.Request<TResponse> request, string AK)
            where TResponse : Models.Response
        {
            TResponse result = default;

            NameValueCollection querys = request.GetPropertyStringValue();
            querys.Add("ak", AK);
            string url = request.URL + "?";

            foreach (var key in querys.AllKeys)
            {
                url = url + $"{key}={BaiduHelper.UrlEncode(querys[key])}&";
            }

            url = url.Substring(0, url.Length - 1);

            using (HttpRequestMessage requestMsg = new HttpRequestMessage())
            {
                requestMsg.Method = HttpMethod.Get;
                requestMsg.RequestUri = new Uri(url);
                result = await requestMsg.SendAndGetResultAsync<TResponse>();
            }


            return result;
        }

        private static async Task<TResponse> SendAndGetResultAsync<TResponse>(this HttpRequestMessage requestMsg)
            where TResponse : Models.Response
        {
            Exception exception = null;
            HttpResponseMessage response = null;
            using (var client = CreateClient())
            {
                try
                {
                    response = await client.SendAsync(requestMsg);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    exception.Data.Add("API", requestMsg.RequestUri);
                    exception.Data.Add("Method", requestMsg.Method.Method);
                }
            }

            if (exception != null)
                throw new Exception("请求API的过程中发生异常！", exception);

            TResponse result = await response.ReadToModelAsync<TResponse>();
            return result;
        }

        private static async Task<TResponse> ReadToModelAsync<TResponse>(this HttpResponseMessage response)
            where TResponse : Models.Response
        {
            TResponse result = default;
            Exception exception = null;
            string json = "";
            try
            {
                json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json)) result = json.FromJson<TResponse>();
                else result = Activator.CreateInstance<TResponse>();
            }
            catch (Exception ex)
            {
                exception = ex;
                exception.Data.Add("JSON", json);
                result = Activator.CreateInstance<TResponse>();
            }
            finally
            {
                result.OriginData = json;
            }

            if (exception != null)
                throw new Exception("解析JSON的过程中发生异常！", exception);

            return result;
        }
    }
}
