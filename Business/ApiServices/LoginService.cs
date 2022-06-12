using Business.Models.API;
using Business.Models.Business;
using Core;
using RestSharp;

namespace Business.ApiServices
{
    public class LoginService
    {
        public RestClient Client;

        public LoginService(RestClient client)
        {
            Client = client;
        }

        public RestResponse<BaseResponseWithListModel<T>> RegisterUser<T>(UserModel userBusinessModel)
        {
            var endpoint = Configurator.BaseUrl + "/register";
            var request = new RestRequest(endpoint);
            request.AddBody(userBusinessModel);
            return Client.ExecuteAsync<BaseResponseWithListModel<T>>(request).Result;
        }

        public RestResponse<BaseResponseWithResourceModel<T>> Login<T>(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithResourceModel<T>>(request).Result;
        }
    }
}