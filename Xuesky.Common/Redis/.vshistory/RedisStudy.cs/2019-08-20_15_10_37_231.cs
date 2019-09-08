using StackExchange.Redis;

namespace Xuesky.Common.Redis
{
    public class RedisStudy
    {
        private static ConnectionMultiplexer server;

        public RedisStudy()
        {
            server = ConnectionMultiplexer.Connect(""
            //    new ConfigurationOptions
            //{
            //    Ssl = false,
            //    SslHost = "127.0.0.1",
            //    DefaultDatabase = 0,

            //}
                );

        }
    }
}
