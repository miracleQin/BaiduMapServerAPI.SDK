using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace BaiduMapAPI.Models.Attributes
{
    /// <summary>
    /// 列表对象转换器
    /// </summary>
    public class ListModelFieldOderStringConverterAttribute : StringConverterAttribute
    {
        /// <summary>
        /// 获取字符串格式结果
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string GetString(object value)
        {
            if (value == null) return null;
            var list = (List<object>)value;

            var propertyInfos = list[0].GetType().GetProperties();

            PropertyInfo[] pros = new PropertyInfo[propertyInfos.Length];

            List<PropertyInfo> unOrderProperties = new List<PropertyInfo>();

            foreach (var item in propertyInfos)
            {
                var display = item.GetCustomAttribute<DisplayAttribute>();

                if (display != null && display.Order > 0)
                {
                    pros[display.Order] = item;
                }
                else unOrderProperties.Add(item);
            }

            foreach (var item in unOrderProperties)
            {
                for (int i = 0; i < pros.Length; i++)
                {
                    if (pros[i] == null)
                    {
                        pros[i] = item;
                        break;
                    }
                }
            }

            List<string> result = new List<string>();

            foreach (var item in list)
            {
                if (item != null)
                {
                    List<string> itemResult = new List<string>();

                    foreach (var pro in pros)
                    {
                        if (pro != null)
                        {
                            itemResult.Add(pro.GetValue(item) + "");
                        }
                    }
                    if (itemResult.Count > 0)
                        result.Add(string.Join(",", itemResult));
                }
            }

            return result.ToJson();
        }
    }
}
