using System;
using System.Collections.Generic;
using System.Text;

namespace Xuesky.Common.Attribute
{
   public class OldClass
    {

        [method: Obsolete("该方法已经过时")]
        public void OldMethod()
        {
            
            Console.WriteLine("过时的方法！");
        }
        public void OldMethod(string name)
        {

            Console.WriteLine($"{name}过时的方法！");
        }
        [return: SomeAttr]
        int Method3() { return 0; }
        [System.AttributeUsage(AttributeTargets.ReturnValue)]
        private class SomeAttrAttribute : System.Attribute
        {
        }

    }
}
