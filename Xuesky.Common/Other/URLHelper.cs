using System;
using System.Collections.Generic;
using System.Linq;

namespace Xuesky.Common.Other
{
    public static class URLHelper
    {
        public static IEnumerable<KeyValuePair<string, string>> QueryToFormUrlEncoded(string query)
        {
            if (query == null)
                throw new ArgumentNullException("url");
            query = query.Trim();
            try
            {
                var split = query.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                var pairs = split.Select(s =>
                {
                    //没有用String.Split防止某些少见Query String中出现多个=，要把后面的无法处理的=全部显示出来
                    var idx = s.IndexOf('=');
                    return new KeyValuePair<string, string>(Uri.UnescapeDataString(s.Substring(0, idx)), Uri.UnescapeDataString(s.Substring(idx + 1)));

                }).ToList();

                return pairs;

            }
            catch (Exception ex)
            {
                throw new FormatException("URL格式错误", ex);
            }
        }
    }
}
