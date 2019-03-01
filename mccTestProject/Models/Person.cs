using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mccTestProject.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Surname")]
        public string Surname { get; set; }

        [BsonElement("Birthday")]
        public string Birthday { get; set; }

        [BsonElement("Nickname")]
        public string Nickname { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
