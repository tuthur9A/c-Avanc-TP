using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Collection
{
    /// <summary>
    /// Shelves relation collection
    /// </summary>
    [BsonIgnoreExtraElements]
    public class IndustryIdentifierCollection
    {

        [BsonElement("type")]
        [Required]
        public string Type { get; set; }

        [BsonElement("identifier")]
        [Required]
        public string Identifier { get; set; }
    }
}
