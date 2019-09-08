using System.Collections.Generic;
namespace Xuesky.Common.DataStructure
{
    public class LinkedListDemo
    {

        LinkedList<string> linkList = new LinkedList<string>();

        public LinkedListDemo()
        {
            linkList.AddFirst("h1");
            linkList.AddFirst("h2");
            linkList.AddBefore("h3");
        }

    }
}
