using Sonrai.ExtRS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace Sonrai.ExtRSNET48
{
    public class SSRSService
    {
        public SSRSConnection conn;
        private HttpClient client;
        CookieContainer cookieContainer = new CookieContainer();
        string serverUrl;
       
        public SSRSService(SSRSConnection connection)
        {          
            conn = connection;
            client = new HttpClient();
            cookieContainer.Add(new Cookie("sqlAuthCookie", conn.sqlAuthCookie, "/", "localhost"));
            serverUrl = string.Format("https://{0}/reports/api/v2.0/", conn.ServerName);
        }

        public async Task<HttpResponseMessage> CallApi(string verb, string operation, string content = "", string parameters = "")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (client = new HttpClient(handler))
                {
                    switch (verb)
                    {
                        case "GET":
                            return await client.GetAsync(serverUrl + operation);
                        case "POST":
                            return await client.PostAsync(serverUrl + operation, httpContent);
                        case "DELETE":
                            return await client.DeleteAsync(serverUrl + operation);
                        case "PUT":
                            return await client.PutAsync(serverUrl + operation, httpContent);
                    }
                }

                return null;
            }
        }

        public static string GetCredentialJson(string user, string password, string domain)
        {
            return string.Format("\"UserName\":\"{0}\",\"Password\": \"{1}\",\"Domain\":\"{2}\"", user, password, domain);
        }

        public static async Task<string> GetSqlAuthCookie(HttpClient client, string user = "ExtRSAuth", string password = "", string domain = "localhost")
        {
            string cookie = "";
            StringContent httpContent = new StringContent("{" + GetCredentialJson(user, password, domain) + "}", Encoding.UTF8, "application/json");

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
            StringBuilder sb = new StringBuilder();
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
    }   
}
