using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Xuesky.Common.Mongo
{
    public class Book : EntityBase
    {

        [BsonElement("Name")]
        public string BookName { get; set; }

        [MongoDbField(true, Ascending = true)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(BookName)}={BookName}, {nameof(Price)}={Price.ToString()}, {nameof(Category)}={Category}, {nameof(Author)}={Author}, {nameof(Id)}={Id}}}";
        }
    }
}
