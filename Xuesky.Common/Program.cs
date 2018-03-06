using System;
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
using Xuesky.Common.Lamda;
using Xuesky.Common.Models;
using Xuesky.Common.ToInterface;


namespace Xuesky.Common
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string test = "|||||";
            string[] arrStrings = test.Split('|');
            Console.WriteLine(arrStrings[0]);
            dynamic ss = new System.Dynamic.ExpandoObject();

            Console.OutputEncoding = Encoding.UTF8;
            DateTime now = DateTime.Now.AddDays(1);
            var week = (int)now.DayOfWeek;
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
            //字典

            Dict.DictTest dictTest = new Dict.DictTest();
            dictTest.DictOrder();
            //JSON
            Json.JsonResolve jsonResolve = new Json.JsonResolve();
            //C#7新特性
            C7.Features features = new C7.Features();
            var userInfo = features.GetUserInfo();
            Console.WriteLine($"多值返回，name:{userInfo.name},age:{userInfo.age}");
            //值注入
            Dto dto = new Dto();
            dto.DtoTest();
            //获取JSON配置文件
            new Config().GetJsonConfig();
            //委托
            //Delet.DeleAndThread deleg = new Delet.DeleAndThread();
            //文件流读取
            MyStream.FileStreamReadFile();

            Console.WriteLine($"我是Main参数值:{String.Join(',', args)}");

            new ImplInterface().PersonPay();
            //Lamda
            LamdaTest.UserSelectMany();
            string path =Path.Combine("a", "b", "c");


            Students students = new Students {ClassName = "12班"};
            var xml = XmlSerialize(students);

            var dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));

            var enumTest = new EnumTest();
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