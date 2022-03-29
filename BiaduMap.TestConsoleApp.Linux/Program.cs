using System;


public static class Program
{
    public static void Main(string[] args) 
    {
        // See https://aka.ms/new-console-template for more information
        //Console.WriteLine("Hello, World!");


        //Console.WriteLine("这是第一个自定义输出");

        //Console.Write("请输入字符:");
        //var inputStr = Console.ReadLine();

        //Console.WriteLine($"您输入的字符为：{inputStr}");

        Console.WriteLine("==================");
        MainMethodHelper.Init(typeof(Test), args);

    }
}
