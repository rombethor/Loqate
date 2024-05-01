using Loqate.EverythingLocation.Capture;
using Loqate.EverythingLocation.Complete;
using Loqate.Find;
using Loqate.Retrieve;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Loqate
{
    /// <summary>
    /// Loqate client 
    /// </summary>
    public class Loqate
    {
        private static string _apikey;
        public static string ApiKey {
            set
            {
                _apikey = value;
            }
        }

        private HttpClient http;

        public Loqate()
        {
            if (string.IsNullOrWhiteSpace(_apikey))
                throw new WarningException("ApiKey has not been set.  Ensure that Loqate.ApiKey is provided a valid API key.");

            http = new HttpClient()
            {
                BaseAddress = new Uri(@"https://" + "api.everythinglocation.com/")
            };
            http.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
        }

        /// <summary>
        /// Uses a text search to find addresses and places. Note this does not return formatted addresses, and repeated calls to this service may be required to drill-down through results until an address ID is returned. The address ID should then be passed into the Retrieve service to obtain a fully formatted address.
        /// <br/>This endpoint does not consume credit.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public FindApi Find(string searchText) => new(http, _apikey, searchText);

        /// <summary>
        /// Returns the full address details based on the Id.
        /// <br/>This endpoint will consume credit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RetrieveApi Retrieve(string id) => new(http, _apikey, id);


        /// <summary>
        /// (Legacy) <br/>
        /// Generate a list of address suggestions based on the supplied query. Use with the /address/capture endpoint to select and return the full address object.
        /// <br/>
        /// Note: only old everythinglocation keys will work with this service.
        /// </summary>
        /// <param name="query">A freeform partial address query. <br/> Example: "999 bak" or "bs328ga</param>
        /// <param name="country">A recognizable country name or ISO code. <br/> Example: "USA", "DE" or "New Zealand"</param>
        /// <returns></returns>
        public CompleteApi EverythingLocation_Complete(string query, string country) 
            => new CompleteApi(http, _apikey, query, country);

        /// <summary>
        /// (Legacy) <br/>
        /// Return full information about a particular result from a call to the /address/complete endpoint.
        /// <br/>
        /// Note: only old everythinglocation keys will work with this service.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="country"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public CaptureApi EverythingLocation_Capture(string query, string country, int result)
            => new CaptureApi(http, _apikey, query, country, result);


    }
}
