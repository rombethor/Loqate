using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loqate.EverythingLocation.Capture
{
    /// <summary>
    /// Return full information about a particular result from a call to the /address/complete endpoint.
    /// <br/>
    /// Note: only old everythinglocation keys will work with this service.
    /// </summary>
    public class CaptureApi
    {
        internal CaptureApi(HttpClient client, string apiKey, string query, string country, int result)
        {
            _client = client;
            
            request = new(apiKey, query, country, result);
        }

        private readonly HttpClient _client;

        private readonly CaptureRequest request;

        public async Task<CaptureResponse> GetResponse()
        {
            HttpRequestMessage msg = new(HttpMethod.Post, "https://api.everythinglocation.com/address/capture");
            msg.Content = JsonContent.Create(request);

            msg.Content.Headers.ContentType.CharSet = "utf-8";

            var result = await _client.SendAsync(msg);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<CaptureResponse>();
            else
                throw new LoqateException((int)result.StatusCode);
        }

        /// <summary>
        /// Sets the required detail
        /// </summary>
        /// <param name="query">A freeform partial address query.
        /// <br/>
        /// Example: "999 bak" or "bs328ga</param>
        /// <param name="country">A recognizable country name or ISO code.
        /// <br/>Example: "USA", "DE" or "New Zealand"</param>
        /// <param name="result">The index of the desired result from the /address/complete result, starting at zero.</param>
        /// <returns></returns>
        public CaptureApi SetRequiredFields(string query, string country, int result)
        {
            request.Query = query;
            request.Country = country;
            request.Result = result;

            return this;
        }

        /// <summary>
        /// Specifies whether to return geocode fields in the response. <br>This is an chargable add-on.</br>
        /// </summary>
        /// <param name="geocode"></param>
        /// <returns></returns>
        public CaptureApi Geocode(string geocode)
        {
            request.Geocode = geocode;
            return this;
        }

        /// <summary>
        /// Specifies whether to return certified fields in the response. This is an chargeable add-on.
        /// </summary>
        /// <param name="certify"></param>
        /// <returns></returns>
        public CaptureApi Certify(string certify)
        {
            request.Certify = certify;
            return this;
        }

    }
}
