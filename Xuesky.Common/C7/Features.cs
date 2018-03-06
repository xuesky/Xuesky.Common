using System;
using System.Collections.Generic;
using System.Text;

namespace Xuesky.Common.C7
{
    public class Features
    {
        public (string name,int age) GetUserInfo()
        {
            Console.WriteLine("*******************多值返回(string name,int age)******************");
            return (name: "xuesky", age: 123);
        }
    }
}
