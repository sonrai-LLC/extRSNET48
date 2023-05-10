using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
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
    }
}
