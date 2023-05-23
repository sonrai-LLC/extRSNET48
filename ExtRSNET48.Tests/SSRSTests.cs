using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sonrai.ExtRS.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class SSRSTests
    {
        SSRSService ssrs;
        HttpClient httpClient;
        string defaultCreds = "\"UserName\": \"ExtRSAuth\",  \"Password\": \"\",  \"Domain\": \"localhost\"";

        [TestInitialize]
        public async Task InitializeTests()
        {
            SSRSConnection connection = new SSRSConnection("localhost", "ExtRSAuth", AuthenticationType.ExtRSAuth);
            httpClient = new HttpClient();
            connection.sqlAuthCookie = await SSRSService.GetSqlAuthCookie(httpClient);
            ssrs = new SSRSService(connection);
        }

        [TestMethod]
        public async Task GetGetSqlAuthCookieSucceeds()
        {
            var result = await SSRSService.GetSqlAuthCookie(httpClient, "ExtRSAuth", "", "localhost");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateSessionSucceeds()
        {
            var result = await ssrs.CallApi("POST", "Session", "{" + defaultCreds + "}");
            Assert.IsTrue(Convert.ToString(result) == "Created");
        }

        [TestMethod]
        public async Task DeleteSessionSucceeds()
        {
            var result = await ssrs.CallApi("DELETE", "Session");
            Assert.IsTrue(Convert.ToString(result) == "OK");
        }

        [TestMethod]
        public async Task GetAllCatalogItemsSucceeds()
        {
            var result = await ssrs.CallApi("GET", "CatalogItems");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllReportsSucceeds()
        {
            var result = await ssrs.CallApi("GET", "Reports");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReportSucceeds()
        {
            var result = await ssrs.CallApi("GET", "Reports(path='/Reports/Team')");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetReportBytesSucceeds()
        {

        }

        [TestMethod]
        public async Task CreateCatalogItemSucceeds()
        {

        }

        [TestMethod]
        public async Task DeleteCatalogItemSucceeds()
        {

        }

        //[TestMethod]
        //public async Task GetParameterMarkupSucceeds()
        //{

        //}

        //[TestMethod]
        //public async Task GetCatalogItemMarkupSucceeds()
        //{

        //}
    }
}
