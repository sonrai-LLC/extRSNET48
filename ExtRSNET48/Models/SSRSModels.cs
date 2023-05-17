namespace Sonrai.ExtRS.Models
{
    public class SSRSModel
    {

        public string Administrator = "ExtRSAuth";
        public string UserName;
        public string ServerUrl;
        public string ClientBearerToken;
        protected bool IsOnline = false;

        public SSRSModel(string serverUrl, string adminUser, string token = "") 
        {
            ServerUrl = serverUrl;
            Administrator = adminUser ?? Administrator;         
            ClientBearerToken = token ?? ClientBearerToken;
        }
    }

    public enum AuthenticationType
    {
        WindowsAD,
        MSCustomForms,
        ExtRSAuth
    }
}
