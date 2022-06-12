using Business.Models.API;
using Business.Models.Business;
using Core;
using RestSharp;

namespace Business.ApiServices
{
    public class ResourceService
    {
        public RestClient Client;

        public ResourceService(RestClient client)
        {
            Client = client;
        }

        public RestResponse<BaseResponseWithListModel<User>> GetResourcesList()
        {
            var endpoint = Configurator.BaseUrl + "/unknown";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithListModel<User>>(request).Result;
        }
        
        public RestResponse<BaseResponseWithResourceModel<User>> GetResourceById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/unknown/{userId}";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithResourceModel<User>>(request).Result;
        }
    }
}