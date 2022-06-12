using Business.Models.Business;
using Newtonsoft.Json;

namespace Business.Models.API
{
    public class BaseResponseModel
    {
        [JsonProperty("support")]
        public SupportModel Support { get; set; }
    }
}