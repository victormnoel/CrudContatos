using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CrudContatos.Models
{
    public class Contato
    {
        //[BsonId]
        //[JsonProperty("id")]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
