using System;
using System.IO;
using System.Text;

namespace Xuesky.Common.IOAndStream
{
    public class FileDemo
    {
        //File类提供创建、复制、删除、移动和打开文件的静态方法，协助创建FileStream对象
        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public FileDemo()
        {
            var directoryPath = Path.Combine(Environment
    .CurrentDirectory);
            var files = Directory
                .GetFiles(directoryPath
                );

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");


            foreach (var item in File.ReadAllLines(path))
            {
                Console.WriteLine(item);
            }


            string str = File.ReadAllTextAsync(path).Result;


            //剪切
            //File.Move(path, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile1.txt"));

            var bytes = File.ReadAllBytes(path);

            var path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile22.txt");
            if (!File.Exists(path))
            {
                File.Create(path2);
            }
            File.WriteAllBytes(path2, bytes);

            File.WriteAllText(path2, $"中国{Environment.NewLine}WriteAllText", Encoding.UTF8);
        }

    }
}
