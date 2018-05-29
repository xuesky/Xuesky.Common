using System;
using System.Collections.Generic;
using Xuesky.Common.Interface;

namespace Xuesky.Common.Models
{
    public class Person : Animal, IPay
    {
        public Person()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "", "" }
            };
        }

        public Person(string name, int age, Func<string, string> go)
        {
            Name = name;
            Age = age;
            Go = go;
        }
        public (string name,int age) UserNameAndAge()
        {
            return ("sdfsd", 20);
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
        /// <summary>
        /// hello
        /// </summary>
        /// <param name="name">name</param>
        public override void Hello(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            throw new NotImplementedException();
        }
    }
}