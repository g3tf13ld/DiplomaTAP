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

        public RestResponse<BaseResponseWithListModel<User>> PostRegisterUser(User userModel)
        {
            var endpoint = Configurator.BaseUrl + "/register";
            var request = new RestRequest(endpoint);
            request.AddBody(userModel);
            // return Client.ExecuteAsync<BaseResponseWithListModel<User>>(request).Result;
        }

        public RestResponse<BaseResponseWithResourceModel<User>> PostLogin(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithResourceModel<User>>(request).Result;
        }
    }
}