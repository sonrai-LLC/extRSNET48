# ExtRS.NET48
ExtRS.NET48 is a .NET Framework 4.8 class library for extending the capabilities of Reporting Services. With ExtRS.NET48, (pronounced "extras dot net 48"), common public API endpoints and SDK clients are consolidated into a utility .dll containing features that can compliment your reporting. ExtRS.NET48 also contains a simplified interface to the SSRS v2 API for programmatically managing SSRS catalog item types (CatalogItem, Report, DataSource, DataSet, etc.).

SSRS ain't dead- it's just a niche tool that hasn't fully realized its potential- yet. 😊

# Requirements
This plug-in works as a drop-in Nuget package for .NET Framework 4.8 projects as well an SSRS Custom Assembly as described by Microsoft here: https://docs.microsoft.com/en-us/sql/reporting-services/custom-assemblies/using-custom-assemblies-with-reports?view=sql-server-ver15

# Contents
This package includes the following components:
- Sonrai.ExtRSNET48.dll

# Examples

```
        [TestInitialize]
        public async Task InitializeTests()
        {
            httpClient = new HttpClient();
            SSRSConnection connection = new SSRSConnection("localhost", "ExtRSAuth", 
            AuthenticationType.ExtRSAuth);
            connection.SqlAuthCookie = await SSRSService.GetSqlAuthCookie(httpClient, 
            connection.Administrator, "", connection.ServerName);
            ssrs = new SSRSService(connection);
        }


        public SSRSService(SSRSConnection connection)
        {          
            conn = connection;
            client = new HttpClient();
            cookieContainer.Add(new Cookie("sqlAuthCookie", conn.SqlAuthCookie, "/", "localhost"));
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

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
```

# Related SSRS Tools
- [ExtRSAuth](https://github.com/sonrai-LLC/ExtRSAuth) for enabling further extension of the SSRS Microsoft Custom Security Sample.
