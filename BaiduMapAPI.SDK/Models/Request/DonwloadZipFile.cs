using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Models
{
    /// <summary>
    /// 下载 ZIP 文件并解析结果
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class DonwloadZipFile<TResponse> : Request<TResponse>
        where TResponse : Response
    {

        /// <summary>
        /// 当前是否可获取结果
        /// </summary>
        /// <returns></returns>
        protected abstract bool CanGetResult();

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <returns></returns>
        public virtual List<TResponse> GetResult()
        {
            return GetResultAsync().Result;
        }


        /// <summary>
        /// 以异步方式获取结果
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">处理过程中发生的异常信息</exception>
        public virtual async Task<List<TResponse>> GetResultAsync()
        {
            List<TResponse> result = null;

            Stream downloadStream = null;//下载下来的 ZIP 文件流
            Dictionary<string, Stream> zipSubItems = null; //ZIP 解压结果
            Exception exception = null;// 处理流程中发生的异常信息
            string mediaType = ""; //下载文件的媒体类型

            //若当前不可获取结果，则直接跳转到结束锚点
            if (!CanGetResult()) goto End;

            try
            {

                //下载文件流
                using (var response = await HttpHelper.GetResponseMessageAsync(this.URL))
                {
                    mediaType = response.Content.Headers.ContentType.MediaType;
                    using (var stream = await response.Content.ReadAsStreamAsync())
                        downloadStream = await stream.CloneAsync();
                }

            }
            catch (Exception ex)
            {
                exception = new Exception("下载文件时发生异常！", ex);
                exception.Data["MediaType"] = mediaType;
                goto End;
            }

            try
            {

                //文件流解压缩
                zipSubItems = await downloadStream.DescodeAsync();

            }
            catch (Exception ex)
            {
                exception = new Exception("解压文件流的时候发生异常！", ex);
                exception.Data["MediaType"] = mediaType;
                goto End;
            }

            try
            {
                result = new List<TResponse>();
                //子文件转 JSON 对象
                foreach (var kv in zipSubItems)
                {
                    //解析文本每行信息并转 JSON
                    using (StreamReader reader = new StreamReader(kv.Value, Encoding.UTF8))
                    {
                        foreach (var line in (await reader.ReadToEndAsync()).Split(new string[] { "\r\n", "\n\r", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var model = line.FromJson<TResponse>() ?? Activator.CreateInstance<TResponse>();
                            model.OriginData = line;
                            result.Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                exception = new Exception("读取解压内容并转换行实体时发生异常！", ex);
                exception.Data["MediaType"] = mediaType;
                goto End;
            }

        End:;

            if (downloadStream != null) downloadStream.Dispose();
            if (zipSubItems != null)
            {
                foreach (var item in zipSubItems.Values) item.Dispose();
                zipSubItems.Clear();
            }
            if (exception != null)
            {
                throw new Exception("获取结果的过程中发生异常！", exception);
            }
            return result;
        }
    }
}
