using System;
using System.IO;

namespace Xuesky.Common.IOAndStream
{
    public class FileStreamDemo
    {
        public FileStreamDemo()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");
            //创建文件流
            FileStream fileStream = File.Open(path, FileMode.Open);
            //fileStream = new FileStream(path, FileMode.Open);

            //数据容器
            byte[] bytes = new byte[1024];

            int length = fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Seek(6, SeekOrigin.End);
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine(bytes[i]);
            }
            while (true)//read.Position < read.Length
            {
                int count = fileStream.Read(bytes, 0, bytes.Length);
                if (count == 0)
                {
                    Console.WriteLine("数据读取完毕");
                    break;
                }
            }
            var path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "1.png");

            var readerStream = File.Open(path2, FileMode.Open);

            var writerStream = File.Create("1副本.png");

            //数据容器
            byte[] data = new byte[1024];

            while (true)
            {
                int length2 = readerStream.Read(data, 0, data.Length);
                if (length2 == 0)
                {
                    Console.WriteLine("complete");
                    break;
                }
                writerStream.Write(data, 0, data.Length);
            }
            readerStream.Close();
            writerStream.Close();
        }
    }
}
