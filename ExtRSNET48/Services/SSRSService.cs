﻿using Newtonsoft.Json;
using Sonrai.ExtRS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System;

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
            serverUrl = string.Format("https://{0}/reports/api/v2.0/", conn.ServerUrl);
        }

        public async Task<object> CallApi(string verb, string operation, string content = "", string parameters = "")
        {
            string response = "";
            CatalogItems items = new CatalogItems();
            CatalogItem item;
            HttpContent httpContent = new StringContent(content);
            HttpResponseHeaders headers;
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            {
                using (client = new HttpClient(handler))
                {
                    switch (verb)
                    {
                        case "GET":
                            response = await client.GetAsync(serverUrl + operation).Result.Content.ReadAsStringAsync();
                            break;
                        case "POST":
                            return client.PostAsync(serverUrl + operation, httpContent).Result.StatusCode;
                        case "DELETE":
                            return client.DeleteAsync(serverUrl + operation).Result.StatusCode;
                        case "PUT":
                            return client.PutAsync(serverUrl + operation, httpContent).Result.StatusCode;
                    }

                    try
                    {
                        items = JsonConvert.DeserializeObject<CatalogItems>(response);

                        if (items.Value != null)
                        {
                            return items;
                        }
                        else
                        {
                            return JsonConvert.DeserializeObject<CatalogItem>(response);
                        }
                    }
                    catch { }

                    return null;
                }
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

        public async Task CreateSession()
        {
            await client.DeleteAsync(string.Format("https://{0}/reports/api/v2.0/Session", conn.ServerUrl));
        }

        public async Task DeleteSession()
        {
            await client.DeleteAsync(string.Format("https://{0}/reports/api/v2.0/Session", conn.ServerUrl));
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
