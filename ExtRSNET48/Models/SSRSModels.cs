using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonrai.ExtRS.Models
{
    public class SSRSModel
    {
        private string version;
        private string adminUser;
        private string _pwd;
        public readonly string Administrator;
        public readonly string ReportServer;
    }

    public enum AuthenticationType
    {
        WindowsAD,
        MSCustomForms,
        ExtRS
    }
}
