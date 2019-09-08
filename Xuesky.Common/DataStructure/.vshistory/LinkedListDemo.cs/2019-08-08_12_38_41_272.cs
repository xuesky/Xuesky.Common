using System.Collections.Generic;

namespace Xuesky.Common.DataStructure
{
    public static class LinkedListDemo
    {
        public static int Namee
        {
            get
            {

                return name;
            }
            set
            {
                if (value > 1)
                {
                }
            }
        }
        static LinkedList<string> linkList = new LinkedList<string>();


        static LinkedListDemo()
        {

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
