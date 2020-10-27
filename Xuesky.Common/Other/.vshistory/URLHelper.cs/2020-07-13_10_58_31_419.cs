using System;
using System.Collections.Generic;
using System.Linq;

namespace Xuesky.Common.Other
{
    public static class URLHelper
    {
        public static Tuple<string, IEnumerable<KeyValuePair<string, string>>> UrlToFormUrlEncoded(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            url = url.Trim();
            try
            {
                var split = url.Split(new[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 1)
                    return new Tuple<string, IEnumerable<KeyValuePair<string, string>>>(url, null);
                //获取前面的URL地址
                var host = split[0];
                var pairs = split.Skip(1).Select(s =>
                {
                    //没有用String.Split防止某些少见Query String中出现多个=，要把后面的无法处理的=全部显示出来
                    var idx = s.IndexOf('=');
                    return new KeyValuePair<string, string>(Uri.UnescapeDataString(s.Substring(0, idx)), Uri.UnescapeDataString(s.Substring(idx + 1)));

                }).ToList();

                return new Tuple<string, IEnumerable<KeyValuePair<string, string>>>(host, pairs);

            }
            catch (Exception ex)
            {
                throw new FormatException("URL格式错误", ex);
            }
        }
    }
}
