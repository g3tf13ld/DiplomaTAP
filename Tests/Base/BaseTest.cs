using Core;
using RestSharp;

namespace Tests.Base
{
    public class BaseTest
    {
        public static RestClient Client;
        
        static BaseTest()
        {
            Client = new RestClient(Configurator.BaseUrl);
        }
    }
}