//using Dapper;
//using System.Data.SqlClient;
//using GoogleMaps.LocationServices;
//using Sonrai.ExtRS.Models;

//namespace Sonrai.ExtRSNET48.Services
//{
//    public class GISService
//    {
//        private readonly GoogleLocationService _locationService;
//        private readonly HttpClient _client;
//        private static readonly string states101FlagUrl = "https://www.states101.com/img/flags/svg/";
//        public GISService(HttpClient client, GoogleLocationService locationService)
//        {
//            _client = client;
//            _locationService = locationService;
//        }

//        public static List<Location> GetLocations(List<string> addresses, GoogleLocationService locationService)
//        {
//            var locations = new List<Location>();
//            foreach (string address in addresses)
//            {
//                Location location = new();
//                MapPoint coords = locationService.GetLatLongFromAddress(address.Replace(" ", "+") + "," + address.Replace(" ", "+") + "," + address.Replace(" ", "+"));
//                if (coords != null)
//                {
//                    location = new() { Lat = coords.Latitude.ToString(), Long = coords.Longitude.ToString() };
//                    locations.Add(location);
//                }
//            }

//            return locations;
//        }

//        public static string GetUnitedStatesFlagUrl(string stateAbbrev)
//        {
//            return string.Format("{0}{1}.svg", states101FlagUrl, GetStateNameFromStateAbbreviation(stateAbbrev));
//        }

//        public async Task<byte[]> GetUnitedStatesFlagImage(string state)
//        {
//            var uri = string.Format("{0}{1}.svg", states101FlagUrl, state);
//            return await _client.GetByteArrayAsync(uri);
//        }

//        public static string GetStateNameFromStateAbbreviation(string abbrev)
//        {
//            return States.StatesAndProvinces.First(x => x.Abbreviation == abbrev).Name;
//        }

//        public static string GetStateAbbreviationFromStateName(string stateName)
//        {
//            return States.StatesAndProvinces.First(x => x.Name == stateName).Abbreviation;
//        }
//    }
//}
