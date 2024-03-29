﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xuesky.Common.DataStructure;
using Xuesky.Common.Models;
using Xuesky.Common.Mongo;
using Xuesky.Common.Other;
using Xuesky.Common.Pattern;
using Xuesky.Common.Redis;
using Xuesky.Common.SqlServerListener;

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
        private static void Main(string[] args)
        {
            /* Func<AsyncCallback, object, Task<string>> func = async (call, o) =>
             {
                using (var httpClient = new HttpClient())
                {
                    return await httpClient.GetStringAsync("http://localhost:8081");
                }
             };
             var taskAsync = Task.Factory.FromAsync(func(asyn =>
             {
                Console.WriteLine(asyn.AsyncState);
             }, "我是AsyncState参数"), ar =>
             {
                Console.WriteLine(ar.AsyncState);
                ((Task<string>)ar).ContinueWith(s => Console.WriteLine(s.Result));
                Console.WriteLine("EndInvoke执行完了");
             });
             RedisStudy redis = new RedisStudy();
             redis.SetSet();
             redis.GetSet();
             //var ty = typeof(Program).Module;
             ////new Reflection.MyReflection().BaseMethod();
             //object obj = new StudentDto();
             //var res = obj as StudentDto;
             //new MyReflection().BaseMethod();
             //Expression<Func<Student, Student>> expression = s => s;
             //var ssss = ExpressionCommon.presson(expression);

             Stopwatch watch = new Stopwatch();
             watch.Start();
             //Console.WriteLine("********************开始监测执行时间**********************");
             //dynamic ss = new System.Dynamic.ExpandoObject();
             //ss = "test";
             //Console.WriteLine("********************字典排序**********************");
             ////字典
             //Dict.DictTest dictTest = new Dict.DictTest();
             //dictTest.DictOrder();
             //Console.WriteLine("********************JSON业务处理**********************");
             ////JSON
             //Json.JsonResolve jsonResolve = new Json.JsonResolve();
             //Console.WriteLine("********************C#7新特性**********************");
             ////C#7新特性
             //C7.Features features = new C7.Features();
             //var (name, age) = features.GetUserInfo();
             //Console.WriteLine($"多值返回，name:{name},age:{age}");

             //Console.WriteLine("********************值注入**********************");
             ////值注入
             //Dto dto = new Dto();
             //dto.DtoTest();

             ////获取JSON配置文件
             //new Config().GetJsonConfig();

             //委托
             //Delet.DeleAndThread deleg = new Delet.DeleAndThread();

             //文件流读取
             //MyStream.FileStreamReadFile();
             //FileInfoDemo fileDemo = new FileInfoDemo();
             //DirectoryInfoDemo directoryInfoDemo = new DirectoryInfoDemo();
             //FileDemo fileDemo = new FileDemo();
             //FileStreamDemo fileStreamDemo = new FileStreamDemo();
             // StreamReaderAndWriter streamReaderAndWriter = new StreamReaderAndWriter();
             //MyStream.FileStreamReadFile();
             //new ImplInterface().PersonPay();

             ////Lamda
             //LamdaTest.UserSelectMany();
             //string path =Path.Combine("a", "b", "c");

             //var dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));

             //var enumTest = new EnumTest();


             //Console.WriteLine($"Token值为:{CreateToken.GetToken("xuesky", "123456", "admin")}");



             //Console.WriteLine($"执行时间为:{watch.ElapsedMilliseconds}ms");

             //YieldTest.PrintSudentList();

             LinkedListDemo.ss();
             watch.Stop();
             var ints = new int[] { 1, 2, 3 };
             var obj = ints;
             var bl = obj as IEnumerable;
             System.Console.WriteLine(bl);

             JObject jObject = JObject.Parse("{\"data\":[{\"code\":0,\"fee\":1,\"mobile\":13700630633,\"msg\":\"成功\",\"sid\":\"cd911d5f-4a40-42a1-97e2-313625d8f860\",\"uid\":1234}],\"total_fee\":1}");
             JToken jToken = jObject["data"][0];
             string sid = jToken["sid"].ToString();
             Console.WriteLine(sid);

             new ListenerSqlServer();
             var formData = URLHelper.QueryToFormUrlEncoded("name=xuesky&age=38&sex=0");

             new MongoDbTest();

             System.Console.WriteLine("**********************Pattern***********************");
             new FactoryMethod();
             new Observer();
 */
            var stu = new Student()
            {
                id = "123"
            };
            var stuList = new List<Student>{
                stu
            };
            stuList.Add(stu);
           var pdf =  Path.ChangeExtension("hello.txt","pdf");
            Console.WriteLine("Fork");
            Console.ReadLine();
        }
    }

}
