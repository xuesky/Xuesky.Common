using System;
using Xuesky.Common.Interface;

namespace Xuesky.Common.Models
{
    public class Person : Animal, IPay
    {
        public Person()
        {
        }

        public Person(string name, int age, Func<string, string> go)
        {
            Name = name;
            Age = age;
            Go = go;
        }

        public string Company { get; set; }

        /// <summary>
        ///     消费
        /// </summary>
        public void Pay(int i)
        {
            Console.WriteLine($"{i}:人是要花钱的");
        }

        public override void Eat()
        {
            Console.WriteLine("人吃馒头");
        }

        public override void Hello(string name = null)
        {
            throw new NotImplementedException();
        }
    }
}