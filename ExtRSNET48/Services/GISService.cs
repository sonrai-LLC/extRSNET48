using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Sonrai.ExtRSNET48.Models;
using System;

namespace Sonrai.ExtRSNET48.Services
{
    public class GISService
    {
        private readonly GoogleLocationService _locationService;
        private readonly HttpClient _client;
        private static readonly string states101FlagUrl = "https://www.states101.com/img/flags/svg/";
        public GISService(HttpClient client, GoogleLocationService locationService)
        {
            _client = client;
            _locationService = locationService;
        }

        public static List<Location> GetLocations(List<string> addresses, GoogleLocationService locationService)
        {
            var locations = new List<Location>();
            foreach (string address in addresses)
            {
                Location unused = new Location();
                MapPoint coords = locationService.GetLatLongFromAddress(address.Replace(" ", "+") + "," + address.Replace(" ", "+") + "," + address.Replace(" ", "+"));
                if (coords != null)
                {
                    Location location = new Location() { Lat = coords.Latitude.ToString(), Long = coords.Longitude.ToString() };
                    locations.Add(location);
                }
            }

            return locations;
        }

        public static string GetUnitedStatesFlagUrl(string stateAbbrev)
        {
            return string.Format("{0}{1}.svg", states101FlagUrl, GetStateNameFromStateAbbreviation(stateAbbrev));
        }

        public async Task<byte[]> GetUnitedStatesFlagImage(string state)
        {
            var uri = string.Format("{0}{1}.svg", states101FlagUrl, state);
            return await _client.GetByteArrayAsync(uri);
        }

        public static string GetStateNameFromStateAbbreviation(string abbrev)
        {
            return Location.StatesAndProvinces.First(x => x.Abbreviation == abbrev).Name;
        }

        public static string GetStateAbbreviationFromStateName(string stateName)
        {
            return Location.StatesAndProvinces.First(x => x.Name == stateName).Abbreviation;
        }

        public static List<string> Abbreviations()
        {
            return Location.StatesAndProvinces.Select(s => s.Abbreviation).ToList();
        }

        public static List<string> Names()
        {
            return Location.StatesAndProvinces.Select(s => s.Name).ToList();
        }

        public static string GetName(string abbreviation)
        {
            return Location.StatesAndProvinces.Where(s => s.Abbreviation.Equals(abbreviation, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Name).FirstOrDefault();
        }

        public static string GetAbbreviation(string name)
        {
            return Location.StatesAndProvinces.Where(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Abbreviation).FirstOrDefault();
        }

        public static List<State> ToList()
        {
            return Location.StatesAndProvinces;
        }
    }
}
