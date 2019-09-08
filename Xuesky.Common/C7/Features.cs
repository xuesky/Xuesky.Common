using System;

namespace Xuesky.Common.C7
{
    public class Features
    {
        /// <summary>
        /// 1.返回多参数，解构函数
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.IO.IOException"></exception>
        public (string name, int age) GetUserInfo()
        {
            Console.WriteLine("*******************多值返回(string name,int age)******************");
            return (name: "xuesky", age: 123);
        }
        /// <summary>
        /// 2.Out参数不必声明了
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="System.IO.IOException"></exception>
        public void TestOut(out string name)
        {
            name = "sdfsdf";
            Console.WriteLine(name);
        }
        /// <summary>
        /// 3。匹配模式
        /// </summary>
        public void PatternMatching()
        {
            object o = 1;
            if (o is int a)
            {
                int b = a + 1;
            }

            switch (o)
            {
                case int b when b < 100:
                    b++;
                    break;
                case string c:
                    c += "is string";
                    break;
                default:
                    o = null;
                    break;

            }
        }
        /// <summary>
        /// 局部函数
        /// 使用隐藏结构取代了隐藏类。这就允许继续存储上一次调用的数据，避免了每次都要实例化对象。与匿名方法一样，局部方法实际存储在隐藏结构中
        /// </summary>
        public void LocalFunction()
        {
            int Add(int a, int b)
            {
                return a + b;
            }
            Add(1, 1);
        }


    }
}
