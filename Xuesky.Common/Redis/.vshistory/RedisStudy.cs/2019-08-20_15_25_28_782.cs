using StackExchange.Redis;
using System.Collections.Generic;

namespace Xuesky.Common.Redis
{
    public class RedisStudy
    {
        private static ConnectionMultiplexer server;
        static IDatabase db;

        static RedisStudy()
        {
            server = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    Ssl = false,
                    SslHost = "127.0.0.1:6379",
                    DefaultDatabase = 0,
                }
                );
            db = server.GetDatabase(0);
        }
        public void SetInfo()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                ["station"] = "站点",
                ["city"] = "城市",
                ["province"] = "省"
            };
            Dictionary<string, string> UseFor = dictionary;
            db.StringSetAsync("", "");
        }
    }
}
