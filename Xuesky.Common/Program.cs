using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Xuesky.Common.Configuration;
using Xuesky.Common.DTO;
using Xuesky.Common.Enums;
using Xuesky.Common.IOAndStream;
using Xuesky.Common.JWT;
using Xuesky.Common.Lamda;
using Xuesky.Common.Models;
using Xuesky.Common.Other;
using Xuesky.Common.ToInterface;


namespace Xuesky.Common
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            object obj = new StudentDto();
            var res = obj as StudentDto;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("********************开始监测执行时间**********************");
            dynamic ss = new System.Dynamic.ExpandoObject();
            ss = "test";
            Console.WriteLine("********************字典排序**********************");
            //字典
            Dict.DictTest dictTest = new Dict.DictTest();
            dictTest.DictOrder();
            Console.WriteLine("********************JSON业务处理**********************");
            //JSON
            Json.JsonResolve jsonResolve = new Json.JsonResolve();
            Console.WriteLine("********************C#7新特性**********************");
            //C#7新特性
            C7.Features features = new C7.Features();
            var userInfo = features.GetUserInfo();
            Console.WriteLine($"多值返回，name:{userInfo.name},age:{userInfo.age}");

            Console.WriteLine("********************值注入**********************");
            //值注入
            Dto dto = new Dto();
            dto.DtoTest();
            //获取JSON配置文件
            new Config().GetJsonConfig();
            //委托
            //Delet.DeleAndThread deleg = new Delet.DeleAndThread();
            //文件流读取
            MyStream.FileStreamReadFile();

            new ImplInterface().PersonPay();
            //Lamda
            LamdaTest.UserSelectMany();
            string path =Path.Combine("a", "b", "c");


            Students students = new Students {ClassName = "12班"};
            var xml = XmlSerialize(students);

            var dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));

            var enumTest = new EnumTest();
            

            Console.WriteLine($"Token值为:{CreateToken.GetToken("xuesky", "123456", "admin")}");

            watch.Stop();

            Console.WriteLine($"执行时间为:{watch.ElapsedMilliseconds}ms");

            YieldTest.PrintSudentList();

            Console.ReadLine();
        }
        private static string XmlSerialize(object o)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            System.IO.MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            ser.Serialize(writer, o, ns);
            writer.Close();
            return Encoding.UTF8.GetString(mem.ToArray());
        }
    }
}