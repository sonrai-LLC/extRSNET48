using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;


namespace Sonrai.ExtRS.Models
{
    public class SSRSConnection
    {
        public HttpClient httpClient { get; set; }
        public string sqlAuthCookie;
        public string Administrator = "ExtRSAuth";
        public string UserName;
        public string UserRole;
        public string ServerUrl;
        public AuthenticationType AuthenticationType;

        protected bool IsOnline = false;

        public SSRSConnection(string serverUrl, string adminUser, AuthenticationType authType = AuthenticationType.ExtRSAuth)
        {
            ServerUrl = serverUrl;
            Administrator = adminUser ?? Administrator;
            AuthenticationType = authType;
            httpClient = new HttpClient();
        }
    }

    public class CatalogItem
    {
        [JsonProperty("@odata.type")]
        string ODataType;
        [JsonProperty("Id")]
        string Id;
        [JsonProperty("Name")]
        string Name;
        string Description;
        string Path;
        string Type;
        bool Hidden;
        int Size;
        string ModifiedBy;
        string ModifiedDate;
        string CreatedBy;
        string CreatedDate;
        string ParentFolderId;
        bool IsFavorite;
        string ContentType;
        string Content;
        string[] Roles;
    }

    public class CatalogItemResponse
    {
        [JsonProperty("@odata.context")]
        string ODataContext;
        [JsonProperty("value")]
        List<CatalogItem> Value;
    }

    public class Report : CatalogItem
    {
        public bool HasDataSources;
        public bool HasSharedDataSets;
        public bool HasParameters;
    }

    public class DataSet : CatalogItem
    {
        bool QueryExecutionTimeOut;
        bool HasParameters;
    }

    public class Folder : CatalogItem
    {

    }

    public class DataSource : CatalogItem
    {
        bool IsEnabled;
        string ConnectionString;
        string DataSourceType;
        bool IsOriginalConnectionStringExpressionBased;
        bool IsConnectionStringOverridden;
        string CredentialRetrieval;
        bool IsReference;
        string DataSourceSubType;
        string CredentialsByUser;
        string CredentialsInServer;
    }

    public enum AuthenticationType
    {
        WindowsAD,
        MSCustomForms,
        ExtRSAuth
    }
}
