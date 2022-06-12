using Newtonsoft.Json;

namespace Business.Models.Business
{
    public class LoginResponseModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; } 
        
        [JsonProperty("token")]
        public string Token { get; set; } 
    }
}