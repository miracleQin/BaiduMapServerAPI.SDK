using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    public class JsonConverterAttribute : StringConverterAttribute
    {
        public override string GetString(object value)
        {
            if (value == null) return null;
            else return value.ToJson();
        }
    }
}
