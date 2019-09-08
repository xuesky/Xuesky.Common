using System;
using System.Collections.Generic;

namespace Xuesky.Common.DataStructure
{
    public static class LinkedListDemo
    {
        static string name;
        static LinkedList<string> linkList = new LinkedList<string>();

        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="System.IO.IOException"></exception>
        static LinkedListDemo()
        {
            Action action = new Action(() => System.Console.WriteLine());
            object obj = null;
            Action callback = new Action(() => { });
            action.BeginInvoke(callback, obj);
            linkList.AddFirst("h1");
            linkList.AddAfter(linkList.Find("h1"), "h2");
            linkList.AddBefore(linkList.Find("h2"), "h3");
        }
        public static void ss()
        {
            foreach (var item in linkList)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
