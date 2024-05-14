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
        private static Loqate? _instance = null;

        private static Loqate Instance => _instance 
            ?? throw new NotImplementedException("Loqate.Configure must be called before Loqate can be used.");

        private string _apikey;
        public string ApiKey {
            set
            {
                _apikey = value;
            }
        }

        // Configure Loqate
        public static void Configure(string apiKey)
        {
            _instance = new(apiKey);
        }

        private readonly HttpClient http;

        private Loqate(string apiKey)
        {
            _apikey = apiKey;

            if (string.IsNullOrWhiteSpace(_apikey))
                throw new WarningException("ApiKey has not been set.  Ensure that Loqate.ApiKey is provided a valid API key.");

            // As client is in static instance, 
            // ensure that connections refresh periodically
            // in case of DNS changes.
            var handler = new SocketsHttpHandler()
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(15)
            };

            http = new HttpClient(handler)
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
        public static FindApi Find(string searchText) => new(Instance.http, Instance._apikey, searchText);


        /// <summary>
        /// Returns the full address details based on the Id.
        /// <br/>This endpoint will consume credit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RetrieveApi Retrieve(string id) => new(Instance.http, Instance._apikey, id);

        /// <summary>
        /// A valuable optional add-on for Capture customers, this Reverse GeoLocationservice takes a 
        /// latitude longitude point and returns addresses that are within a specified radius. 
        /// This must be followed by a Retrieve to obtain a fully formatted address.
        /// </summary>
        /// <param name="longitude">Centre longitude</param>
        /// <param name="latitude">Centre latitude</param>
        /// <param name="limit">Number of results to return</param>
        /// <param name="radius">Accuracy in meters.  Up to 200m maximum.</param>
        /// <returns></returns>
        public static GeolocationApi Geolocation(double longitude, double latitude, int limit, int radius)
            => new(Instance._apikey, Instance.http, longitude, latitude, limit, radius);
        

        /// <summary>
        /// (Legacy) <br/>
        /// Generate a list of address suggestions based on the supplied query. Use with the /address/capture endpoint to select and return the full address object.
        /// <br/>
        /// Note: only old everythinglocation keys will work with this service.
        /// </summary>
        /// <param name="query">A freeform partial address query. <br/> Example: "999 bak" or "bs328ga</param>
        /// <param name="country">A recognizable country name or ISO code. <br/> Example: "USA", "DE" or "New Zealand"</param>
        /// <returns></returns>
        public static CompleteApi EverythingLocation_Complete(string query, string country) 
            => new(Instance.http, Instance._apikey, query, country);

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
        public static CaptureApi EverythingLocation_Capture(string query, string country, int result)
            => new(Instance.http, Instance._apikey, query, country, result);


    }
}
