using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;


namespace Sonrai.ExtRS.Models
{
    public class SSRSConnection
    {
        public HttpClient HttpClient { get; set; }
        public string SqlAuthCookie;
        public string Administrator = "ExtRSAuth";
        public string serName;
        public string UserRole;
        public string ServerName;
        public AuthenticationType AuthenticationType;

        protected bool IsOnline = false;

        public SSRSConnection(string serverName, string adminUser, AuthenticationType authType = AuthenticationType.ExtRSAuth)
        {
            ServerName = serverName;
            Administrator = adminUser ?? Administrator;
            AuthenticationType = authType;
            HttpClient = new HttpClient();
        }
    }

    [JsonObject]
    public class CatalogItem
    {
        [JsonProperty("@odata.context")]
        string ODataContext;
        [JsonProperty("@odata.type")]
        string ODataType;
        [JsonProperty("Id")]
        string Id;
        [JsonProperty("Name")]
        string Name;
        [JsonProperty("Description")]
        string Description;
        [JsonProperty("Path")]
        string Path;
        [JsonProperty("Type")]
        string Type;
        [JsonProperty("Hidden")]
        bool Hidden;
        [JsonProperty("Size")]
        int Size;
        [JsonProperty("ModifiedBy")]
        string ModifiedBy;
        [JsonProperty("ModifiedDate")]
        string ModifiedDate;
        [JsonProperty("CreatedBy")]
        string CreatedBy;
        [JsonProperty("CreatedDate")]
        string CreatedDate;
        [JsonProperty("ParentFolderId")]
        string ParentFolderId;
        [JsonProperty("IsFavorite")]
        bool IsFavorite;
        [JsonProperty("ContentType")]
        string ContentType;
        [JsonProperty("Content")]
        string Content;
        [JsonProperty("Roles")]
        string[] Roles;
    }

    public class CatalogItems
    {
        [JsonProperty("@odata.context")]
        public string ODataContext;
        [JsonProperty("value")]
        public List<CatalogItem> Value;
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
        [JsonProperty("@odata.context")]
        string ODataContext;
        [JsonProperty("HasDataSources")]
        public bool HasDataSources;
        [JsonProperty("HasSharedDataSets")]
        public bool HasSharedDataSets;
        [JsonProperty("HasParameters")]
        public bool HasParameters;
    }

    public class DataSet : CatalogItem
    {
        [JsonProperty("QueryExecutionTimeOut")]
        bool QueryExecutionTimeOut;
        [JsonProperty("HasParameters")]
        bool HasParameters;
    }

    public class Folder : CatalogItem
    {

    }

    public class DataSource : CatalogItem
    {
        [JsonProperty("IsEnabled")]
        bool IsEnabled;
        [JsonProperty("ConnectionString")]
        string ConnectionString;
        [JsonProperty("DataSourceType")]
        string DataSourceType;
        [JsonProperty("IsOriginalConnectionStringExpressionBased")]
        bool IsOriginalConnectionStringExpressionBased;
        [JsonProperty("IsConnectionStringOverridden")]
        bool IsConnectionStringOverridden;
        [JsonProperty("CredentialRetrieval")]
        string CredentialRetrieval;
        [JsonProperty("IsReference")]
        bool IsReference;
        [JsonProperty("DataSourceSubType")]
        string DataSourceSubType;
        [JsonProperty("CredentialsByUser")]
        string CredentialsByUser;
        [JsonProperty("CredentialsInServer")]
        string CredentialsInServer;
    }

    public enum AuthenticationType
    {
        Windows,
        Forms,
        ExtRSAuth
    }
}
