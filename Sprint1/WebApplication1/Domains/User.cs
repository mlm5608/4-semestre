using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication1.Domains
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("Password")]
        public string? Password { get; set; }

        public Dictionary<string, string> AdditonalAtributes { get; set; }

        public User()
        {
            AdditonalAtributes = new Dictionary<string, string>();
        }
    }
}
