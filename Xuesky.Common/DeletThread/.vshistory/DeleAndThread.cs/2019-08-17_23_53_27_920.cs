using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Xuesky.Common.Delet
{
    public delegate void Dosomething(string name);
    public class DeleAndThread
    {
        public DeleAndThread()
        {
            Console.WriteLine("****************************委托执行测试*****************************************");
            var action2 = new Action<string, int>(Dosomething1);
            action2("我是带参数的委托Action", 1);
            var action3 = new Action(() => Dosomething1("", 0));
            Expression<Func<int, int, int, int>> expr = (x, y, z) => (x + y) / z;
            Console.WriteLine($"表达式Expression<Func<int, int, int, int>>执行结果:{expr.Compile()(1, 2, 3)}");

            Dosomething method1 = t => Console.WriteLine($"我是实现委托的方法,{t}");
            method1.Invoke("delegate");

            Task<int> Act(int i) => new Asynctest().LoadCache(i);
            Task<int> result = Act(10);
            Console.WriteLine("************************异步委托*****************************");
            result.ContinueWith(t => Console.WriteLine("异步调用完成后的最终返回计算结果为：{0}", t.Result.ToString()));

            Func<string, string> method2 = GetSomething2;
            string result1 = method2("xuesky");

            //以下Core不支持
            var s1 = method2.BeginInvoke("xuesky", t => Console.WriteLine($"异步回调,当前线程{Thread.CurrentThread.ManagedThreadId}"), "age");
            //var result2 = method2.EndInvoke(s1);
            //Console.WriteLine($"当前线程{Thread.CurrentThread.ManagedThreadId},异步返回值为{result1}");
            //以下Core不支持
            Func<string, int, (string, int)> method = GetSomething;
            //var ss = method.BeginInvoke("xuesky", 1, t => Console.WriteLine($"异步回调,当前线程{Task.CurrentId}"), "age");

            Console.WriteLine("************************多线程*****************************");
            Task task = new Task(t => { Console.WriteLine($"我是多线程:{t},线程ID为:{Thread.CurrentThread.ManagedThreadId}"); }, 5);
            task.Start();
            var t1 = Task.Factory.StartNew(DoSomething);
            var t2 = Task.Factory.StartNew(DoSomething);
            var t3 = Task.Factory.StartNew(DoSomething);
            var t4 = Task.Factory.StartNew(DoSomething);
            var t5 = Task.Factory.StartNew(DoSomething);
            var t6 = Task.Factory.StartNew(DoSomething);
            Console.WriteLine("是否主动释放DbContext（y/n）");
            var yes = Console.ReadLine();
            Console.WriteLine("请输入模拟并发量");
            var number = Console.ReadLine();
            SemaphoreSlim sem = new SemaphoreSlim(int.Parse(number));
            var j = 0;
            while (j < 1000)
            {
                Console.WriteLine("启动第" + j++ + "个线程");

                sem.Wait();
                var t7 = new TaskFactory().StartNew(() =>
                {
                    Console.WriteLine($"多线程执行，线程ID：{Thread.CurrentThread.ManagedThreadId}");
                });
            }
        }

        private static (string name, int age) GetSomething(string name, int age) => (name, age);
        public static int DoSomething()
        {
            Object obj = new object();
            lock (obj)
            {
                Console.WriteLine($"我是来处理事情的，doSomething,线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }
            return 1;
        }
        private static void Dosomething1(string str, int i)
        {
            Console.WriteLine(str);
        }
        private static string GetSomething2(string name) => name;
    }
}
