﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48
{
    // Twitter, IG, Fb, Quora
    //PollingPlaces
    //ElectionResult
    //Headlines
    // Score (NCAAM, NCAAF, NBA, MLB, NFL, Futbol)
    public class ReferenceDataService
    {
        public static async Task<string> GetSynonyms(string wordsPlusDelimited)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync("https://api.datamuse.com/words?ml=" + wordsPlusDelimited);
        }

        public static async Task<string> GetAppPublicIP()
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync("https://api.ipify.org?format=json");
        }

        public static async Task<string> GetCountryByIP(string ip)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(string.Format("https://api.country.is/{0}", ip));
        }

        public static async Task<string> GetTickerInfo(string ticker, string token)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(string.Format("https://api.tiingo.com/tiingo/daily/{0}?token={1}", ticker, token));
        }

        public static async Task<string> GetTickerPrices(string ticker, string token)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(string.Format("https://api.tiingo.com/tiingo/daily/{0}/prices?token={1}", ticker, token));
        }

        public static async Task<string> GetTickerPriceHistory(string ticker, string start, string end, string token)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(string.Format("https://api.tiingo.com/tiingo/daily/{0}/prices?startDate={1}&endDate={2}?token={3}", ticker, start, end, token));
        } 
    }
}
