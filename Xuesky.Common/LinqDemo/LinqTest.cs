using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Xuesky.Common.LinqDemo
{
    public class LinqTest
    {
       static List<Bouquet> bouquets = new List<Bouquet>()
            {
        new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
        new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
        new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
        new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            };
        /// <summary>
        /// Select() 和 SelectMany() 的工作都是依据源值生成一个或多个结果值。Select() 为每个源值生成一个结果值。因此，总体结果是一个与源集合具有相同元素数目的集合。与之相反，SelectMany() 将生成单一总体结果，其中包含来自每个源值的串联子集合。作为参数传递到 SelectMany() 的转换函数必须为每个源值返回一个可枚举值序列。然后，SelectMany() 将串联这些可枚举序列以创建一个大的序列。
        /// </summary>
        public static void Select()
        {
            // *********** Select ***********            
            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

        }

        public static void SelectMany()
        {
            // ********* SelectMany *********
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

        }




        private class Bouquet
        {
            public List<string> Flowers { get; internal set; }
        }
    }
}
