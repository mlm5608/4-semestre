using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication1.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Status")]
        public bool Status { get; set; }

        [BsonElement, BsonRepresentation(BsonType.Array)]
        public List<string> ProdutoIds { get; set; } = new List<string>();

        [BsonElement, BsonRepresentation(BsonType.Array)]
        public List<Product> Produtos { get; set; } = new List<Product>();
    }
}
