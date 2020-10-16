using Newtonsoft.Json;

namespace TP.Filters
{
    /// <summary>
    /// Books Filter
    /// </summary>
    public class BooksFilters
    {
        /// <summary>
        /// Filter by Title.
        /// </summary>
        [JsonProperty("filterByTitle")]
        public string FilterByTitle { get; set; }

        /// <summary>
        /// pagesize.
        /// </summary>
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        /// <summary>
        /// pagesize.
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}
