using System.Net;
using Business.ApiServices;
using Business.Models.API;
using Business.Models.Business;
using Core;
using NUnit.Framework;
using Tests.Base;

namespace Tests.Tests
{
    public class LoginTests : BaseTest
    {
        [Test]
        [Smoke]
        public void RegisterUser_ShouldBeOk()
        {
            var email = "eve.holt@reqres.in";
            var password = "pistol";

            var response = new LoginService(Client).RegisterUser<LoginResponseModel>(new UserLoginModel()
            {
                Email = email,
                Password = password
            });
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.NotNull(response.Data.Id);
                Assert.NotNull(response.Data.Token);
            });
        }
        
        [Test]
        [Regression]
        public void RegisterUser_MissingPassword_ShouldBeBadRequest()
        {
            var email = "test.email@gmail.com";

            var response = new LoginService(Client).RegisterUser<ErrorModel>(new UserLoginModel()
            {
                Email = email
            });
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual("Missing password", response.Data.Error);
            });
        }
        
        [Test]
        public void RegisterUser_MissingEmail_ShouldBeBadRequest()
        {
            var password = "!qwerty123!";

            var response = new LoginService(Client).RegisterUser<ErrorModel>(new UserLoginModel()
            {
                Password = password
            });
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual("Missing email or username", response.Data.Error);
            });
        }
        
        [Test]
        public void RegisterUser_MissingEmailAndPassword_ShouldBeBadRequest()
        {
            var response = new LoginService(Client).RegisterUser<ErrorModel>(new UserLoginModel() { });
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual("Missing email or username", response.Data.Error);
            });
        }

        [Test]
        [Smoke]
        public void Login_ShouldBeOk()
        {
            var email = Configurator.Username;
            var password = Configurator.Password;
            
            var response = new LoginService(Client).RegisterUser<LoginResponseModel>(new UserLoginModel()
            {
                Email = email,
                Password = password
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.NotNull(response.Data.Token);
            });
        }
        
        [Test]
        public void Login_MissingPassword_ShouldBeBadRequest()
        {
            var email = Configurator.Username;
            
            var response = new LoginService(Client).RegisterUser<ErrorModel>(new UserLoginModel()
            {
                Email = email
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual("Missing password",response.Data.Error);
            });
        }
        
        [Test]
        public void Login_MissingEmail_ShouldBeBadRequest()
        {
            var password = Configurator.Password;

            var response = new LoginService(Client).RegisterUser<ErrorModel>(new UserLoginModel()
            {
                Password = password
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual("Missing email or username",response.Data.Error);
            });
        }
    }
}