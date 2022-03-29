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
        public override string GetString(object value)
        {
            string result = null;

            var nvs = value.GetPropertyStringValue();
            List<KeyValuePair<string, string>> kvs = new List<KeyValuePair<string, string>>();
            foreach (var key in nvs.AllKeys)
            {
                kvs.Add(new KeyValuePair<string, string>(key, nvs[key]));
            }

            result = string.Join("|", kvs.Select(s => $"{s.Key}:{s.Value}"));

            return result;
        }
    }
}
