using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xuesky.Common.Models
{
    public class TextMessage : ReceiveBase
    {
        public string Content { get; set; }
    }
}