using System.Net;
using Business.ApiServices;
using Business.Models.API;
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
        [Smoke]
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
        [Smoke]
        public void SingleUser_ShouldBeNotFound()
        {
            var response = new UsersService(Client).GetUserById("23");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                Assert.True(response.Content == "{}");
            });
        }

        [Test]
        [Smoke]
        public void CreateUser_ShouldBeCreated()
        {
            var name = "Pavel";
            var job = "AQA Engineer";

            var response = new UsersService(Client).CreateUser(new UserModel()
            {
                Name = name,
                Job = job
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual(job, response.Data.Job);
                Assert.AreEqual(name, response.Data.Name);
                Assert.NotNull(response.Data.Id);
                Assert.NotNull(response.Data.CreatedAt);
            });
        }

        [Test]
        [Smoke]
        public void PutUpdateUser_ShouldBeOk()
        {
            var name = "morpheus";
            var job = "AQA Engineer";

            var response = new UsersService(Client).UpdateUserPutRequest("2", new UserModel()
            {
                Name = name,
                Job = job
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual(job, response.Data.Job);
                Assert.AreEqual(name, response.Data.Name);
                Assert.NotNull(response.Data.UpdatedAt);
            });
        }

        [Test]
        [Smoke]
        public void PatchUpdateUser_ShouldBeOk()
        {
            var name = "morpheus";
            var job = "AQA Engineer";

            var response = new UsersService(Client).UpdateUserPutRequest("2", new UserModel()
            {
                Name = name,
                Job = job
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.AreEqual(job, response.Data.Job);
                Assert.AreEqual(name, response.Data.Name);
                Assert.NotNull(response.Data.UpdatedAt);
            });
        }

        [Test]
        [Smoke]
        public void DeleteUser_ShouldBeNoContent()
        {
            var response = new UsersService(Client).DeleteUserById("2");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
                Assert.IsEmpty(response.Content);
            });
        }
    }
}