using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xuesky.Common.Interface
{
    public interface IBase<Entity> where Entity : class, new()
    {
    }
}