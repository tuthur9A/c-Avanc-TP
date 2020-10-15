using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TP.Collection
{
    /// <summary>
    /// Books relation collection
    /// </summary>
    [BsonIgnoreExtraElements]
    public class BookCollection 
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        [BsonElement("title")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// list Author.
        /// </summary>
        [BsonElement("authors")]
        [Required]
        public IEnumerable<string> Authors { get; set; }

        /// <summary>
        /// publisher.
        /// </summary>
        [BsonElement("publisher")]
        [Required]
        public string Publisher { get; set; }

        /// <summary>
        /// published Date.
        /// </summary>
        [BsonElement("publishedDate")]
        [Required]
        public string PublishedDate { get; set; }

        /// <summary>
        /// list industry identifiers.
        /// </summary>
        [BsonElement("industryIdentifiers")]
        [Required]
        public IEnumerable<IndustryIdentifierCollection> IndustryIdentifiers { get; set; }

        /// <summary>
        /// page count.
        /// </summary>
        [BsonElement("pageCount")]
        [Required]
        public int PageCount { get; set; }

        /// <summary>
        /// print type.
        /// </summary>
        [BsonElement("printType")]
        [Required]
        public string PrintType { get; set; }

        /// <summary>
        /// average rating.
        /// </summary>
        [BsonElement("averageRating")]
        [Required]
        public int AverageRating { get; set; }

        /// <summary>
        /// ratings count.
        /// </summary>
        [BsonElement("ratingsCount")]
        [Required]
        public int RatingsCount { get; set; }

        /// <summary>
        /// Image links.
        /// </summary>
        [BsonElement("imageLinks")]
        [Required]
        public ImageLinkCollection ImageLinks { get; set; }

        /// <summary>
        /// Language.
        /// </summary>
        [BsonElement("language")]
        [Required]
        public string Language { get; set; }

        /// <summary>
        /// preview.
        /// </summary>
        [BsonElement("previewLink")]
        [Required]
        public string PreviewLink { get; set; }

        /// <summary>
        /// info.
        /// </summary>
        [BsonElement("infoLink")]
        [Required]
        public string InfoLink { get; set; }
    }
}
