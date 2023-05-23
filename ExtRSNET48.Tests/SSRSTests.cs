using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Sonrai.ExtRS.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class SSRSTests
    {
        SSRSService ssrs;
        HttpClient httpClient;
        string defaultCreds = "\"UserName\": " + "\"ExtRSAuth\",  " + "\"Password\": \"\", " + " \"Domain\": \"localhost\"";

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
            HttpResponseMessage result = await ssrs.CallApi("POST", "Session", "{" + defaultCreds + "}");
            Assert.IsTrue(Convert.ToString(result.StatusCode) == "Created");
        }

        [TestMethod]
        public async Task DeleteSessionSucceeds()
        {
            var result = await ssrs.CallApi("DELETE", "Session");
            Assert.IsTrue(Convert.ToString(result.StatusCode) == "OK");
        }

        [TestMethod]
        public async Task GetAllCatalogItemsSucceeds()
        {
            var result = ssrs.CallApi("GET", "CatalogItems");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllReportsSucceeds()
        {
            var result = ssrs.CallApi("GET", "Reports");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReportSucceeds()
        {
            var result = ssrs.CallApi("GET", "Reports(path='/Reports/Team')");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetReportBytesSucceeds()
        {

        }

        [TestMethod]
        public async Task CreateCatalogItemSucceeds()
        {
            string content = "\"Id\": \"3A42F3DD-3B48-461C-9625-2CF531C301D2\"," +
                              "\"ModifiedBy\": \"ExtRSAuth\", " +
                              "\"Name\": \"EWTF_some_new_resource7\"," +
                               "\"Description\": \"This is a desc\"," +
                               "\"Path\": \"/Reports\"," +
                               "\"Type\": \"Resource\"," +
                               "\"Hidden\": \"false\"," +
                               "\"ModifiedDate\": \"2023-06-25\"," +
                               "\"CreatedBy\": \"ExtRSAuth\"," +
                               "\"CreatedDate\": \"2023-06-25\"," +
                               "\"ParentFolderId\": \"af7c2bfd-9da4-4d6f-95c1-75b37498f273\"," +
                               "\"ContentType\": \"text\"," +
                               "\"Content\": \"U29tZSB0ZXh0IGhlcmUuLi4uLi4uLi4=\"," +
                               "\"IsFavorite\": \"false\"";

            var result = await ssrs.CallApi("POST", "Resources", "{" + content + "}");
            Assert.IsTrue(result.IsSuccessStatusCode);
            var delResult = await ssrs.CallApi("DELETE", result.Headers.Location.Segments[4]);
            Assert.IsTrue(result.IsSuccessStatusCode);
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
