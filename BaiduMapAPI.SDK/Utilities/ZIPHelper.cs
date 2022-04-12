using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiduMapAPI.Utilities
{
    /// <summary>
    /// ZIP 压缩包辅助类
    /// </summary>
    internal static class ZIPHelper
    {
        /// <summary>
        /// 解压缩压缩包文件
        /// </summary>
        /// <param name="zipStream"></param>
        /// <returns></returns>
        internal static async Task<Dictionary<string, Stream>> DescodeAsync(this Stream zipStream)
        {
            Dictionary<string, Stream> result = new Dictionary<string, Stream>();
            Exception exception = null;

            using (System.IO.Compression.ZipArchive zipArchive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                try
                {
                    foreach (var entity in zipArchive.Entries)
                    {
                        var key = entity.FullName;

                        Stream stream = null;
                        using (var entityStream = entity.Open())
                        {
                            stream = await entityStream.CloneAsync();
                        }

                        result.Add(key, stream);
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (exception != null)
                throw new Exception("解压缩的过程中发生异常！", exception);

            return result;
        }

        /// <summary>
        /// 解压缩压缩包文件
        /// </summary>
        /// <param name="zipStream"></param>
        /// <returns></returns>
        internal static Dictionary<string, Stream> Descode(this Stream zipStream) 
        {
            return zipStream.DescodeAsync().Result;
        }
    }
}
