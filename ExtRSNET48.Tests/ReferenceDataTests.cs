using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class ReferenceDataTests
    {
        [TestMethod]
        public async Task GetSynonymsSucceeds()
        {
            var result = await ReferenceDataService.GetSynonyms("nonplussed bored");
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetSynonymsFails()
        {
            var result = await ReferenceDataService.GetSynonyms(null);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
