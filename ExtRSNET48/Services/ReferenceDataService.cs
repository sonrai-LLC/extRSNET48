using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sonrai.ExtRSNET48
{
    public class ReferenceDataService
    {
        public static async Task<string> GetSynonyms(string wordsPlusDelimited)
        {
            HttpClient client = new HttpClient();
            return await client.GetStringAsync("https://api.datamuse.com/words?ml=" + wordsPlusDelimited);
        }

        // 

        //Static Reference Data(D1HOOPS, etc.)
        //    Market Info
        //    GoogleMaps LocationInfo, Zillow, etc.


        //public string GetDJIA()
        //{

        //}

        //public string GetNasdaq()
        //{

        //}

        //public string GetSP500()
        //{

        //}

        //public string GetUSStates()
        //{

        //}

        //public string GetUSFlag()
        //{

        //}


        // Static ref data

        // Custom ref data
        public string GetCustomReferenceData(string tenantId, string sql = "")
        {
            return ""; // FROM D1MBB...
        }
    }
}
