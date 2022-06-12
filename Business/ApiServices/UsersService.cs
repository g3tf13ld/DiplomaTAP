using Business.Models.API;
using Business.Models.Business;
using Core;
using Newtonsoft.Json;
using RestSharp;

namespace Business.ApiServices
{
    public class UsersService
    {
        public RestClient Client;

        public UsersService(RestClient client)
        {
            Client = client;
        }

        public RestResponse<BaseResponseWithListModel<User>> GetUsersList()
        {
            var endpoint = Configurator.BaseUrl + "/users";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithListModel<User>>(request).Result;
        }
        
        public RestResponse<BaseResponseWithResourceModel<User>> GetUserById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithResourceModel<User>>(request).Result;
        }

        public void CreateUser(User userModel)
        {
            var endpoint = Configurator.BaseUrl + "/users";
            var request = new RestRequest(endpoint, Method.Post);
            request.AddBody(JsonConvert.SerializeObject(userModel));
            // return Client.ExecuteAsync<BaseResponseWithListModel<User>>(request).Result;
        }

        public void DeleteUserById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint);
            // return Client.ExecuteAsync<BaseResponseWithResourceModel<User>>(request).Result;
        }
        
        
    }
}