using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BiaduMap.TestConsoleApp.Linux
{
    /// <summary>
    /// 辅助类
    /// </summary>
    public static class OtherHelper
    {

        public static string? GetDescription<TEnum>(this TEnum? tag)
            where TEnum : struct
        {
            return tag.HasValue ? tag.Value.GetDescription() : null;
        }


        public static string GetDescription<TEnum>(this TEnum tag)
            where TEnum : struct
        {
            string result = tag + "";


            var enumType = tag.GetType();
            var field = enumType.GetField(result);
            var description = field.GetCustomAttribute<DescriptionAttribute>();
            if (description != null)
            {
                result = description.Description;
            }


            return result;
        }
    }
}
