using Newtonsoft.Json;

namespace Business.Models.Business
{
    public class ErrorModel
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}