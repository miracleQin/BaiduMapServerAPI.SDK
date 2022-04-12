using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 参数属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class QueryParameterAttribute : Attribute
    {
        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// 参数属性
        /// </summary>
        /// <param name="ParameterName"></param>
        public QueryParameterAttribute(string ParameterName)
        {
            this.ParameterName = ParameterName;
        }
    }
}
