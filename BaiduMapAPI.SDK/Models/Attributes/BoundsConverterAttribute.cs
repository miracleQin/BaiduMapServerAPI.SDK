using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    public class BoundsConverterAttribute : StringConverterAttribute
    {
        public override string GetString(object value)
        {
            if (value == null) return null;
            var b = (Bound)value;

            return $"{b.TopLeft.Lat},{b.TopLeft.Lng},{b.BottonRight.Lat},{b.BottonRight.Lng}";
        }
    }
}
