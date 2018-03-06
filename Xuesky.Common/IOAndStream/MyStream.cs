using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Xuesky.Common.IOAndStream
{
    public class MyStream
    {
        public static string FileStreamReadFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");
            FileStream file = new FileStream(filePath, FileMode.Open);
            //每次读取的字节数
            var clen = 16;
            byte[] data = new byte[clen];
            char[] charData = new char[clen];
            file.Seek(0, SeekOrigin.Begin);
            //读入两百个字节
            file.Read(data, 0, clen);
            //提取字节数组
            Decoder dec = Encoding.UTF8.GetDecoder();
            dec.GetChars(data, 0, data.Length, charData, 0);
            Console.WriteLine("通过FileStreamReadFile读出的数据：{0}", new String(charData));
            return "";
        }
        public static string StreamReaderReadFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");
            StreamReader file = new StreamReader(filePath);
            //每次读取的字节数
            var clen = 3;
            char[] buffer = new char[clen];
            int count = file.Read(buffer, 0, clen);
            var result = "";
            while (count > 0)
            {
                var str = new String(buffer, 0, clen);
                result += str;
                count = file.Read(buffer, 0, clen);
            }
            Console.WriteLine("通过StreamReaderReadFile读出的数据：{0}", result);
            return result;
        }
    }
}
