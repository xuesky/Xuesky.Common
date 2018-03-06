using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xuesky.Common.Interface;

namespace Xuesky.Common.Reflection
{
    public class Reflection
    {
        public void BaseMethod()
        {
            Assembly assembly = System.Reflection.Assembly.LoadFrom("MyLib");
            Type type = assembly.GetType("MyLib.GetUserInfo");
            MethodInfo[] methods = type.GetMethods();
            foreach (var item in methods)
            {
                List<string> para = new List<string>();
                ParameterInfo[] parameterInfo = item.GetParameters();
                foreach (var p in parameterInfo)
                {
                    para.Add(p.Name + "," + p.ParameterType);
                }
                Console.WriteLine($"方法名称:{item.Name},方法参数名称:{string.Join(',', para)}");
            }
            var oa = Activator.CreateInstance(type, "薛小锋");
            var o = (IGetUserInfo)oa;
            o.GetName();
        }
    }
}
