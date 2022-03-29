using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 控制台程序参数化函数辅助工具
    /// 
    /// </summary>
    public static class MainMethodHelper
    {
        public static void Init(Type type, string[] args)
        {
        Start:;
            var methods = type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            List<MethodDetail> methodDetails = new List<MethodDetail>();
            foreach (var method in methods) methodDetails.Add(new MethodDetail(method));
            if (args.Length > 0)
            {
                var methodName = args[0];
                string[] param = new string[args.Length - 1];
                if (args.Length > 1)
                {
                    for (int i = 1; i < args.Length; i++) param[i - 1] = args[i];
                }
                var inputParameters = param.GetParameters();

                var method = methodDetails.FirstOrDefault(s => s.Name == methodName || s.ShortName == methodName);
                if (method != null)
                {
                    Console.WriteLine($"即将调用 [{method.Name}]");
                    List<object> parameters = new List<object>();
                    foreach (var parameter in method.Parameters)
                    {
                        string[] inputVal = null;

                        if (inputParameters.ContainsKey(parameter.Name) && inputParameters[parameter.Name].Length > 0) inputVal = inputParameters[parameter.Name];
                        else if (inputParameters.ContainsKey(parameter.ShortName) && inputParameters[parameter.ShortName].Length > 0) inputVal = inputParameters[parameter.ShortName];

                        if (inputVal != null && inputVal.Length > 0) parameters.Add(ConvertType(parameter.Type, inputVal));
                        else parameters.Add(null);

                        Console.WriteLine($"  [{parameter.Name}] => {(inputVal == null || inputVal.Length == 0 ? "NULL" : $"[{string.Join("|", inputVal)}]")}");
                    }

                    method.Info.Invoke(null, parameters.ToArray());

                    return;
                }
                else
                {
                    Console.WriteLine($"未找到方法 [{methodName}]");
                }
            }

            ShowMethods(methodDetails);

            Console.WriteLine("---------------------\r\n填写要操作的函数与参数：");
            var inputStr = Console.ReadLine();
            args = inputStr?.Split(' ');
            goto Start;
        }

        private static void ShowMethods(List<MethodDetail> methods)
        {
            var fileName = System.IO.Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);

            StringBuilder msg = new StringBuilder();
            msg.AppendLine("调用方法：");
            msg.AppendLine($"{fileName} <方法名> -<参数1> <参数1值> -<参数2> <参数2值>");
            msg.AppendLine();
            msg.AppendLine();
            msg.AppendLine();



            foreach (var method in methods)
            {
                msg.AppendLine($"-----------[{method.Name}] 方法------------");
                msg.AppendLine();
                msg.AppendLine($"  调用名称：{method.Name}{(!string.IsNullOrEmpty(method.ShortName) ? $" | {method.ShortName}" : "")}");
                msg.AppendLine($"  方法描述：  {method.DisplayName}");
                msg.AppendLine($"  方法备注：{method.Description}");
                msg.AppendLine();
                if (method.Parameters.Count > 0)
                {
                    msg.AppendLine("参数信息：");
                    msg.AppendLine();
                    msg.AppendLine("  调用名 | 类型 | 描述 | 备注");
                    int nameMax = method.Parameters.Max(s => s.Name.GetLength() + s.ShortName.GetLength() + 4);
                    int displayNameMax = method.Parameters.Max(s => s.DisplayName.GetLength());
                    int typeMax = method.Parameters.Max(s => s.TypeName.GetLength());

                    foreach (var parameter in method.Parameters)
                    {
                        var invokName = (parameter.Name + (string.IsNullOrEmpty(parameter.ShortName) ? "" : $" | -{parameter.ShortName}"));
                        msg.AppendLine($"  -{invokName.PadRight(nameMax, ' ')}\t{parameter.TypeName.PadRight(typeMax, ' ')}\t{parameter.DisplayName.PadRight(displayNameMax, ' ')}\t{parameter.Description}");
                    }
                }

                msg.AppendLine();
                msg.AppendLine();
            }


            Console.WriteLine(msg.ToString());
        }

        public static Dictionary<string, string[]> GetParameters(this string[] args)
        {
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();

            //找出参数项
            List<string[]> firstParameters = new List<string[]>();
            List<string> tmp_parameters = new List<string>();
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                    {
                        if (tmp_parameters.Count > 0) firstParameters.Add(tmp_parameters.ToArray());
                        tmp_parameters.Clear();
                        tmp_parameters.Add(args[i].Substring(1, args[i].Length - 1));
                    }
                    else tmp_parameters.Add(args[i]);
                }

                if (tmp_parameters.Count > 0) firstParameters.Add(tmp_parameters.ToArray());

                foreach (var parameters in firstParameters)
                {
                    var key = parameters[0];
                    result[key] = new string[parameters.Length - 1];
                    for (int i = 1; i < parameters.Length; i++)
                    {
                        result[key][i - 1] = parameters[i];
                    }
                }

            }
            return result;
        }
        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetLength(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }
            return tempLen;
        }

        private static object ConvertType(Type type, string[] data)
        {
            object result = null;
            bool isArray = false;
            Type trueType = type;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                trueType = type.GenericTypeArguments[0];
            }
            else if (type.IsArray)
            {
                trueType = type.GetElementType();
                isArray = true;
            }

            if (trueType == typeof(long))
            {

                if (!isArray)
                {
                    long tmp;
                    if (long.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    long[] tmpArray = new long[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        long tmp;
                        if (long.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }

            }
            else if (trueType == typeof(int))
            {
                if (!isArray)
                {
                    int tmp;
                    if (int.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    int[] tmpArray = new int[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        int tmp;
                        if (int.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }
            }
            else if (trueType == typeof(DateTime))
            {
                if (!isArray)
                {
                    DateTime tmp;
                    if (DateTime.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    DateTime[] tmpArray = new DateTime[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        DateTime tmp;
                        if (DateTime.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }
            }
            else if (trueType == typeof(float))
            {
                if (!isArray)
                {
                    float tmp;
                    if (float.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    float[] tmpArray = new float[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        float tmp;
                        if (float.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }
            }
            else if (trueType == typeof(double))
            {
                if (!isArray)
                {
                    double tmp;
                    if (double.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    double[] tmpArray = new double[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        double tmp;
                        if (double.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }
            }
            else if (trueType == typeof(decimal))
            {
                if (!isArray)
                {
                    decimal tmp;
                    if (decimal.TryParse(data[0] + "", out tmp)) result = tmp;
                }
                else
                {
                    decimal[] tmpArray = new decimal[data.Length];
                    for (int i = 0; i < data.Length; i++)
                    {
                        decimal tmp;
                        if (decimal.TryParse(data[i], out tmp)) tmpArray[i] = tmp;
                    }
                    result = tmpArray;
                }
            }
            else if (trueType == typeof(string))
            {
                if (!isArray)
                {
                    result = data[0];
                }
                else
                {
                    result = data;
                }
            }

            return result;
        }


        private class MethodDetail
        {
            internal MethodDetail(MethodInfo methodInfo)
            {
                this.Info = methodInfo;
                this.Name = methodInfo.Name;
                this.ShortName = methodInfo.Name;

                var displayName = methodInfo.GetCustomAttribute<DisplayNameAttribute>();
                var description = methodInfo.GetCustomAttribute<DescriptionAttribute>();
                var display = methodInfo.GetCustomAttribute<DisplayAttribute>();

                if (display != null)
                {
                    this.ShortName = string.IsNullOrEmpty(display.ShortName) ? this.Name : display.ShortName;
                    this.DisplayName = string.IsNullOrEmpty(display.Name) ? "" : display.Name;
                    this.Description = string.IsNullOrEmpty(display.Description) ? "" : display.Description;
                }

                if (displayName != null) this.DisplayName = !string.IsNullOrEmpty(displayName.DisplayName) ? displayName.DisplayName : "";
                if (description != null) this.Description = !string.IsNullOrEmpty(description.Description) ? description.Description : "";

                this.Parameters = new List<ParameterDetail>();
                var parameterInfos = methodInfo.GetParameters();
                if (parameterInfos.Length > 0)
                {
                    foreach (var parametrInfo in parameterInfos)
                    {
                        this.Parameters.Add(new ParameterDetail(parametrInfo));
                    }
                }

            }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public List<ParameterDetail> Parameters { get; set; }
            public MethodInfo Info { get; set; }
        }

        private class ParameterDetail
        {
            internal ParameterDetail(ParameterInfo parameterInfo)
            {
                this.Name = parameterInfo.Name;
                this.Type = parameterInfo.ParameterType;
                this.ShortName = "";
                this.Description = "";
                this.DisplayName = "";

                var displayName = parameterInfo.GetCustomAttribute<DisplayNameAttribute>();
                var description = parameterInfo.GetCustomAttribute<DescriptionAttribute>();
                var display = parameterInfo.GetCustomAttribute<DisplayAttribute>();

                if (display != null)
                {
                    this.ShortName = string.IsNullOrEmpty(display.ShortName) ? "" : display.ShortName;
                    this.DisplayName = string.IsNullOrEmpty(display.Name) ? "" : display.Name;
                    this.Description = string.IsNullOrEmpty(display.Description) ? "" : display.Description;
                }

                if (displayName != null) this.DisplayName = !string.IsNullOrEmpty(displayName.DisplayName) ? displayName.DisplayName : "";
                if (description != null) this.Description = !string.IsNullOrEmpty(description.Description) ? description.Description : "";
            }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public Type Type { get; set; }
            public string TypeName
            {
                get
                {
                    if (Type.IsGenericType && Type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {

                        return $"{Type.GenericTypeArguments[0].Name}?";
                    }

                    return Type.Name;
                }
            }
        }
    }
}
