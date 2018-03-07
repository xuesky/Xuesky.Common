using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xuesky.Common.Dict
{
    /// <summary>
    /// 字典数据测试类
    /// </summary>
    public class DictTest
    {
        public void DictOrder()
        {
            Console.WriteLine("**********************字典类数据排序****************************");

            //初始方式一
            var dic = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
            //方式二
            var dict = new Dictionary<string, string>
            {
                {"sss","1122300" },
                {"app_id", "123"},
                {"method", "alipay.system.oauth.token"},
                {"charset", "GBK"},
                {"sign_type", "RSA"},
                {"timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                {"code", "code"},
                {"grant_type", "1"},
                {"version", "1.0"},
                {"refresh_token", ""}
            };
            var dic1Asc = dict.Where(s => !string.IsNullOrEmpty(s.Value)).OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

            StringBuilder sb = new StringBuilder();
            foreach (var s in dic1Asc)
            {
                sb.Append(s.Key).Append("=").Append(s.Value).Append("&");
            }
            Console.WriteLine($"排序后的字典值为:{sb.ToString()}");

            Console.WriteLine(dic.Values.Contains(2)?"该值存在":"该值不存在");
        }
    }
}
