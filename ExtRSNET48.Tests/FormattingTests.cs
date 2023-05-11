using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class FomattingTests
    {
        [TestMethod]
        public void GetBillionsSucceeds()
        {
            var result = FormattingService.ToMillions(200000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void GetMillionsSucceeds()
        {
            var result = FormattingService.ToBillions(200000000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void GetTrillionsSucceeds()
        {
            var result = FormattingService.ToTrillions(200000000000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void CsvToJsonSucceeds()
        {
            var csv = @"comma,separated,values
                        are,super,duper
                        fun,fun,forever
                        data, is, beautiful";
            var json = FormattingService.CsvToJson(csv, ",");
            Assert.IsTrue(JToken.Parse(json).HasValues);
        }

        [TestMethod]
        public void HexidecialSucceeds()
        {
            var match = Regex.Match("#000000", FormattingService.Hexidecimnal);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void HexidecialFails()
        {
            var match = Regex.Match("#33ff355$", FormattingService.Hexidecimnal);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void SocialSecuritySucceeds()
        {
            var match = Regex.Match("111-22-1111", FormattingService.SocialSecurity);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void SocialSecurityFails()
        {
            var match = Regex.Match("11-2-34453-1", FormattingService.SocialSecurity);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void AlphanumericSucceeds()
        {
            var match = Regex.Match("AaaBbbCcc1133", FormattingService.Alphanumeric);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void AlphanumericWithSpacesSucceeds()
        {
            var match = Regex.Match("Aaa BbbCcc111222333", FormattingService.AlphanumericWithSpaces);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void AlphanumericWithSpacesFails()
        {
            var match = Regex.Match("Aaa^BbbCcc+111222333", FormattingService.AlphanumericWithSpaces);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void CardAmexSucceeds()
        {
            var match = Regex.Match("378282246310005", FormattingService.CardAmex);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void CardAmexFails()
        {
            var match = Regex.Match("3782224631005", FormattingService.CardAmex);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void CardDiscoverSucceeds()
        {
            var match = Regex.Match("6011000990139424", FormattingService.CardDiscover);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void CardDiscoverFails()
        {
            var match = Regex.Match("601111111111117", FormattingService.CardDiscover);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void CardMastercardSucceeds()
        {
            var match = Regex.Match("5555555555554444", FormattingService.CardMastercard);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void CardMastercardFails()
        {
            var match = Regex.Match("55555555555544", FormattingService.CardMastercard);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void ComplexPasswordSucceeds()
        {
            var match = Regex.Match("lL1!eightchars", FormattingService.ComplexPassword);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void ComplexPasswordFails()
        {
            var match = Regex.Match("lL1eightchars", FormattingService.ComplexPassword);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void DecimalNumbersSucceeds()
        {
            var match = Regex.Match("3.14", FormattingService.DecimalNumbers);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void DecimalNumbersFails()
        {
            var match = Regex.Match("5", FormattingService.DecimalNumbers);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void DateWithSlashesSucceeds()
        {
            var match = Regex.Match("03/15/1983", FormattingService.DateWithSlashes);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void DateWithSlashesFails()
        {
            var match = Regex.Match("15/3-1983", FormattingService.DateWithSlashes);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void AmericanEnglishDateSucceeds()
        {
            var match = Regex.Match("03/15/1983", FormattingService.AmericanEnglishDate);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void AmericanEnglishDateFails()
        {
            var match = Regex.Match("15/03/1983", FormattingService.AmericanEnglishDate);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void BritishEnglishDateSucceeds()
        {
            var match = Regex.Match("15/03/1983", FormattingService.BritishEnglishDate);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void BritishEnglishDateFails()
        {
            var match = Regex.Match("15/14/1983", FormattingService.BritishEnglishDate);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void FilePathSucceeds()
        {
            var match = Regex.Match("var/some/place.pdf", FormattingService.FilePath);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void FilePathFails()
        {
            var match = Regex.Match("var|some|place.", FormattingService.FilePath);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void HasDupelicatesSucceeds()
        {
            var match = Regex.Match("this contains contains dupes", FormattingService.HasDupelicates);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void HasDupelicatesFails()
        {
            var match = Regex.Match("eachcharisdiferent eachWordIsDifferent", FormattingService.HasDupelicates);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void HtmlTagSucceeds()
        {
            var match = Regex.Match("<input type='button' />", FormattingService.HtmlTag);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void HtmlTagFails()
        {
            var match = Regex.Match("{'some':'value' }", FormattingService.HtmlTag);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void HttpsUrlSucceeds()
        {
            var match = Regex.Match("https://tel.net", FormattingService.HttpsUrl);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void HttpsUrlFails()
        {
            var match = Regex.Match("http//tel.net", FormattingService.HttpsUrl);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void IpV4Succeeds()
        {
            var match = Regex.Match("8.8.8.8", FormattingService.IpV4);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void IpV4Fails()
        {
            var match = Regex.Match("8.7.5.esVV.oc.oc", FormattingService.IpV4);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void IpV6Succeeds()
        {
            var match = Regex.Match("2001:0db8:85a3:0000:0000:8a2e:0370:7334", FormattingService.IpV6);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void IpV6Fails()
        {
            var match = Regex.Match("1:22:85a3:0000-27-8a2e-0370-7334", FormattingService.IpV6);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void IpV4AndIpV6Succeeds()
        {
            var match = Regex.Match("8.8.8.4", FormattingService.IpV4AndIpV6);
            Assert.IsTrue(match.Success);
            match = Regex.Match("2001:0db8:85a3:0000:0000:8a2e:0370:7334", FormattingService.IpV4AndIpV6);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void IIpV4AndIpV6Fails()
        {
            var match = Regex.Match("1:33:85a3:0000-27--0370-_", FormattingService.IpV4AndIpV6);
            Assert.IsTrue(!match.Success);
            match = Regex.Match("89.345.23.aa.c-1", FormattingService.IpV4AndIpV6);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void IsoDashDateSucceeds()
        {
            var match = Regex.Match("2024-01-01", FormattingService.IsoDashDate);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void IsoDashDateFails()
        {
            var match = Regex.Match("00/11/234", FormattingService.IsoDashDate);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void ModeratePasswordSucceeds()
        {
            var match = Regex.Match("l34534Rdhfbdth", FormattingService.ModeratePassword);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void ModeratePasswordFails()
        {
            var match = Regex.Match("lRdhdth", FormattingService.ModeratePassword);
            Assert.IsTrue(!match.Success);
        }

        [TestMethod]
        public void OracleDateSucceeds()
        {
            var match = Regex.Match("01-APR-1998", FormattingService.OracleDate);
            Assert.IsTrue(match.Success);
        }

        [TestMethod]
        public void OracleDateFails()
        {
            var match = Regex.Match("JAN-01-2024", FormattingService.OracleDate);
            Assert.IsTrue(!match.Success);
        }



        [TestMethod]
        public void DelimitedToJsonSucceeds()
        {
            string csv = @"comma,separated,values
                        are,super,duper
                        fun,fun,forever
                        data, is, beautiful";
            string json = FormattingService.CsvToJson(csv, ",");
            Assert.IsTrue(JToken.Parse(json).HasValues);
        }

        [TestMethod]
        public void ConvertJsonToXmlSucceeds()
        {
            string result = FormattingService.ConvertJsonToXml("{ 'some':'thing' }");
            Assert.IsTrue(result.Contains("/Root>"));
        }

        [TestMethod]
        public void ConvertXmlToJsonSucceeds()
        {
            string result = FormattingService.ConvertXmlToJson("<xml><childXml></childXml></xml>");
            Assert.IsTrue(result.Contains("{"));
        }

        [TestMethod]
        public void SerializeObjectSucceeds()
        {
            List<string> list = new List<string> { "Aa", "Bb", "Cc" };
            var result = FormattingService.SerializeObject(list);
            Assert.IsTrue(result.Contains("["));
        }
    }
}
