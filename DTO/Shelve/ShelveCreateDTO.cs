using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// Shelve DTO.
    /// </summary>
    public class ShelveCreateDTO
    {
        /// <summary>
        /// Unique identifier of this book.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        [JsonProperty("book_id")]
        public string BookId { get; set; }

    }
}