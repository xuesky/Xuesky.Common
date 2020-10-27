using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using Xuesky.Common.Interface;
using Xuesky.Common.Models;

namespace Xuesky.Common.Reflection
{
    public class MyReflection
    {

        public void BaseMethod()
        {
            ZipFile.CreateFromDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "123.zip"));
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().ToList();
            //var moudules = assembly.GetModules();
            //moudules.ToList().ForEach(m =>
            //{
            //    Console.WriteLine(m.Name);
            //});
            var cls = types.Where(s => s.IsAssignableFrom(typeof(Person))).ToArray();
            Type type = assembly.GetType("MyLib.GetUserInfo");

            object attributes = type.GetCustomAttributes(true);
            MethodInfo[] methods = type.GetMethods();
            foreach (var item in methods)
            {
                List<string> para = new List<string>();
                var parameterInfo = item.GetParameters();
                foreach (var p in parameterInfo)
                {
                    para.Add(p.Name + "," + p.ParameterType);
                }
                Console.WriteLine($"方法名称:{item.Name},方法参数名称:{string.Join(',', para)}");
            }
            var oa = Activator.CreateInstance(type, "薛小锋");
            var o = (IGetUserInfo)oa;
            o.GetName();
            //TODO 待定
        }
    }
}
