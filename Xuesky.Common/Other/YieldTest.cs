using System;
using System.Collections.Generic;
using System.Text;
using Xuesky.Common.Lamda;

namespace Xuesky.Common.Other
{
   public static class YieldTest
    {
        public static void PrintSudentList()
        {
            foreach (Student student in GetSudentList())
                Console.WriteLine(student.Score);
        }
        private static IEnumerable<Student> GetSudentList()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new Student(i);
            }
        }
    }
}
