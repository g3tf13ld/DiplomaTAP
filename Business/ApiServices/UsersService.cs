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

        public RestResponse<BaseResponseWithListModel<UserBusinessModel>> GetUsersList()
        {
            var endpoint = Configurator.BaseUrl + "/users";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithListModel<UserBusinessModel>>(request).Result;
        }
        
        public RestResponse<BaseResponseWithResourceModel<UserBusinessModel>> GetUserById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint);
            return Client.ExecuteAsync<BaseResponseWithResourceModel<UserBusinessModel>>(request).Result;
        }

        public RestResponse<UserModel> CreateUser(UserModel userBusinessModel)
        {
            var endpoint = Configurator.BaseUrl + "/users";
            var request = new RestRequest(endpoint, Method.Post);
            request.AddBody(JsonConvert.SerializeObject(userBusinessModel));
            return Client.ExecuteAsync<UserModel>(request).Result;
        }

        public RestResponse<UserModel> UpdateUserPutRequest(string userId, UserModel userModel)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint, Method.Put);
            request.AddBody(JsonConvert.SerializeObject(userModel));
            return Client.ExecuteAsync<UserModel>(request).Result;
        }
        
        public RestResponse<UserModel> UpdateUserPatchRequest(string userId, UserModel userModel)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint, Method.Patch);
            request.AddBody(JsonConvert.SerializeObject(userModel));
            return Client.ExecuteAsync<UserModel>(request).Result;
        }

        public RestResponse DeleteUserById(string userId)
        {
            var endpoint = Configurator.BaseUrl + $"/users/{userId}";
            var request = new RestRequest(endpoint, Method.Delete);
            return Client.ExecuteAsync(request).Result;
        }
    }
}