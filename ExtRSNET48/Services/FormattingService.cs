using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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

        public string ConvertXmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(doc);
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

        [Obsolete("This method will be deprecated soon.")]
        public bool DeprecatedExample()
        {
            return true;
        }
    }
}
