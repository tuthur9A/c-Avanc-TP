using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// author DTO.
    /// </summary>
    public class IndustryIdentifierDTO
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}