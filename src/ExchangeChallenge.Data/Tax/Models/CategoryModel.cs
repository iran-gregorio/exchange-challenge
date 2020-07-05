using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExchangeChallenge.Data.Tax.Models
{
    public class CategoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("tax")]
        public decimal Tax { get; set; }
    }
}
