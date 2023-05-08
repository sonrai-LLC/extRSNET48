using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Sonrai.ExtRSNET48.Services;

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
    }
}
