using System;


public static class Program
{
    public static void Main(string[] args)
    {
        int mode = 0;

    SelectMode:;
        Console.WriteLine("==================");
        Console.WriteLine("请选择测试模式：");
        Console.WriteLine("  1. 手动测试（Test 静态类的公共静态函数）。");
        Console.WriteLine("  2. 自动测试（动态选择已实现百度接口的类并手动输入接口参数，然后自动执行并输出接口返回结果）。");
        Console.Write("请选择模式:");
        if (!int.TryParse(Console.ReadLine(), out mode) || mode < 1 || mode > 2) goto SelectMode;

        switch (mode)
        {
            case 1: MainMethodHelper.Init(typeof(Test), args); break;
            case 2: BiaduMap.TestConsoleApp.Linux.AutoTestMethod.Init(); break;
        }

        Console.ReadLine();
    }
}
