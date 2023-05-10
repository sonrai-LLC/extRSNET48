﻿using Microsoft.VisualBasic.FileIO;
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

        public static bool StringHasDupes(string value, bool caseSensitive)
        {
            if (caseSensitive)
                value = value.ToUpper();
            var valueLen = value.Length;
            var charLen = new List<char>(value.ToCharArray()).GroupBy(a => a).Count();

            return valueLen != charLen;
        }

        public static string Shrug = "¯\\_(ツ)_/¯";

        #region CommonRegex
        //ref: //https://digitalfortress.tech/tips/top-15-commonly-used-regex/ 

        public static string WholeNumbers = "/^\\d+$/";

        public static string DecimalNumbers = "/^\\d*\\.\\d+$/";

        public static string WholeAndDecimalNumbers = "/^\\d*(\\.\\d+)?$/";

        public static string GetShrugText = "¯\\_(ツ)_/¯";

        public static string Alphanumeric = "/^[a-zA-Z0-9]*$/";

        public static string AlphanumericWithSpaces = "/^[a-zA-Z0-9 ]*$/";

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

        /* Date Format YYYY-MM-dd */
        public static string IsoDashDate = "/([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))/";

        public static string EnglishDate = "/^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[1,3-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$/";

        public static string OracleDate = "/^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)(?:0?2|(?:Feb))\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$/";

        public static string Time12Hour = "/((1[0-2]|0?[1-9]):([0-5][0-9]) ?([AaPp][Mm]))/";

        public static string Time24Hour = "/^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/";

        public static string HtmlTag = "/<\\/?[\\w\\s]*>|<.+[\\W]>/";

        public static string HasDupelicates = "/(\\b\\w+\\b)(?=.*\\b\\1\\b)/";

        public static string PhoneNumberInternational = "/^(?:(?:\\(?(?:00|\\+)([1-4]\\d\\d|[1-9]\\d?)\\)?)?[\\-\\.\\ \\\\\\/]?)?((?:\\(?\\d{1,}\\)?[\\-\\.\\ \\\\\\/]?){0,})(?:[\\-\\.\\ \\\\\\/]?(?:#|ext\\.?|extension|x)[\\-\\.\\ \\\\\\/]?(\\d+))?$/";

        public static string FilePathWithExt = "/((\\/|\\\\|\\/\\/|https?:\\\\\\\\|https?:\\/\\/)[a-z0-9 _@\\-^!#$%&+={}.\\/\\\\\\[\\]]+)+\\.[a-z]+$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string UsPostalCode = "^(?!0{3})[0-9]{3,5}$";

        public static string SocialSecurity = "/^((?!219-09-9999|078-05-1120)(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4})|((?!219 09 9999|078 05 1120)(?!666|000|9\\d{2})\\d{3} (?!00)\\d{2} (?!0{4})\\d{4})|((?!219099999|078051120)(?!666|000|9\\d{2})\\d{3}(?!00)\\d{2}(?!0{4})\\d{4})$/";

        public static string Passport = "/^[A-PR-WY][1-9]\\d\\s?\\d{4}[1-9]$/";

        // can use either hypen(-) or space( ) character as separator
        // ref: https://stackoverflow.com/questions/9315647/regex-credit-card-number-tests

        public static string CardAmex = "^3[47][0-9]{13}$";

        public static string CardDiscover = "^65[4-9][0-9]{13}|64[4-9][0-9]{13}|6011[0-9]{12}|(622(?:12[6-9]|1[3-9]";

        public static string CardMastercard = "^(5[1-5][0-9]{14}|2(22[1-9][0-9]{12}|2[3-9][0-9]{13}|[3-6][0-9]{14}|7[0-1][0-9]{13}|720[0-9]{12}))$";

        public static string CardVisaMastercard = "^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14})$";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";

        public static string FilePathWithoutExt = "/^(.+)/([^/]+)$/";
        #endregion

        [Obsolete("This method will be deprecated soon.")]
        public bool DeprecatedExample()
        {
            return true;
        }
    }
}
