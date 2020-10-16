using System.Collections.Generic;
using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// Shelve DTO.
    /// </summary>
    public class ShelveDTO
    {
        /// <summary>
        /// Unique identifier of this book.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The title of the book
        /// </summary>
        [JsonProperty("books")]
        public IEnumerable<BookDTO> Books { get; set; }

    }
}