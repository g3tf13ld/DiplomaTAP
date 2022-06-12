﻿using Newtonsoft.Json;

namespace Business.Models.Business
{
    public class UserBusinessModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}