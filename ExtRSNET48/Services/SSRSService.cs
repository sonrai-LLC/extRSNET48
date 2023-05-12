using System.Net.Http;

namespace Sonrai.ExtRSNET48
{
    // RSAuth (auth via header. etc.- return sqlAuthCookie)

    public class SSRSService
    {
        HttpClient _client;
        public SSRSService(HttpClient client)
        {
            _client = client;
        }

        public string GetServerHealth()
        {
            return "";
        }

        public string GetServerInfo()
        {
            return "";
        }

        public string GetReportInfo()
        {
            return "";
        }

        public string GetPBIChartMarkup()
        {
            //RESTService service = new(_client);
            return "</>";
        }

        public string LiveStats()
        {
            return "11 000 1111 000000 1111111111";
        }

        public string GetPBIServiceStatus()
        {
            return "ON";
        }

        public string PBIRunData(string url, string xpath, string entity)
        {
            return @"Execs past 24hrs: 2,000,436
                     Logins past 24hrs: 39,074
                     CPU Avg past 24hrs: 83%";
        }

        public string DynamicRDL()
        {
            return "</>";
        }

        public string GetSSRSResourceMarkup(string resourceType, string onClick = "", bool addCss = true)
        {
            switch(resourceType)
            {
                case "folders":
                    {
                        return "</>"; //option list
                    }
                case "reports":
                    {
                        return "</>"; //option list
                    }

                case "datasources":
                    {
                        return "</>"; //option list
                    }
                case "datasets":
                    {
                        return "</>"; //option list
                    }
                case "schedules":
                    {
                        return "</>"; //option list
                    }
            }
            return "</>"; // format HTML in CLI lib lkup
        }

        public string GetSSRSParameterUIMarkup()
        {
            return "</>";
        }

        public string GetCascadeParameters(string source, string sourceCol, string cascade, string casecadeCol)
        {
            return "";
        }

        public string LiveSSRSLook()
        {
            return "";
        }

        public string LivePBILook()
        {
            return "";
        }

        public string GetReportServerInfo()
        {
            return "";
        }

        public string GetReportServerStatus()
        {
            return "";
        }

        public string GetLogStream()
        {
            return "";
        }

        public string ExportLog()
        {
            return "";
        }

        public string SearchLogs()
        {
            return "";
        }

        public string SearchWindowsEvents()
        {
            return "";
        }

        public string UploadReport()
        {
            return "";
        }

        public string UpdateReport()
        {
            return "";
        }

        public string UploadDataSource()
        {
            return "";
        }

        public string UploadDataSet()
        {
            return "";
        }

        public string DeleteResource(string id)
        {
            return "";
        }

        public string GetDynamicColWidth(string id)
        {
            return "";
        }

        public string GetReportHeader(string id)
        {
            return "";
        }

        public string GetReportFooter(string id)
        {
            return "";
        }

        public string RSScheduleData(string url, string xpath, string entity)
        {
            return "";
        }

        public string RSRunData(string url, string xpath, string entity)
        {
            return "";
        }

        public byte[] GetSSRSLog()
        {
            return new byte[0]; // TODO
        }

        public byte[] GetSSRSAdmin()
        {
            return new byte[0]; // TODO
        }

        public void UpdateSection(string sectionName, string sectionValue)
        {
            //return new byte[0]; // TODO
        }

        public static string GetHeaderContent()
        {
            return "";
        }

        public static string GetFooterContent()
        {
            return "";
        }

        public static string CopyrightSymbol()
        {
            return "";
        }

        public static string TMSymbol()
        {
            return "";
        }

        public static string USDate()
        {
            return "";
        }

        public static string GlobalDate()
        {
            return "";
        }

        public static string GetImage()
        {
            return "";
        }
    }   
}
