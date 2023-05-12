using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using System;
using System.Net.Http;

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
        public void GetLocationReturnsNothing()
        {
            var result = gis.GetLocation("NeverNeverland");
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void GetLocationsSucceeds()
        {
            List<string> locations = new List<string> { "Chicago, IL", "Milwaukee, WI", "Detroit, MI"};
            var result = gis.GetLocations(locations);
            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void GetLocationsReturnsNothing()
        {
            List<string> locations = new List<string> { "adv??asdvgsd, _B", "adgsdgvs, RE", "YTFYT??, H+" };
            var result = gis.GetLocations(locations);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void GetUnitedStatesFlagUrlSucceeds()
        {
            var result = GISService.GetUnitedStatesFlagUrl("WI");
            Assert.IsTrue(result.Length > 0);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetUnitedStatesFlagUrlFails()
        {
            var result = GISService.GetUnitedStatesFlagUrl(null);
            // expect exception
        }

        [TestMethod]
        public async Task GetUnitedStatesFlagImageSucceeds()
        {
            var result = await gis.GetUnitedStatesFlagImage("wisconsin");
            Assert.IsTrue(result.Length > 0);
        }

        [ExpectedException(typeof(HttpRequestException))]
        [TestMethod]
        public async Task GetUnitedStatesFlagImageFails()
        {
            var result = await gis.GetUnitedStatesFlagImage("ZZ");
            // expect exception
        }

        [TestMethod]
        public void GetStateNameFromStateAbbreviationSucceeds()
        {
            var result = GISService.GetStateNameFromStateAbbreviation("WI");
            Assert.IsTrue(result.Length > 0);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetStateNameFromStateAbbreviationFails()
        {
            var result = GISService.GetStateNameFromStateAbbreviation("ZZ");
        }

        [TestMethod]
        public void GetStateAbbreviationFromStateNameSucceeds()
        {
            var result = GISService.GetStateAbbreviationFromStateName("Wisconsin");
            Assert.IsTrue(result.Length > 0);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void GetStateAbbreviationFromStateNameFails()
        {
            var result = GISService.GetStateAbbreviationFromStateName("Milwaukee"); ;
        }

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
