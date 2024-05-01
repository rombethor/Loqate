using Loqate.EverythingLocation.Capture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Loqate.EverythingLocation.Complete
{
    /// <summary>
    /// Generate a list of address suggestions based on the supplied query. Use with the /address/capture endpoint to select and return the full address object.
    /// Note: only old everythinglocation keys will work with this service.
    /// </summary>
    public class CompleteApi
    {
        readonly HttpClient _client;

        internal CompleteApi(HttpClient client, string apikey, string query, string country)
        {
            requestBody = new(apikey, query, country);
            _client = client;
        }

        private readonly CompleteRequest requestBody;

        /// <summary>
        /// In cases where the result can be chosen when this client is still
        /// open, we can conveniently initialise the capture API.
        /// </summary>
        /// <param name="resultIndex">The index of the chosen result</param>
        /// <returns></returns>
        public CaptureApi GetCaptureApi(int resultIndex)
            => new(_client, requestBody.Lqtkey, requestBody.Query, requestBody.Country, resultIndex);

        public async Task<CompleteResponse> GetResponse()
        {
            HttpRequestMessage msg = new(HttpMethod.Post, "https://api.everythinglocation.com/address/complete");
            msg.Content = JsonContent.Create(requestBody);

            var response = await _client.SendAsync(msg);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<CompleteResponse>();
            else
                throw new LoqateException((int)response.StatusCode);
        }

        /// <summary>
        /// A recognizable country name or ISO code. <br/>
        /// Example: "USA", "DE" or "New Zealand"
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public CompleteApi Country(string country)
        {
            ArgumentNullException.ThrowIfNull(country, nameof(country));
            requestBody.Country = country;
            return this;
        }

        /// <summary>
        /// A freeform partial address query.<br/>
        /// Example: "999 bak" or "bs328ga
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public CompleteApi Query(string query)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));
            requestBody.Query = query;
            return this;
        }

        private void EnsureFilters(string filter)
        {
            ArgumentNullException.ThrowIfNull(filter, nameof(filter));
            if (requestBody.Filters == null)
                requestBody.Filters = new();
        }

        public CompleteApi FilterPostalCode(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.PostalCode = filter;
            return this;
        }

        public CompleteApi FilterSubBuilding(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.SubBuilding = filter;
            return this;
        }

        public CompleteApi FilterPremise(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.Premise = filter;
            return this;
        }

        public CompleteApi FilterThoroughfare(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.Thoroughfare = filter;
            return this;
        }

        public CompleteApi FilterLocality(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.Locality = filter;
            return this;
        }

        public CompleteApi FilterAdministrativeArea(string filter)
        {
            EnsureFilters(filter);
            requestBody.Filters!.AdministrativeArea = filter;
            return this;
        }

    }
}
