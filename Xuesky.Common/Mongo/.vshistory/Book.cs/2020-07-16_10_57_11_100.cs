using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Xuesky.Common.Mongo
{
    public class Book : EntityBase
    {

        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
