using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sonrai.ExtRSNET48.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;

namespace Sonrai.ExtRSNET48.UnitTests
{
    [TestClass]
    public class GISTests
    {
        protected readonly string googleApiKey = "AIzaSyC0orVO-ck9GwAbqgYZTjx4yTMptnhBNNE"; // Google Maps API key, found here https://developers.google.com/maps/documentation/javascript/get-api-key
        GISService gis;
       [TestInitialize] public void Init()
        {
            gis = new GISService(new System.Net.Http.HttpClient(), new GoogleLocationService(googleApiKey));
        }

        [TestMethod]
        public void GetLocationSucceeds()
        {
            var result = gis.GetLocation("Beloit, WI");
            Assert.IsTrue(result.Long.Length > 0);
        }

        [TestMethod]
        public void GetLocationFails()
        {
            var result = gis.GetLocation("NeverNeverland");
            Assert.IsFalse(result.Long.Length > 0);
        }

        //[TestMethod]
        //public async Task GetLocationsSucceeds()
        //{
        //    var result = await gis.GetLocations(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetLocationsFails()
        //{
        //    var result = await gis.GetLocations(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetUnitedStatesFlagUrlSucceeds()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetUnitedStatesFlagUrlFails()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}


        //[TestMethod]
        //public async Task GetUnitedStatesFlagImageSucceeds()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetUnitedStatesFlagImageFails()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetStateNameFromStateAbbreviationSucceeds()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetStateNameFromStateAbbreviationFails()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetStateAbbreviationFromStateNameSucceeds()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task GetStateAbbreviationFromStateNameFails()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        //[TestMethod]
        //public async Task AbbreviationsSucceeds()
        //{
        //    var result = await ReferenceDataService.GetSynonyms(null);
        //    Assert.IsTrue(result.Length > 0);
        //}

        [TestMethod]
        public void StateAbbreviationsSucceeds()
        {
            var result = GISService.StateAbbreviations().Count > 50;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StateNamesSucceeds()
        {
            var result = GISService.StateNames().Count > 50;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetStateOrProvinceNameSucceeds()
        {
            var result = GISService.GetStateOrProvinceName("WI");
            Assert.IsTrue(result.Length > 0);
        }
    }
}
