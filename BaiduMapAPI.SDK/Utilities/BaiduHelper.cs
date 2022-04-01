using BaiduMapAPI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Utilities
{
    /// <summary>
    /// 百度地图辅助工具
    /// </summary>
    internal static class BaiduHelper
    {
        #region 百度地图签名算法

        private static string MD5(string password)
        {
            try
            {
                System.Security.Cryptography.HashAlgorithm hash = System.Security.Cryptography.MD5.Create();
                byte[] hash_out = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var md5_str = BitConverter.ToString(hash_out).Replace("-", "");
                return md5_str.ToLower();
            }
            catch
            {
                throw;
            }
        }
        internal static string UrlEncode(string str)
        {
            str = System.Web.HttpUtility.UrlEncode(str);
            byte[] buf = Encoding.ASCII.GetBytes(str);//等同于Encoding.ASCII.GetBytes(str)
            for (int i = 0; i < buf.Length; i++)
                if (buf[i] == '%')
                {
                    if (buf[i + 1] >= 'a') buf[i + 1] -= 32;
                    if (buf[i + 2] >= 'a') buf[i + 2] -= 32;
                    i += 2;
                }
            return Encoding.ASCII.GetString(buf);//同上，等同于Encoding.ASCII.GetString(buf)
        }

        private static string HttpBuildQuery(NameValueCollection querystring_arrays, bool urlEncoding = true)
        {
            StringBuilder sb = new StringBuilder();

            if (urlEncoding)
            {
                foreach (var key in querystring_arrays.AllKeys)
                {
                    sb.Append(UrlEncode(key));
                    sb.Append("=");
                    sb.Append(UrlEncode(querystring_arrays[key]));
                    sb.Append("&");
                }
            }
            else
            {
                foreach (var key in querystring_arrays.AllKeys)
                {
                    sb.Append(key);
                    sb.Append("=");
                    sb.Append(querystring_arrays[key]);
                    sb.Append("&");
                }
            }


            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 获取签名字符串
        /// </summary>
        /// <param name="ak"></param>
        /// <param name="sk"></param>
        /// <param name="url"></param>
        /// <param name="querystring_arrays"></param>
        /// <param name="urlEncode"></param>
        /// <returns></returns>
        internal static string CaculateAKSN(string ak, string sk, string url, NameValueCollection querystring_arrays, bool urlEncode = true)
        {
            var queryString = HttpBuildQuery(querystring_arrays, urlEncode);

            var str = urlEncode ? UrlEncode(url + "?" + queryString + sk) : $"{url}?{queryString}{sk}";

            return MD5(str);
        }
        /// <summary>
        /// 获取签名URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ak"></param>
        /// <param name="sk"></param>
        /// <param name="query"></param>
        /// <param name="urlEncode"></param>
        /// <returns></returns>
        internal static string GetSNUrl(string url, string ak, string sk, NameValueCollection query, bool urlEncode = true)
        {
            string result = null;
            var uri = new Uri(url);
            string sn = CaculateAKSN(ak, sk, uri.AbsolutePath, query, urlEncode);
            query.Add("sn", sn);
            result = string.Format("{0}?{1}", url, HttpBuildQuery(query, urlEncode));
            return result;
        }

        internal static string GetUrl(string url, NameValueCollection query, bool urlEncode = true)
        {
            string result = null;
            result = string.Format("{0}?{1}", url, HttpBuildQuery(query, urlEncode));
            return result;
        }

        #endregion

        internal static string ToTimestamp(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToTimestamp() : null;
        }

        internal static string ToTimestamp(this DateTime dateTime)
        {
            return ((dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000) + "";
        }

        internal static DateTime FromTimestamp(this long timestamp)
        {
            var tmp = timestamp * 10000000 + 621355968000000000;
            return DateTime.FromFileTimeUtc(tmp).ToLocalTime();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static NameValueCollection GetPropertyStringValue(this object data, bool onlyAttribute = false)
        {
            NameValueCollection result = new NameValueCollection();
            if (data != null)
            {
                var type = data.GetType();

                var properties = type.GetProperties();

                if (onlyAttribute)
                {
                    if (properties.Any(s => s.GetCustomAttribute<QueryParameterAttribute>() != null))
                    {
                        properties = properties.Where(s => s.GetCustomAttribute<QueryParameterAttribute>() != null).ToArray();
                    }
                    else return result;
                }

                foreach (var property in properties.Where(s => s.Name != "URL"))
                {
                    if (property.PropertyType != typeof(Dictionary<string, string>))
                    {
                        var display = property.GetCustomAttribute<DisplayAttribute>();
                        var stringConvert = property.GetCustomAttribute<StringConverterAttribute>(true);

                        string name = display == null ? property.Name : display.Name;
                        var val = property.GetValue(data);
                        string value = stringConvert == null ? val + "" : stringConvert.GetString(val);

                        if (!string.IsNullOrEmpty(value))
                        {
                            result.Add(name, value);
                        }
                    }
                    else
                    {
                        var dic = property.GetValue(data) as Dictionary<string, string>;
                        if (dic != null)
                        {
                            foreach (var kv in dic)
                            {
                                if (!string.IsNullOrEmpty(kv.Value))
                                {
                                    result.Add(kv.Key, kv.Value);
                                }
                            }
                        }
                    }

                }
            }
            return result;
        }

        internal static string ToCss(this System.Drawing.Color? color)
        {
            return color.HasValue ? color.Value.ToCSS() : null;
        }

        internal static string ToCSS(this System.Drawing.Color color)
        {
            return $"0x{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        /// <summary>
        /// 获取枚举自定义描述特性
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumField"></param>
        /// <returns></returns>
        internal static CustomDescriptionAttribute GetCustomDescription<TEnum>(this TEnum? enumField)
            where TEnum : struct
        {
            return enumField == null ? null : enumField.Value.GetCustomDescription();
        }

        /// <summary>
        /// 获取枚举自定义描述特性
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumField"></param>
        /// <returns></returns>
        internal static CustomDescriptionAttribute GetCustomDescription<TEnum>(this TEnum enumField)
            where TEnum : struct
        {
            CustomDescriptionAttribute result = null;
            var enumType = typeof(TEnum);
            var fieldType = enumType.GetField(enumField.ToString());
            result = fieldType.GetCustomAttribute<CustomDescriptionAttribute>();
            return result;
        }
    }
}
