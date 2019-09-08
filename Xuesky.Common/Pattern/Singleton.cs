using System;

namespace Xuesky.Common.Pattern
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class Singleton
    {
        #region 方式一
        private static Singleton singleton = null;
        private static object objLock = new Object();
        private Singleton() { }
        public static Singleton CreateInstance1()
        {
            if (singleton != null)//保证对象初始化后的所有线程不用等待锁
            {
                lock (objLock)//线程安全，保证只有一个进程可访问
                {
                    if (singleton == null)
                    {
                        singleton = new Singleton();
                    }
                }
            }
            return singleton;
        }
        #endregion

        #region 方式二
        /// <summary>
        /// 采用静态构造函数实现，静态构造函数只会执行一次
        /// </summary>
        static Singleton()
        {
            singleton = new Singleton();
        }
        public static Singleton CreateInstance2()
        {
            return singleton;
        }
        #endregion

        #region 方式三
        /// <summary>
        /// 静态变量第一次使用的时候初始化
        /// </summary>
        private static Singleton singleton2 = new Singleton();
        public static Singleton CreateInstance3()
        {
            return singleton2;
        }
        #endregion

    }
}
