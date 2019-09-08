using StackExchange.Redis;

namespace Xuesky.Common.Redis
{
    public class RedisStudy
    {
        private static ConnectionMultiplexer server;

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
        }
        public void SetInfo()
        {
            server.
        }
    }
}
