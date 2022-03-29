using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 列表转换器
    /// </summary>
    public class ListConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 列表分隔符
        /// </summary>
        public string SplitString { get; private set; }

        /// <summary>
        /// 要 UrlEncode 每项的值
        /// </summary>
        public bool EncodeValue { get; private set; }

        /// <summary>
        /// 列表转换器
        /// </summary>
        /// <param name="SplitString">列表分隔符</param>
        /// <param name="EncodeValue">要 UrlEncode 每项的值</param>
        public ListConverterAttribute(string SplitString = ",", bool EncodeValue = true)
        {
            this.SplitString = SplitString;
            this.EncodeValue = EncodeValue;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value == null) return null;
            var list = (List<string>)value;
            return string.Join(SplitString, list.Select(s => EncodeValue ? BaiduMapAPI.Utilities.BaiduHelper.UrlEncode(s) : s));

        }
    }
}
