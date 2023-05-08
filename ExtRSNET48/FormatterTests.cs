using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class FomattingTests
    {
        [TestMethod]
        public void GetBillionsSucceeds()
        {
            var result = Services.FormattingService.ToMillions(200000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void GetMillionsSucceeds()
        {
            var result = Services.FormattingService.ToBillions(200000000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void GetTrillionsSucceeds()
        {
            var result = Services.FormattingService.ToTrillions(200000000000000);
            Assert.IsTrue(result == 200);
        }

        [TestMethod]
        public void CsvToJsonSucceeds()
        {
            var csv = @"comma,separated,values
                        are,super,duper
                        fun,fun,forever
                        data, is, beautiful";
            var json = Services.FormattingService.CsvToJson(csv, ",");
            Assert.IsTrue(json.Length > 0);
        }
    }
}
