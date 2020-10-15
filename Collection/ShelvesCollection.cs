using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Collection
{
    /// <summary>
    /// Shelves relation collection
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ShelvesCollection
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
        [BsonElement("book_id")]
        [Required]
        public string BookId { get; set; }
    }
}
