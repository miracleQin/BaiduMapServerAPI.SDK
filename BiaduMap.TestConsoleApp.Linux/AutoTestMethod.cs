using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BiaduMap.TestConsoleApp.Linux
{
    /// <summary>
    /// 自动测试方法
    /// </summary>
    internal static class AutoTestMethod
    {
        /// <summary>
        /// 注释文件辅助工具
        /// </summary>
        private static XmlCommentHelper xmlHelper;

        internal static void Init()
        {
            xmlHelper = new XmlCommentHelper();


            //程序集
            var assembly = typeof(BaiduMapAPI.Models.Bound).Assembly;

            var folder = System.IO.Path.GetDirectoryName(assembly.Location);
            var fileName = System.IO.Path.GetFileNameWithoutExtension(assembly.Location);
            xmlHelper.Load(System.IO.Path.Combine(folder, $"{fileName}.xml"));


            //获取所有请求类
            List<Type> allReqeustTypes = GetAllRequstTypes(assembly);

            int maxLength = allReqeustTypes.Max(s => s.FullName?.Length ?? 0);

            Dictionary<string, string> apiTypeInfos = new Dictionary<string, string>();

            foreach (var type in allReqeustTypes.OrderBy(s => s.Namespace).ThenBy(s => s.Name))
            {
                string[] comments = xmlHelper.GetTypeComment(type).GetComments();
                apiTypeInfos[type.FullName.PadRight(maxLength, ' ')] = comments[0];
                //Console.WriteLine($"{type.FullName.PadRight(maxLength, ' ')} | [{comments[0]}]");
            }

            Type? selectType = null;
        ReTest:;
            Console.WriteLine("请选择下列类型来进行测试：");
            int showIndex = 1;
            var format = $"D{apiTypeInfos.Count.ToString().Length}";
            Console.WriteLine("序号 | 类全名 | 类描述");
            foreach (var kv in apiTypeInfos)
            {
                Console.WriteLine($"{(showIndex++).ToString(format)} | {kv.Key} | {kv.Value}");
            }
            Console.WriteLine("===============================");
            var typeName = GetInputString("请输入全类名:").Trim();

            selectType = allReqeustTypes.FirstOrDefault(s => s.FullName == typeName);
            if (selectType == null)
                goto ReTest;

            var invokeResult = SetValueAndInvoke(selectType);

            ShowResult(invokeResult);
            Console.WriteLine("------结果打印完毕------");
            if (GetInputBool("是否重新测试？", "Y", "N"))
                goto ReTest;
        }

        #region 设值并调用

        /// <summary>
        /// 设值并调用
        /// </summary>
        /// <param name="selectType"></param>
        /// <returns></returns>
        private static object SetValueAndInvoke(Type? selectType)
        {
            var method = selectType.GetMethod("GetResult");
            object[] parameterValues = GetMethodParameterValues(method);//函数参数值

            var model2 = SetTypeValue(selectType);

            Console.WriteLine("------即将发起请求-------");
            var returnValue = method.Invoke(model2, parameterValues);
            Console.WriteLine("------请求发起结束-------");

            return returnValue;
        }

        #region 属性设值

        /// <summary>
        /// 设置指定类型的值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object SetTypeValue(Type type, string preName = "")
        {
            object result = null;

            //外层类型
            var type_releaType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            //值类型
            var type_valueType = type.IsGenericType ? type.GetGenericArguments()[0] : type;

        SetValue:;
            if (type_valueType.IsEnum)
            {
                ShowEnumFields(type_valueType);
            }

            if (type.IsClass && !type.IsGenericType && type != typeof(string))
            {
                result = SetCustomClassValue(type, string.IsNullOrEmpty(preName) ? "request" : preName);
            }
            else if (type_releaType == typeof(List<>))
            {
                result = SetListValue(type, type_valueType, preName);
            }
            else if (type_releaType == typeof(Dictionary<,>))
            {
                result = SetDictionaryValue(type, preName);
            }
            #region 基元类型设值

            else if (type_valueType == typeof(string))
            {
                Console.Write($"请输入数值:");
                string? val;
                if (string.IsNullOrEmpty(val = Console.ReadLine())) goto SetValue;
                result = val + "";
            }
            else if (type_valueType == typeof(int))
            {
                Console.Write($"请输入数值:");
                int val;
                if (!int.TryParse(Console.ReadLine(), out val)) goto SetValue;
                result = val;
            }
            else if (type_valueType == typeof(double))
            {
                Console.Write($"请输入数值:");
                double val;
                if (!double.TryParse(Console.ReadLine(), out val)) goto SetValue;
                result = val;
            }
            else if (type_valueType == typeof(bool))
            {
                Console.Write($"请输入数值[Y/N]:");
                bool val;
                if ((Console.ReadLine() + "").Equals("y", StringComparison.CurrentCultureIgnoreCase)) val = true;
                else if((Console.ReadLine() + "").Equals("n", StringComparison.CurrentCultureIgnoreCase)) val = false;
                else goto SetValue;
                result = val;
            }
            else if (type_valueType == typeof(DateTime))
            {
                Console.Write($"请输入数值:");
                DateTime val;
                if (!DateTime.TryParse(Console.ReadLine(), out val)) goto SetValue;
                result = val;
            }
            else if (type_valueType == typeof(float))
            {
                Console.Write($"请输入数值:");
                float val;
                if (!float.TryParse(Console.ReadLine(), out val)) goto SetValue;
                result = val;
            }
            else if (type_valueType.IsEnum)
            {
                Console.Write($"请输入数值:");
                object val;
                if (!Enum.TryParse(type_valueType, Console.ReadLine(), out val)) goto SetValue;
                result = val;
            }

            #endregion
            else //未知类型，先抛异常出来，后续追加设值类型的处理
            {
                var ex = new NullReferenceException("当前类型数据设值逻辑尚未有处理机制！");
                ex.Data.Add("Type", type);
                ex.Data.Add("ReleaType", type_releaType);
                ex.Data.Add("ValueType", type_valueType);
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 设置字典类型的值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object SetDictionaryValue(Type type, string preName)
        {
            object result = Activator.CreateInstance(type);
            var addMethod = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);
            var ContainsKeyMethod = type.GetMethod("ContainsKey", BindingFlags.Public | BindingFlags.Instance);
            //var Remove = type.GetMethod("Remove", BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("即将设置字典项");
            var types = type.GetGenericArguments();
            int index = 0;
            do
            {
                Console.WriteLine($"请设置字典项的键\r\n{preName}[{index}].Key:");
                var key = SetTypeValue(types[0], $"{preName}[{index}].Key");
                var hasKey = (bool)ContainsKeyMethod.Invoke(result, new object[] { key });

                if (hasKey)
                {
                    Console.WriteLine("该键已设置过！请勿重复设置！");
                }
                else
                {
                    Console.WriteLine($"请设置字典项的值\r\n{preName}[{index}].Value:");
                    var value = SetTypeValue(types[1], $"{preName}[{index}].Value");
                    index++;
                    addMethod.Invoke(result, new object[] { key, value });
                }
            } while (GetInputBool("\r\n是否继续添加字典项？", "Y", "N"));
            return result;
        }

        /// <summary>
        /// 设值列表类型数值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="type_valueType"></param>
        /// <returns></returns>
        private static object SetListValue(Type type, Type type_valueType, string preName)
        {
            object result = Activator.CreateInstance(type);
            var addMethod = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("即将设置列表数据：");
            int index = 0;
            do
            {
                Console.WriteLine($"添加 {preName}[{index}]");
                var item = SetTypeValue(type_valueType, $"{preName}[{index}]");
                index++;
                addMethod.Invoke(result, new object[] { item });
            }
            while (GetInputBool("是否继续添加列表项？", "Y", "N"));
            return result;
        }

        /// <summary>
        /// 设值自定义类型数值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object SetCustomClassValue(Type type, string preName)
        {
            object result = Activator.CreateInstance(type);
            //取可写的实例化属性
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(s => s.CanWrite);
            //循环属性赋值
            foreach (var property in properties)
            {
                //外层类型
                var releaType = property.PropertyType.IsGenericType ? property.PropertyType.GetGenericTypeDefinition() : property.PropertyType;
                //值类型
                var valueType = property.PropertyType.IsGenericType ? property.PropertyType.GetGenericArguments()[0] : property.PropertyType;

                var comments = xmlHelper.GetFieldOrPropertyComment(property).GetComments();
                Console.WriteLine($"--------\r\n给属性赋值\r\n{string.Join("\r\n    ", comments)}\r\n[{preName}.{property.Name}]({valueType.Name})");

                if (
                      (releaType == typeof(List<>) || releaType == typeof(Nullable<>) || releaType == typeof(Dictionary<,>) || !valueType.IsValueType) &&
                      !GetInputBool($"是否设置 [{preName}.{property.Name}]({valueType.Name}) 的值?", "Y", "N")
                  )
                {
                    continue;
                }

                var val = SetTypeValue(property.PropertyType, $"{preName}.{property.Name}");
                property.SetValue(result, val);
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 获取函数参数值
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private static object[] GetMethodParameterValues(MethodInfo? method)
        {
            var parameters = method.GetParameters();

            object[] parameterValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                Console.Write($"请给参数 {parameter.Name}[{parameter.ParameterType.Name}] 设值：");
                parameterValues[i] = Console.ReadLine() + "";
            }
            return parameterValues;
        }

        #endregion

        #region 显示结果

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="result"></param>
        private static void ShowResult(object result, string preStr = "response")
        {
            var resultType = result.GetType();
            var realType = resultType.IsGenericType ? resultType.GetGenericTypeDefinition() : resultType;
            var valueType = resultType.IsGenericType ? resultType.GetGenericArguments()[0] : resultType;

            if (!resultType.IsGenericType && !resultType.IsValueType && resultType != typeof(string))
            {
                var properties = resultType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(s => s.CanRead);
                foreach (var property in properties)
                {
                    var pValue = property.GetValue(result);
                    if (pValue == null) Console.WriteLine($"{preStr}.{property.Name} -> [null]");
                    else ShowResult(pValue, $"{preStr}.{property.Name}");
                }
            }
            else if (realType == typeof(List<>))
            {
                var GetEnumeratorMethod = resultType.GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);
                IEnumerator enumerator = (IEnumerator)GetEnumeratorMethod.Invoke(result, null);

                int index = 0;

                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (item == null)
                        Console.WriteLine($"{preStr}[{index}] -> [null]");
                    else
                        ShowResult(enumerator.Current, $"{preStr}[{index}]");
                    index++;
                }

            }
            else if (realType == typeof(Dictionary<,>))
            {
                var GetEnumeratorMethod = resultType.GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);
                IEnumerator enumerator = (IEnumerator)GetEnumeratorMethod.Invoke(result, null);

                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    var itemType = item.GetType();
                    var keyPro = itemType.GetProperty("Key");
                    var valuePro = itemType.GetProperty("Value");

                    var key = keyPro.GetValue(item);
                    var value = valuePro.GetValue(item);

                    if (value == null)
                        Console.WriteLine($"{preStr}[{key}] -> [null]");
                    else
                        ShowResult(value, $"{preStr}[{key}]");
                }
            }
            else if (valueType.IsEnum)
            {
                var fields = valueType.GetFields(BindingFlags.Public | BindingFlags.Static);

                List<Tuple<int, string, string>> enumItems = new List<Tuple<int, string, string>>();
                foreach (var field in fields)
                {
                    object intVal;
                    if (Enum.TryParse(valueType, field.Name, out intVal))
                    {
                        var description = field.GetCustomAttribute<DescriptionAttribute>();
                        enumItems.Add(new Tuple<int, string, string>((int)intVal, field.Name, description?.Description ?? ""));
                    }

                }

                bool isFlagEnum = !enumItems.Any(s => (s.Item1 % 2 != 0 && s.Item1 != 1) || (s.Item1 == 0));

                List<string> enumStrs = new List<string>();
                int enumValue = (int)result;
                if (isFlagEnum)
                {

                    foreach (var item in enumItems)
                    {
                        if ((enumValue & item.Item1) == item.Item1)
                        {
                            enumStrs.Add($"[{item.Item2}({item.Item3})]");
                        }
                    }
                }
                else
                {
                    var item = enumItems.FirstOrDefault(s => enumValue == s.Item1);
                    if (item != null)
                        enumStrs.Add($"[{item.Item2}({item.Item3})]");
                }
                Console.WriteLine($"{preStr} -> {string.Join("、", enumStrs)}");
            }
            else //if (valueType.IsValueType || valueType == typeof(string) || valueType.IsEnum)
            {
                Console.WriteLine($"{preStr} -> [{result}]");
            }
        }

        #endregion

        /// <summary>
        /// 获取所有请求类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private static List<Type> GetAllRequstTypes(Assembly assembly)
        {
            var baseRequestType = typeof(BaiduMapAPI.Models.Request<>);
            var allTypes = assembly.GetTypes();
            //var allReqeustTypes = assembly.GetTypes().Where(s => s.IsDefined(baseRequestType) && !s.IsAbstract);

            List<Type> allReqeustTypes = new List<Type>();
            allReqeustTypes.Add(baseRequestType);

            Func<Type, bool> condition = s =>
                        allReqeustTypes.Any(t => (s.BaseType.IsGenericType && t == s.BaseType.GetGenericTypeDefinition()) || s.BaseType == t)
                         && !allReqeustTypes.Any(t => t == s);

            while (allTypes.Any(condition))
            {
                var findTypes = allTypes.Where(condition);
                allReqeustTypes.AddRange(findTypes);
            }

            allReqeustTypes = allReqeustTypes.Where(s => !s.IsAbstract).ToList();
            return allReqeustTypes;
        }

        private static string[] GetComments(this string comment)
        {
            return comment.Replace("<br>", "\r\n").Split(new string[] { "\r\n", "\n\r", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取输入的 bool 值
        /// </summary>
        /// <param name="text"></param>
        /// <param name="yesValue"></param>
        /// <param name="noValue"></param>
        /// <returns></returns>
        private static bool GetInputBool(string text, string yesValue, string noValue)
        {
        Retry:
            Console.Write($"{text}[{yesValue}/{noValue}]:");

            var val = Console.ReadLine() + "";

            if (val.Equals(yesValue, StringComparison.InvariantCultureIgnoreCase)) return true;
            else if (val.Equals(noValue, StringComparison.InvariantCultureIgnoreCase)) return false;
            else goto Retry;
        }

        /// <summary>
        /// 获取输入的 string 值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string GetInputString(string text)
        {
            Console.Write(text);
            return Console.ReadLine() + "";
        }

        private static void ShowEnumFields(Type enumType)
        {
            var fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);


            List<Tuple<int, string, string>> items = new List<Tuple<int, string, string>>();
            foreach (var field in fields)
            {
                var item = Enum.Parse(enumType, field.Name);
                var description = field.GetCustomAttribute<DescriptionAttribute>(true);
                //Console.WriteLine($"    [{(int)item}|{item}] {description?.Description}");

                items.Add(new Tuple<int, string, string>((int)item, item.ToString() ?? "", description?.Description ?? ""));
            }

            var numberLength = items.Max(s => s.Item1).ToString().Length;
            var nameLength = items.Max(s => s.Item2.Length);
            numberLength = numberLength > 4 ? numberLength : 4;
            nameLength = nameLength > 4 ? nameLength : 4;

            Console.WriteLine($"可选范围(填写数值或名称):\r\n    数值{"".PadRight(numberLength - 4, ' ')} | 名称{"".PadRight(nameLength - 4, ' ')} | 描述");

            foreach (var item in items)
            {
                Console.WriteLine($"    {item.Item1.ToString().PadRight(numberLength, ' ')} | {item.Item2.PadRight(nameLength, ' ')} | {item.Item3}");
            }
        }
    }
}
