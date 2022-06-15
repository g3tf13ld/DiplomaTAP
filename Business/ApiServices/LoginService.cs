using Business.Models.API;
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

        public RestResponse<T> RegisterUser<T>(UserLoginModel userLoginModel)
        {
            var endpoint = Configurator.BaseUrl + "/register";
            var request = new RestRequest(endpoint, Method.Post);
            request.AddBody(userLoginModel);
            return Client.ExecuteAsync<T>(request).Result;
        }

        public RestResponse<T> Login<T>(UserLoginModel userLoginModel)
        {
            var endpoint = Configurator.BaseUrl + "login";
            var request = new RestRequest(endpoint, Method.Post);
            request.AddBody(userLoginModel);
            return Client.ExecuteAsync<T>(request).Result;
        }
    }
}