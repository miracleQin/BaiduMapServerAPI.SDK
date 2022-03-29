using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 属性转字符串工具
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class StringConverterAttribute : Attribute
    {
        /// <summary>
        /// 获取字符串结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract string GetString(object value);
    }
}
