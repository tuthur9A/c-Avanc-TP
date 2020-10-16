using Newtonsoft.Json;

namespace TP.Filters
{
    /// <summary>
    /// Shelve Filter
    /// </summary>
    public class ShelvesFilters
    {
        /// <summary>
        /// Filter by bookId.
        /// </summary>
        [JsonProperty("filterByBookId")]
        public string FilterByBookId { get; set; }
    }
}
