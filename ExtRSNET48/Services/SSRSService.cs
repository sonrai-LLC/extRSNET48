using Microsoft.VisualBasic;
using System.Globalization;
using System;
using System.Net.Http;

namespace Sonrai.ExtRSNET48
{
    public class SSRSService
    {
        HttpClient _client;
        public SSRSService(HttpClient client)
        {
            _client = client;
        }

        public static string CopyrightSymbol()
        {
            return "&#169;.";
        }

        public static string TMSymbol()
        {
            return "&#8482;";
        }

        public static string USDate(string date)
        {
            return DateTime.Parse(date, new CultureInfo("en-US")).ToString();
        }

        public static string UKDate(string date)
        {
            return DateTime.Parse(date, new CultureInfo("en-UK")).ToString();
        }
        public string GetSSRSResourceMarkup(string resourceType, string onClick = "", bool addCss = true)
        {
            switch (resourceType)
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

        public byte[] GetReportBytes(string report)
        {
            return new byte[0];
        }

        public string IsOnline()
        {
            return "";
        }
    }   
}
