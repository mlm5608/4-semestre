﻿
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Domains
{
    public class Product
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        public Dictionary<string, string> AdditonalAtributes{ get; set; }

        public Product()
        {
            AdditonalAtributes = new Dictionary<string,string>();
        }
    }
}
