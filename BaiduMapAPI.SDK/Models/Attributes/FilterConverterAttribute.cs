using BaiduMapAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 检索过滤条件转换格式
    /// </summary>
    public class FilterConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 各项拼接字符串
        /// </summary>
        public string ItemSplitStr { get; private set; }
        /// <summary>
        /// 值拼接字符串
        /// </summary>
        public string ValueSplitStr { get; private set; }

        /// <summary>
        /// 检索过滤条件转换格式
        /// </summary>
        public FilterConverterAttribute()
        {
            this.ItemSplitStr = "|";
            this.ValueSplitStr = ":";
        }

        /// <summary>
        /// 检索过滤条件转换格式
        /// <paramref name="ItemSplitStr">各项拼接字符串</paramref>
        /// <paramref name="ValueSplitStr">值拼接字符串</paramref>
        /// </summary>
        public FilterConverterAttribute(string ItemSplitStr, string ValueSplitStr)
        {
            this.ItemSplitStr = ItemSplitStr;
            this.ValueSplitStr = ValueSplitStr;
        }

        /// <summary>
        /// 获取字符串结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            string result = null;

            var nvs = value.GetPropertyStringValue();
            List<KeyValuePair<string, string>> kvs = new List<KeyValuePair<string, string>>();
            foreach (var key in nvs.AllKeys)
            {
                kvs.Add(new KeyValuePair<string, string>(key, nvs[key]));
            }

            result = string.Join(this.ItemSplitStr, kvs.Select(s => $"{s.Key}{this.ValueSplitStr}{s.Value}"));

            return result;
        }
    }
}
