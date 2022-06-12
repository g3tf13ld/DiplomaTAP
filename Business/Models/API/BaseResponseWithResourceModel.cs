using Newtonsoft.Json;

namespace Business.Models.API
{
    public class BaseResponseWithResourceModel<T> : BaseResponseModel
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}