using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sonrai.ExtRS.Models;
using System.Net.Http;
using System.Threading.Tasks;

// await httpClient.DeleteAsync(string.Format("https://{0}/reports/api/v2.0/Session", ServerUrl));
namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class SSRSTests
    {
        SSRSService ssrs;

        [TestInitialize]
        public async Task InitializeTests()
        {
            SSRSConnection connection = new SSRSConnection("localhost", "ExtRSAuth", AuthenticationType.ExtRSAuth);
            HttpClient httpClient = new HttpClient();
            connection.sqlAuthCookie = await SSRSService.GetSqlAuthCookie(httpClient);
            ssrs = new SSRSService(connection);
        }

        [TestMethod]
        public async Task GetAllCatalogItemsHtmlSucceeds()
        {
            var result = await ssrs.GetAllCatalogItemsHtml("");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSSRSParameterUIMarkupSucceeds()
        {

        }

        [TestMethod]
        public void GetReportBytesSucceeds()
        {

        }

        [TestMethod]
        public void IsOnlineSucceeds()
        {

        }

        [TestMethod]
        public void DeleteCatalogItemSucceeds()
        {

        }

        [TestMethod]
        public void CreateSessionSucceeds()
        {

        }

        [TestMethod]
        public void DeleteSessionSucceeds()
        {

        }
    }
}
