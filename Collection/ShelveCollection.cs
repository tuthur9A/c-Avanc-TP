using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Collection
{
    /// <summary>
    /// Shelves relation collection
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ShelveCollection
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Unique identifier
        /// </summary>
        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier
        /// </summary>
        [BsonElement("bookIds")]
        [Required]
        public IEnumerable<string> BookIds { get; set; }
    }
}
