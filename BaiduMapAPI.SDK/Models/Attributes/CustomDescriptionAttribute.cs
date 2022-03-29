using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 自定义值描述
    /// </summary>
    public class CustomDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// 自定义值描述
        /// </summary>
        /// <param name="description">描述</param>
        /// <param name="value">值</param>
        public CustomDescriptionAttribute(string description, object value) : base(description) 
        {
            this.Value = value;
        }

        /// <summary>
        /// 自定义值
        /// </summary>
        public object Value { get; private set; }


    }
}
