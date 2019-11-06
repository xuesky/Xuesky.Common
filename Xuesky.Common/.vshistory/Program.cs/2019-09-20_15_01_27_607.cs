﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xuesky.Common
{
    internal class Program
    {
        private static string SALT_FORMAT = "$_n{0}_jJ3mF)";
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        private static async Task Main(string[] args)
        {
            Console.WriteLine("hello");
            Func<AsyncCallback, object, Task<string>> func = async (call, o) =>
             {
                 using (var httpClient = new HttpClient())
                 {
                     Console.WriteLine(o);
                     return await httpClient.GetStringAsync("http://localhost:8081");
                 }
             };
            var taskAsync = Task.Factory.FromAsync(async (call, o) =>
            {
                using (var httpClient = new HttpClient())
                {
                    Console.WriteLine(o);
                    return await httpClient.GetStringAsync("http://localhost:8081");
                }
            }, ar =>
              {
                  ((Task<string>)ar).ContinueWith(s => Console.WriteLine(s.Result));
                  Console.WriteLine("EndInvoke执行完了");
              }, "hello AsyncState");
            Console.WriteLine("我是下一步的操作");
            Console.ReadLine();
            //RedisStudy redis = new RedisStudy();
            //redis.SetSet();
            //redis.GetSet();
            ////var ty = typeof(Program).Module;
            //////new Reflection.MyReflection().BaseMethod();
            ////object obj = new StudentDto();
            ////var res = obj as StudentDto;
            ////new MyReflection().BaseMethod();
            ////Expression<Func<Student, Student>> expression = s => s;
            ////var ssss = ExpressionCommon.presson(expression);

            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            ////Console.WriteLine("********************开始监测执行时间**********************");
            ////dynamic ss = new System.Dynamic.ExpandoObject();
            ////ss = "test";
            ////Console.WriteLine("********************字典排序**********************");
            //////字典
            ////Dict.DictTest dictTest = new Dict.DictTest();
            ////dictTest.DictOrder();
            ////Console.WriteLine("********************JSON业务处理**********************");
            //////JSON
            ////Json.JsonResolve jsonResolve = new Json.JsonResolve();
            ////Console.WriteLine("********************C#7新特性**********************");
            //////C#7新特性
            ////C7.Features features = new C7.Features();
            ////var (name, age) = features.GetUserInfo();
            ////Console.WriteLine($"多值返回，name:{name},age:{age}");

            ////Console.WriteLine("********************值注入**********************");
            //////值注入
            ////Dto dto = new Dto();
            ////dto.DtoTest();

            //////获取JSON配置文件
            ////new Config().GetJsonConfig();

            ////委托
            ////Delet.DeleAndThread deleg = new Delet.DeleAndThread();

            ////文件流读取
            ////MyStream.FileStreamReadFile();
            ////FileInfoDemo fileDemo = new FileInfoDemo();
            ////DirectoryInfoDemo directoryInfoDemo = new DirectoryInfoDemo();
            ////FileDemo fileDemo = new FileDemo();
            ////FileStreamDemo fileStreamDemo = new FileStreamDemo();
            //// StreamReaderAndWriter streamReaderAndWriter = new StreamReaderAndWriter();
            ////MyStream.FileStreamReadFile();
            ////new ImplInterface().PersonPay();

            //////Lamda
            ////LamdaTest.UserSelectMany();
            ////string path =Path.Combine("a", "b", "c");

            ////var dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));

            ////var enumTest = new EnumTest();


            ////Console.WriteLine($"Token值为:{CreateToken.GetToken("xuesky", "123456", "admin")}");



            ////Console.WriteLine($"执行时间为:{watch.ElapsedMilliseconds}ms");

            ////YieldTest.PrintSudentList();

            //LinkedListDemo.ss();
            //watch.Stop();
            Console.ReadLine();
        }
    }
}