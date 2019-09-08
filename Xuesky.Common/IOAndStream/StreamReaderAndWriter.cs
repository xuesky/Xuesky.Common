using System;
using System.IO;

namespace Xuesky.Common.IOAndStream
{
    public class StreamReaderAndWriter
    {
        public StreamReaderAndWriter()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myfile.txt");
            var streamReader = new StreamReader(File.Open(path, FileMode.Open));
            var streamWriter = new StreamWriter(File.Create("html副本.html"));
            while (true)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("读取完毕");
                    break;
                }
                streamWriter.WriteLine(line);
                Console.WriteLine(line);
            }

            //string str = streamReader.ReadToEnd();
            //Console.WriteLine(str);
            while (true)
            {
                int res = streamReader.Read();
                if (res == -1)
                {
                    Console.Write("字节完毕");
                    break;
                }
                Console.WriteLine((char)res);
            }

            streamReader.Close();
            streamWriter.Close();

        }
    }
}
