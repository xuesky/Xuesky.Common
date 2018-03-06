using System;
using System.Collections.Generic;
using System.Text;

namespace Xuesky.Common.Models
{
    public class Article : IComparable<Article>
    {
        public string Title { private get; set; }
        public int Comments { private get; set; }

        public int SortIndex { private get; set; }
        public override string ToString()
        {
            return $"{Title}，{Comments}";
        }

        public int CompareTo(Article other)
        {
            if (other == null)
                return 1;
            int value = this.SortIndex - other.SortIndex;
            if (value == 0)
                value = this.Comments - other.Comments;
            return value;
        }
    }
}
