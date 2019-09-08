using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Xuesky.Common.IOAndStream
{
    public class DirectoryInfoDemo
    {
        public DirectoryInfoDemo()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            Console.WriteLine($"路径是否存在:{directoryInfo.Exists}");
            Console.WriteLine($"路径Parent:{directoryInfo.Parent}");
            Console.WriteLine($"路径Root:{directoryInfo.Root}");

            directoryInfo.CreateSubdirectory("aaaaa");
            directoryInfo.Delete();

        }
    }
}
