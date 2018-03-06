using System;
using System.Collections.Generic;
using System.Text;
using Xuesky.Common.Interface;
using Xuesky.Common.Models;

namespace Xuesky.Common.ToInterface
{
   public class ImplInterface
    {
        public void PersonPay()
        {
            Console.WriteLine("************************接口实现*****************************");
            Animal animal = new Person("xuesky",10,s=> s + s);
            var animalGo = animal.Go("aaaaaaaaaaa");
            var pay = (IPay)animal;
            pay.Pay(1);
            IPay iPay = new Person();
            iPay.Pay(2);
        }
    }
}
