namespace Sonrai.ExtRS.Models
{
    public class SSRSModel
    {
        public readonly string Administrator = "ExtRSAuth";
        public readonly string UserName;
        public readonly string ServerName = "localhost";
    }

    public enum AuthenticationType
    {
        WindowsAD,
        MSCustomForms,
        ExtRSAuth
    }
}
