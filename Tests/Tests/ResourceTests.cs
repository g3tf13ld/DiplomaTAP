using System.Net;
using Business.ApiServices;
using Core;
using NUnit.Framework;
using Tests.Base;

namespace Tests.Tests
{
    public class ResourceTests: BaseTest
    {
        [Test]
        [Regression]
        public void GetResourcesList_ShouldBeOk()
        {
            var response = new ResourceService(Client).GetResourcesList();
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.NotNull(response.Data);
                Assert.Less(0, response.Data.Page);
                Assert.Less(0, response.Data.Total);
                Assert.LessOrEqual(0, response.Data.PerPage);
                Assert.Less(0, response.Data.Data.Length);

                CheckSupportModel(response.Data.Support);
            });
        }

        [Test]
        public void GetResourceById_ShouldBeOk()
        {
            var response = new ResourceService(Client).GetResourceById("2");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Data);
                Assert.NotNull(response.Data.Data.Color);
                Assert.NotNull(response.Data.Data.PantoneValue);
                Assert.NotNull(response.Data.Data.Name);
                Assert.NotNull(response.Data.Data.Year);
                Assert.LessOrEqual(0, response.Data.Data.Id);

                CheckSupportModel(response.Data.Support);
            });
        }
        
        [Test]
        public void GetResourceById_ShouldBeNotFound()
        {
            var response = new ResourceService(Client).GetResourceById("23");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
                Assert.True(response.Content == "{}");
            });
        }
    }
}