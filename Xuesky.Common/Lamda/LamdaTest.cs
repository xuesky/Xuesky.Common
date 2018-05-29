using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Xuesky.Common.Lamda
{
   public static class LamdaTest
    {
        static List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher("a",new List<Student>{ new Student(100),new Student(90),new Student(30) }),
            new Teacher("b",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
            new Teacher("c",new List<Student>{ new Student(100),new Student(90),new Student(40) }),
            new Teacher("d",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
            new Teacher("e",new List<Student>{ new Student(100),new Student(90),new Student(50) }),
            new Teacher("f",new List<Student>{ new Student(100),new Student(90),new Student(60) }),
            new Teacher("g",new List<Student>{ new Student(100),new Student(90),new Student(60) })
        };

        public static void UserSelectMany()
        {
            var list = _teachers
                .SelectMany(teacher => teacher.Students, (a, c) => new { a, c })
                .Where(a => a.c.Score < 60)
                .ToList();
            var list1 = _teachers.SelectMany(teacher => new List<string>{"a","b"});
            var list2 = _teachers.Select(teacher => teacher);
            var s = _teachers.Where(teacher => true).Count();
        }
    }
    class Student
    {
        public int Score { get; set; }

        public Student(int score) => this.Score = score;
    }

    class Teacher
    {
        public string Name { get; set; }

        public List<Student> Students;

        public Teacher(string order, List<Student> students)
        {
            this.Name = order;

            this.Students = students;
        }
    }
}
