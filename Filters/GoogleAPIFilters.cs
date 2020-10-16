using Newtonsoft.Json;

namespace TP.Filters
{
    /// <summary>
    /// Books Filter
    /// </summary>
    public class GoogleAPIFilters
    {
        /// <summary>
        /// Filter by Title.
        /// </summary>
        [JsonProperty("filterByTitle")]
        public string FilterByTitle { get; set; }

        /// <summary>
        /// pagesize.
        /// </summary>
        [JsonProperty("filterByAuthor")]
        public string FilterByAuthor { get; set; }
    }
}
