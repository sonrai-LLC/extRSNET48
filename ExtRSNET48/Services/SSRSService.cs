using Newtonsoft.Json;
using Sonrai.ExtRS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48
{
    public class SSRSService
    {
        public SSRSConnection conn;
        private HttpClient client;
        public SSRSService(SSRSConnection connection)
        {          
            conn = connection;
            client = new HttpClient();
        }

        public async Task<string> GetAllCatalogItemsHtml(string filter, string css = "")
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("sqlAuthCookie", conn.sqlAuthCookie, "/", "localhost"));
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (client = new HttpClient(handler))
                {
                    string resp = await client.GetAsync(string.Format("https://{0}/reports/api/v2.0/CatalogItems", conn.ServerUrl)).Result.Content.ReadAsStringAsync();
                    CatalogItemResponse catalogItems = JsonConvert.DeserializeObject<CatalogItemResponse>(resp);
                    StringBuilder sb = new StringBuilder();

                    //sb.Append("<div id='path'");
                    //foreach (var item in catalogItems.)
                    //{
                    //    sb.Append(@" < div>
                    //    !!!!!
                    //    </div>");
                    //}
                    //sb.Append(@"</div>");

                    return sb.ToString();
                }
            }
        }

        public static async Task<string> GetSqlAuthCookie(HttpClient client, string user = "", string password = "", string domain = "localhost")
        {
            string cookie = "";
            StringContent httpContent = new StringContent("{ \"UserName\": \"ExtRSAuth\",  \"Password\": \"\",  \"Domain\": \"{0}\" }", Encoding.UTF8, "application/json");

            var response = await client.PostAsync(string.Format("https://{0}/reports/api/v2.0/Session", domain), httpContent);
            HttpHeaders headers = response.Headers;
            if (headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                cookie = values.First();
            }

            string pattern = @"(sqlAuthCookie=[A-Z0-9])\w+";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match sqlAuthCookie = regex.Match(cookie);

            return sqlAuthCookie.Value.Replace("sqlAuthCookie=", "");
        }

        public string GetCatalogItemHtml(string pathOrId, string onClick = "", string css = "")
        {
            string resourceType = "";
            switch (resourceType)
            {
                case "folder":
                    {
                        return "</>";
                    }
                case "report":
                    {
                        return "</>";
                    }
                case "datasource":
                    {
                        return "</>";
                    }
                case "dataset":
                    {
                        return "</>";
                    }
            }
            return "</>"; // format HTML in CLI lib lkup
        }

        public string GetSSRSParameterHtml(string pathOrId)
        {
            return "</>";
        }

        public string CreateOrUpdateCatalogItem(List<CatalogItem> catalogItem)
        {
            return "</>";
        }

        public string DeleteCatalogItem(string pathOrId)
        {
            return "</>";
        }

        public string DeleteCatalogItems(List<CatalogItem> catalogItem)
        {
            return "</>";
        }

        public byte[] GetReportBytes(string pathOrId)
        {
            return new byte[0];
        }

        public string IsOnline()
        {
            return "";
        }
    }   
}
