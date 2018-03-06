using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Xuesky.Common.Configuration
{
   /// <summary>
   /// .net Core 配置文件操作
   /// </summary>
   public class Config
    {
        /// <summary>
        /// JSON配置文件
        /// </summary>
        public void GetJsonConfig()
        {
            string path = Path.Combine(AppContext.BaseDirectory,"configs\\config.json");
            //方式一
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile(path).Build();
            Console.WriteLine("配置文件port:one值：" + config["port:one"]);

            //方式二
            //Console.WriteLine($"config.json 的内容：{File.ReadAllText(path)}");
            var source = new JsonConfigurationSource() {Optional = false, ReloadOnChange = false};
            var provider = new JsonConfigurationProvider(source);
            provider.Load(new FileStream(path,FileMode.Open));

            provider.TryGet("url", out var url);
            Console.WriteLine($"url={url}");

            provider.TryGet("port:one", out var one);
            Console.WriteLine($"port-one={one}");

            provider.TryGet("port:two", out var two);
            Console.WriteLine($"port0two={two}");
        }
        
    }
}
