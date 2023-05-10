using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Sonrai.ExtRSNET48
{
    public class FormattingService
    {
        public static string ConvertInchesToFeetAndInches(int inches, bool forHtml = false)
        {
            var feet = inches / 12;
            inches %= 12;
            return feet.ToString() + (forHtml ? "&#39;" : "\'") + " " + inches + (forHtml ? " &#34;" : "\"");
        }

        public static string ToCurrencyUSD(decimal value)
        {
            return value.ToString("C");
        }

        public static decimal ToThousands(decimal value)
        {
            return Convert.ToDecimal(value) / 1000;
        }

        public static decimal ToMillions(decimal value)
        {
            return Convert.ToDecimal(value) / 1000000;
        }

        public static decimal ToBillions(decimal value)
        {
            return Convert.ToDecimal(value) / 1000000000;
        }

        public static decimal ToTrillions(decimal value)
        {
            return Convert.ToDecimal(value) / 1000000000000;
        }

        public static string DelimitedToJson(string json)
        {
            return JsonConvert.DeserializeXmlNode(json).ToString();
        }

        public static string ConvertXmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(doc);
        }

        public static string ConvertJsonToXml(string json)
        {
            return JsonConvert.DeserializeXNode(json, "Root").ToString();
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #region ref
        // ref: https://stackoverflow.com/questions/10824165/converting-a-csv-file-to-json-using-c-sharp
        #endregion      
        public static string CsvToJson(string input, string delimiter)
        {
            using (TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(input))))
            {
                parser.Delimiters = new string[] { delimiter };
                string[] headers = parser.ReadFields();
                if (headers == null) return null;
                string[] row;
                string comma = "";
                var sb = new StringBuilder((int)(input.Length * 1.1));
                sb.Append('[');
                while ((row = parser.ReadFields()) != null)
                {
                    var dict = new Dictionary<string, object>();
                    for (int i = 0; row != null && i < row.Length; i++)
                        dict[headers[i]] = row[i];

                    var obj = JsonConvert.SerializeObject(dict);
                    sb.Append(comma + obj);
                    comma = ",";
                }

                return sb.Append(']').ToString();
            }
        }

        //ExtRS-- > REST API methods for:
        //https://digitalfortress.tech/tips/top-15-commonly-used-regex/ 

        public static bool StringHasDupes(string value, bool caseSensitive)
        {
            if (caseSensitive)
                value = value.ToUpper();
            var valueLen = value.Length;
            var charLen = new List<char>(value.ToCharArray()).GroupBy(a => a).Count();

            return valueLen != charLen;
        }

        public static string ShrugText = "¯\\_(ツ)_/¯";

        #region CommonRegex

        public static string WholeNumbers = "/^\\d+$/";

        public static string DecimalNumbers = "/^\\d*\\.\\d+$/";

        public static string WholeAndDecimalNumbers = "/^\\d*(\\.\\d+)?$/";

        public static string GetShrugText = "¯\\_(ツ)_/¯";

        public static string Alphanumeric = "/^[a-zA-Z0-9]*$/";

        public static string AlphanumericWithSpaces = "/^[a-zA-Z0-9 ]*$/";

        public static string CommonEmail = "/^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6})*$/";

        public static string UncommonEmail = "/^([a-z0-9_\\.\\+-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$/";

        // Should have 1 lowercase letter, 1 uppercase letter, 1 number, 1 special character and be at least 8 characters long
        public static string ComlpexPassword = @"/(?=(.*[0-9]))(?=.*[\!@#$%^&*()\\[\]{}\-_+=~`|:;""'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}/";

        // Should have 1 lowercase letter, 1 uppercase letter, 1 number, and be at least 8 characters long
        public static string ModeratePassword = "/(?=(.*[0-9]))((?=.*[A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z]))^.{8,}$/";

        // Alphanumeric string that may include _ and – having a length of 3 to 16 characters
        public static string HttpsUrl = "/https?:\\/\\/(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#()?&//=]*)/";

        public static string Uri = "/(https?:\\/\\/)?(www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)/ ";

        public static string IpV4 = "/^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$/";

        public static string IpV6 = @"/(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))/";

        public static string UserName = "/^[a-z0-9_-]{3,16}$/";

        public static string IpV4AndIpV6 = @"/((^\s*((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\s*$)|(^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$))/";

        #endregion

        [Obsolete("This method will be deprecated soon.")]
        public bool DeprecatedExample()
        {
            return true;
        }
    }
}
