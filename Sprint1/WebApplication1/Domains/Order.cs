﻿using MongoDB.Bson.Serialization.Attributes;
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
        public string? Status { get; set; }

        [BsonElement("ProductId")]
        public List<string>? ProductIds { get; set; }
        public List<Product>? Products { get; set; }


        [BsonElement("ClientId")]
        public string? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
