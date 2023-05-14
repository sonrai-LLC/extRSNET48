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
    }   
}
