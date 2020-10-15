using Newtonsoft.Json;

namespace TP.DTO
{
    /// <summary>
    /// author DTO.
    /// </summary>
    public class ImageLinkDTO
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}