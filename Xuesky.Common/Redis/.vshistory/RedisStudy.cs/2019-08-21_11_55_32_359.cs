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
                    DefaultDatabase = 0,
                    EndPoints = {
                        { "192.168.16.129", 6379 }
                    }
                }
                );
            db = server.GetDatabase(0);
        }
        public void SetString()
        {
            var dic = new Dictionary<RedisKey, RedisValue>
            {
                ["station"] = "站点",
                ["city"] = "城市",
                ["province"] = "省"
            };
            db.StringSetAsync(dic.ToArray());
        }
        public (string, string, string) GetString()
        {
            string station = db.StringGetAsync("station").Result;
            string city = db.StringGetAsync("city").Result;
            string province = db.StringGetAsync("province").Result;
            return (station, city, province);
        }

        public void SetList()
        {
            db.ListLeftPushAsync("list", "list1");
            db.ListLeftPushAsync("list", "list2");
            db.ListLeftPushAsync("list", "list3");
            db.ListRightPushAsync("list", "list4");
        }
        public void GetList()
        {
            var result = db.ListRangeAsync("list", 0, 10).Result;
        }

        public void SetHash()
        {
            db.HashSetAsync("hash", new HashEntry[] {
                new HashEntry("h1", "h1"),
                new HashEntry("h2", "h2"),
                new HashEntry("h3", "h3")
            });
        }
        public void GetHash()
        {
            var result = db.HashGetAllAsync("hash").Result;
        }

        public void SetSet()
        {
            db.SetAdd("set", new RedisValue[] { "set1", "set2", "set3" });
        }
        public void GetSet()
        {
            var result = db.SetMembersAsync("set").Result;
            db
        }

    }
}
