using System;
using System.IO;

namespace Xuesky.Common.IOAndStream
{
    public class FileInfoDemo
    {
        public FileInfoDemo()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");
            Console.WriteLine($"myfile是否存在:{File.Exists(path)}");

            Console.WriteLine(File.ReadAllText(path));
            FileInfo fileInfo = new FileInfo(path);
            //常用属性
            Console.WriteLine($"文件名为:{fileInfo.Name}");
            Console.WriteLine($"文件字节长度为:{fileInfo.Length}");
            Console.WriteLine($"文件路径:{fileInfo.Directory}");
            Console.WriteLine($"文件是否只读:{fileInfo.IsReadOnly}");
            Console.WriteLine($"文件扩展名:{fileInfo.Extension}");



            //fileInfo.MoveTo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile副本.txt"));
        }
    }
}
