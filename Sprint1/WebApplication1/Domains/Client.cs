using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication1.Domains
{
    public class Client
    {

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("Cpf")]
        public string? Cpf { get; set; }

        [BsonElement("Phone")]
        public string? Phone { get; set; }
        
        [BsonElement("Address")]
        public string? Address { get; set; }

        public Dictionary<string, string> AdditonalAtributes { get; set; }

        public Client()
        {
            AdditonalAtributes = new Dictionary<string, string>();
        }
    }
}
