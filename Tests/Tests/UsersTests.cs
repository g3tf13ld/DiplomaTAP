using System.Net;
using Business.Models.API;
using Business.Models.Business;
using NUnit.Framework;
using RestSharp;
using Tests.Base;

namespace Tests.Tests
{
    public class UsersTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            var req = new RestRequest("users", Method.Get);
            var resp = Client.ExecuteAsync<BaseResponseWithListModel<User>>(req).Result;
            var content = resp.Data;
            // var content2 = JsonConvert.DeserializeObject<BaseResponseWithListModel<User>>();
            var a = 0;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            });
        }

        [Test]
        public void UsersTest()
        {
            
        }
    }
}