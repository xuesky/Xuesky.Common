using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Xuesky.Common.MongoDB
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
