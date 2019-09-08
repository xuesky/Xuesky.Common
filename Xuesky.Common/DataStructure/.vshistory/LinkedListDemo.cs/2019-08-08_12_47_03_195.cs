using System.Collections.Generic;

namespace Xuesky.Common.DataStructure
{
    public static class LinkedListDemo
    {
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


        public static int GetMyProperty(DependencyObject obj)
        {
            return (int)obj.GetValue(MyPropertyProperty);
        }

        public static void SetMyProperty(DependencyObject obj, int value)
        {
            obj.SetValue(MyPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("MyProperty", typeof(int), typeof(ownerclass), new PropertyMetadata(0));



    }
}
