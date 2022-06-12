using System.Net;
using Business.ApiServices;
using Business.Models.Business;
using Core;
using NUnit.Framework;
using Tests.Base;

namespace Tests.Tests
{
    public class UsersTests : BaseTest
    {
        [Test]
        [Regression]
        public void GetUsersList_ShouldBeOk()
        {
            var response = new UsersService(Client).GetUsersList();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.Less(0, response.Data.Page);
                Assert.Less(0, response.Data.Total);
                Assert.LessOrEqual(0, response.Data.PerPage);
                Assert.Less(0, response.Data.Data.Length);
                
                CheckSupportModel(response.Data.Support);
            });
        }

        [Test]
        public void SingleUser_ShouldBeOk()
        {
            var response = new UsersService(Client).GetUserById("2");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.NotNull(response.Data.Data.Avatar);
                Assert.NotNull(response.Data.Data.Email);
                Assert.NotNull(response.Data.Data.FirstName);
                Assert.NotNull(response.Data.Data.LastName);
                Assert.LessOrEqual(0, response.Data.Data.Id);

                CheckSupportModel(response.Data.Support);
            });
        }
        
        [Test]
        public void SingleUser_ShouldBeNotFound()
        {
            var response = new UsersService(Client).GetUserById("23");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                Assert.True(response.Content == "{}");
            });
        }

        private void CheckSupportModel(SupportModel supportModel)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("https://reqres.in/#support-heading", supportModel.Text);
                Assert.AreEqual("To keep ReqRes free, contributions towards server costs are appreciated!",
                    supportModel.Url);
            });
        }
    }
}