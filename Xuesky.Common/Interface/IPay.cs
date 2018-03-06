using System;
using System.Collections.Generic;
using System.Text;

namespace Xuesky.Common.Interface
{
    public interface IPay
    {
        /// <summary>
        /// 消费
        /// </summary>
        void Pay(int i = 0);
    }
}