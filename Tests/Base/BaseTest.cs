using Business.Models.Business;
using Core;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Tests.Base
{
    public class BaseTest
    {
        public static RestClient Client;
        
        static BaseTest()
        {
            Client = new RestClient(Configurator.BaseUrl);
            Client.UseNewtonsoftJson();
        }
        
        protected void CheckSupportModel(SupportModel supportModel)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("https://reqres.in/#support-heading", supportModel.Url);
                Assert.AreEqual("To keep ReqRes free, contributions towards server costs are appreciated!",
                    supportModel.Text);
            });
        }
    }
}