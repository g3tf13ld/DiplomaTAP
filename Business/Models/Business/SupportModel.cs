using Newtonsoft.Json;

namespace Business.Models.Business
{
    public class SupportModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}