using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;

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
        /// Generate tokenizer.
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<string> Search(string text)
        {
            Log.ForContext<GoogleAPIClientService>().Information(JsonConvert.SerializeObject(text));
            var result = await _httpClient.GetAsync("https://www.googleapis.com/books/v1/volumes?q=" + text);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
