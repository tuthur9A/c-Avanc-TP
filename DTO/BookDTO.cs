using System.Collections.Generic;
using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// book DTO.
    /// </summary>
    public class BookDTO
    {
        /// <summary>
        /// Unique identifier of this book.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// list Author.
        /// </summary>
        [JsonProperty("authors")]
        public IEnumerable<string> Authors { get; set; }

        /// <summary>
        /// publisher.
        /// </summary>
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// published Date.
        /// </summary>
        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }

        /// <summary>
        /// list industry identifiers.
        /// </summary>
        [JsonProperty("industryIdentifiers")]
        public IEnumerable<IndustryIdentifierDTO> IndustryIdentifiers { get; set; }

        /// <summary>
        /// page count.
        /// </summary>
        [JsonProperty("pageCount")]
        public string PageCount { get; set; }

        /// <summary>
        /// print type.
        /// </summary>
        [JsonProperty("printType")]
        public string PrintType { get; set; }

        /// <summary>
        /// average rating.
        /// </summary>
        [JsonProperty("averageRating")]
        public int? AverageRating { get; set; } = null;

        /// <summary>
        /// ratings count.
        /// </summary>
        [JsonProperty("ratingsCount")]
        public int? RatingsCount { get; set; } = null;

        /// <summary>
        /// Image links.
        /// </summary>
        [JsonProperty("imageLinks")]
        public ImageLinkDTO ImageLinks { get; set; }

        /// <summary>
        /// Language.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// preview.
        /// </summary>
        [JsonProperty("previewLink")]
        public string PreviewLink { get; set; }

        /// <summary>
        /// info.
        /// </summary>
        [JsonProperty("infoLink")]
        public string InfoLink { get; set; }

    }
}
