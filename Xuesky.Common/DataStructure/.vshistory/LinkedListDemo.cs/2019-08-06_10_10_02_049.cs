﻿using System.Collections.Generic;
namespace Xuesky.Common.DataStructure
{
    public static class LinkedListDemo
    {

        static LinkedList<string> linkList = new LinkedList<string>();

        static LinkedListDemo()
        {
            linkList.AddFirst("h1");
            linkList.AddAfter(new LinkedListNode<string>("h1"), "h2");
            //linkList.AddBefore(linkList.Find("h2"), "h3");
        }
        public static void ss()
        {

        }

    }
}
