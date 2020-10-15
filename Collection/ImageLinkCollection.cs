using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Collection
{
    /// <summary>
    /// Shelves relation collection
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ImageLinkCollection
    {

        [BsonElement("smallThumbnail")]
        [Required]
        public string SmallThumbnail { get; set; }

        [BsonElement("thumbnail")]
        [Required]
        public string Thumbnail { get; set; }
    }
}
