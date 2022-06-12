using Newtonsoft.Json;

namespace Business.Models.Business
{
    public class UserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("job")]
        public string Job { get; set; }
        
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
    }
}