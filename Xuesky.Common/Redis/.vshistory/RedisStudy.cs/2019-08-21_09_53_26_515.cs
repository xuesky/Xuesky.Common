using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

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
                    SslHost = "192.168.16.128:6379",
                    DefaultDatabase = 0,
                    EndPoints =
                },
                );
            db = server.GetDatabase(0);
        }
        public void SetInfo()
        {
            var dic = new Dictionary<RedisKey, RedisValue>
            {
                ["station"] = "站点",
                ["city"] = "城市",
                ["province"] = "省"
            };
            db.StringSetAsync(dic.ToArray());
        }
        public (string, string, string) GetInfo()
        {
            string station = db.StringGetAsync("station").Result;
            string city = db.StringGetAsync("city").Result;
            string province = db.StringGetAsync("province").Result;
            return (station, city, province);
        }
    }
}
