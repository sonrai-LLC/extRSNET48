using Newtonsoft.Json;

namespace Sonrai.ExtRS.Models
{
    public class SSRSConnection
    {
        private string sqlAuthCookie;
        public string Administrator = "ExtRSAuth";
        public string UserName;
        public string UserRole;
        public string ServerUrl;
        public AuthenticationType AuthenticationType;

        protected bool IsOnline = false;

        public SSRSConnection(string serverUrl, string adminUser, string cookie, AuthenticationType authType = AuthenticationType.ExtRSAuth)
        {
            ServerUrl = serverUrl;
            Administrator = adminUser ?? Administrator;
            sqlAuthCookie = cookie;
            AuthenticationType = authType;
        }
    }

    public abstract class CatalogItem
    {
        [JsonProperty("@odata.type")]
        string ODataType;
        string Id;
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

    public class Report : CatalogItem
    {
        bool HasDataSources;
        bool HasSharedDataSets;
        bool HasParameters;
    }

    public class DataSet
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
