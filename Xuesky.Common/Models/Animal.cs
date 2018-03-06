using System;

namespace Xuesky.Common.Models
{
    /// <summary>
    /// 动物
    /// </summary>
    public abstract class Animal
    {
        public string Name { get; set; } = "动物名称";
        public int Age { get; set; } = 0;

        public Func<string,string> Go { get; set; }

        public void Call()
        {
            Console.WriteLine("动物吼叫");
        }
        public abstract void Hello(string Name = null);
        public abstract void Eat();
    }
}