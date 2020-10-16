using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using TP.Filters;

namespace TP.Services.GoogleAPI
{
    /// <summary>
    /// R client service.
    /// </summary>
    public class GoogleAPIClientService : IGoogleAPIClientService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="client"></param>
        public GoogleAPIClientService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Search by title.
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<string> Search(GoogleAPIFilters filters)
        {
            var baseUrl = "https://www.googleapis.com/books/v1/volumes?q=";
            if(filters.FilterByTitle != null && filters.FilterByTitle != "") {
                baseUrl += "intitle:" + filters.FilterByTitle + "+";
            }
            if(filters.FilterByAuthor != null && filters.FilterByAuthor != "") {
                baseUrl += "inauthor:" + filters.FilterByAuthor + "+";
            }
            Log.ForContext<GoogleAPIClientService>().Information(JsonConvert.SerializeObject(baseUrl));
            var result = await _httpClient.GetAsync(baseUrl);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
