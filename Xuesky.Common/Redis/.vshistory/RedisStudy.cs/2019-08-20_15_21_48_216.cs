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
            db.StringSetAsync(new Dictionary<string, string>
            {
                name = "xuesky",
                age = "18",
            });
        }
    }
}
