using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sonrai.ExtRSNET48
{
    public class ReferenceDataService
    {
        public string GetMarketTickers()
        {
            return "";
        }

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
