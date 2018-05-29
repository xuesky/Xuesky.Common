using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xuesky.Common.Models
{
    public class Students
    {
        public string ClassName { get; set; }
        public Students() => stus = new List<Student>
            {
                new Student {fname = "wushuangqi1",lname=",last", id = "1"},
                new Student {fname = "wushuangqi",lname=",last", id = "2"},
                new Student {fname = "lingyuan",lname=",last", id = "2"}
            };

        public List<Student> stus { get; set; }
    }

    /// <summary>
    /// 测试类
    /// </summary>
    public class Nametest
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string id { get; set; }
    }

    /// <summary>
    /// 数据传输DTO
    /// </summary>
    public class StudentDto
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public static class MyHelp
    {
        public static List<Student> MySelect(this Students ss, Func<List<Student>, List<Student>> func)
        {
            return func?.Invoke(ss.stus);
        }
    }
}