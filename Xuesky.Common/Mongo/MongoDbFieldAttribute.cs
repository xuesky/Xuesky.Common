using System;

namespace Xuesky.Common.Mongo
{
    /// <summary>
    /// Mongodb数据库的字段特性  主要是设置索引之用
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MongoDbFieldAttribute : System.Attribute
    {
        /// <summary>
        /// 是否是索引
        /// </summary>
        public bool IsIndex { get; set; }

        /// <summary>
        /// 是否是唯一的  默认flase
        /// </summary>
        public bool Unique { get; set; }

        /// <summary>
        /// 是否是升序 默认true
        /// </summary>
        public bool Ascending { get; set; }

        public MongoDbFieldAttribute(bool _isIndex)
        {
            this.IsIndex = _isIndex;
            this.Unique = false;
            this.Ascending = true;
        }
    }
}
