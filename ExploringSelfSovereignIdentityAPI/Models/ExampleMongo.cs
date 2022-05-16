using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExploringSelfSovereignIdentityAPI.Models
{
    [BsonIgnoreExtraElements]
    public class ExampleMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("age")]
        public int age { get; set; }
    }
}
