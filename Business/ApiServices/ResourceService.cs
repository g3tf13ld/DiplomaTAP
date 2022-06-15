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

        public RestResponse<BaseResponseWithListModel<ResourceModel>> GetResourcesList()
        {
            var endpoint = Configurator.BaseUrl + "/unknown";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithListModel<ResourceModel>>(request).Result;
        }
        
        public RestResponse<BaseResponseWithResourceModel<ResourceModel>> GetResourceById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/unknown/{userId}";
            var request = new RestRequest(endpoint);
            
            return Client.ExecuteAsync<BaseResponseWithResourceModel<ResourceModel>>(request).Result;
        }
    }
}