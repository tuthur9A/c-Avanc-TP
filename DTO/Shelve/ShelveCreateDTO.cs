using System.Collections.Generic;
using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// Shelve DTO.
    /// </summary>
    public class ShelveCreateDTO
    {
        /// <summary>
        /// Unique identifier of this shelve.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the shelve
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The id of the book
        /// </summary>
        [JsonProperty("bookIds")]
        public IEnumerable<string> BookIds { get; set; }

    }
}