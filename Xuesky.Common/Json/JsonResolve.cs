using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using Xuesky.Common.Models;

namespace Xuesky.Common.Json
{
    public class JsonResolve
    {
        public readonly string FieldName;
        public JsonResolve()
        {
            Console.WriteLine("******************************Json数据处理*******************************");
            JObject j = new JObject { ["name"] = "xuesky" };
            Console.WriteLine($"输出JObject值:{j}");
            List<Article> list = GetArticleList();
            list.Sort();
            foreach (var info in list)
            {
                Console.WriteLine(info);
            }
            //自带JSON类库
            Console.WriteLine($"Core自带JSON类库输出");
            var dic = new Dictionary<string, JsonValue>
            {
                {"a","aa"},
                {"b","bb" }
            };
            var list1 = new Dictionary<int, int>() { };
            //JsonObject jsonObject1 = new JsonObject(new KeyValuePair<string, JsonValue>("aaa",JsonValue.Parse(JsonConvert.SerializeObject(dic))));
            JsonObject jsonObject = new JsonObject(dic);
            var jsonValue = JsonObject.Parse(jsonObject.ToString());
            Console.WriteLine(jsonObject.ToString());

            string ss = @"{ ""alipay_system_oauth_token_response"": {""access_token"": ""publicpBa869cad0990e4e17a57ecf7c5469a4b2"",""user_id"": ""2088411964574197"",""alipay_user_id"": ""20881007434917916336963360919773"",""expires_in"": 300,""re_expires_in"": 300,""refresh_token"": ""publicpB0ff17e364f0743c79b0b0d7f55e20bfc""},""sign"": ""xDffQVBBelDiY/FdJi4/a2iQV1I7TgKDFf/9BUCe6+l1UB55YDOdlCAir8CGlTfa0zLYdX0UaYAa43zY2jLhCTDG+d6EjhCBWsNY74yTdiM95kTNsREgAt4PkOkpsbyZVXdLIShxLFAqI49GIv82J3YtzBcVDDdDeqFcUhfasII=""}";
            var job = JObject.Parse(ss);
            JToken s1 = job.SelectToken("alipay_system_oauth_token_response");
            var id = job.SelectToken("alipay_system_oauth_token_response.user_id");
            var ssss = job.Properties().Any(s => s.Name == "alipay_system_oauth_token_response");
            foreach (var jToken in s1)
            {
                var jp = (JProperty)jToken;
                Console.WriteLine(jp.Name + ":" + jp.Value);
            }
            var sign = job["alipay_system_oauth_token_response"]["access_token"];
            Console.WriteLine($"alipay_system_oauth_token_response:access_token的值为:{sign}");
        }
        public static List<Article> GetArticleList()
        {
            List<Article> source = new List<Article>();
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 100; i > 0; i--)
            {
                var article = new Article()
                {
                    Title = "wenzhang" + i,
                    Comments = random.Next(),
                    SortIndex = random.Next()
                };
                source.Add(article);
            }
            return source;
        }
    }

}
