using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Xuesky.Common.Reflection
{
    public class EmitHelper
    {

        public void  HelloEmit()
        {
            Type[] args = { typeof(string) };
            DynamicMethod method = new DynamicMethod("HelloEmit", typeof(string), args,typeof(string).Module);
            //method.defi
        }
    }
}
