using Loqate.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loqate.Find
{
    /// <summary>
    /// Uses a text search to find addresses and places. Note this does not return formatted addresses, and repeated calls to this service may be required to drill-down through results until an address ID is returned. The address ID should then be passed into the Retrieve service to obtain a fully formatted address.
    /// <br/>This method does not consume credit.
    /// </summary>
    public class FindApi
    {

        internal FindApi(HttpClient client, string apiKey, string searchText)
        {
            _searchText = searchText;
            _apikey = apiKey;
            _client = client;
        }

        readonly HttpClient _client;

        private readonly string _apikey;
        private string _searchText;
        private bool? _isMiddleware = null;
        private string? _container = null;
        private string? _origin = null;
        private List<string> _countries = new();
        private int? _limit;
        private string? _language;
        private bool? _bias;
        private List<string> _filters = new();
        private List<GeoCoordinate> _geofence = new();

        public async Task<FindItem[]> GetResponse()
        {
            string query = $"?Key={_apikey}&Text={_searchText}";
            if (_isMiddleware.HasValue)
                query += $"&IsMiddleware={_isMiddleware}";
            if (!string.IsNullOrWhiteSpace(_container))
                query += $"&Container={_container}";
            if (!string.IsNullOrWhiteSpace(_origin))
                query += $"&Origin";
            if (_countries.Count > 0)
                query += $"&Countries={string.Join(',', _countries)}";
            if (_limit.HasValue)
                query += $"&Limit={_limit}";
            if (!string.IsNullOrWhiteSpace(_language))
                query += $"&Language={_language}";
            if (_bias.HasValue)
                query += $"&Bias={_bias}";
            
            foreach (var filter in _filters)
                query += $"Filters={filter}";

            if (_geofence.Count >= 3)
                query += $"&GeoFence=[{JsonSerializer.Serialize(_geofence)}]";

            HttpRequestMessage msg = new(HttpMethod.Post, 
                $"https://api.addressy.com/Capture/Interactive/Find/v1.1/json3.ws{query}");

            var result = await _client.SendAsync(msg);
            if (result.IsSuccessStatusCode)
            {
                string json = await result.Content.ReadAsStringAsync();
                try
                {
                    return JsonSerializer.Deserialize<FindResponse>(json)?.Items;
                }
                catch (JsonException)
                {
                    var errorTable = JsonSerializer.Deserialize<LoqateErrorTable>(json);
                    throw new LoqateException((int)result.StatusCode, errorTable?.Items ?? []);
                }

            }
            throw new LoqateException((int)result.StatusCode);
        }

        /// <summary>
        /// The search text to find. Ideally a postcode or the start of the address.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public FindApi SearchText(string text)
        {
            _searchText = text;
            return this;
        }

        /// <summary>
        /// Whether the API is being called from a middleware implementation (and therefore the calling IP address should not be used for biasing).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FindApi IsMiddleware(bool value = true)
        {
            _isMiddleware = value;
            return this;
        }

        /// <summary>
        /// A container for the search. This should only be another Id previously returned from this service when the Type of the result was not 'Address'.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FindApi Container(string id)
        {
            _container = id;
            return this;
        }

        /// <summary>
        /// A starting location for the search. This can be the name or ISO 2 or 3 character code of a country, WGS84 coordinates (comma separated) or IP address to search from.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FindApi Origin(string value)
        {
            _origin = value;
            return this;
        }

        /// <summary>
        /// A list of ISO 2 or 3 character country codes to limit the search within.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public FindApi Country(params string[] values)
        {
            _countries = values.ToList();
            return this;
        }

        /// <summary>
        /// The preferred language for results where the same address matches input in different languages. This parameter will also affect the label "Addresses" in the Description field of the Container results, eg. where Language=es, the value will be "direcciones". The value should be a 2 or 4 character language code e.g. (en, fr, en-gb, en-us).
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public FindApi Language(string language)
        {
            _language = language;
            return this;
        }

        /// <summary>
        /// Enable/Disable biasing
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public FindApi Bias(bool value)
        {
            _bias = value;
            return this;
        }

        /// <summary>
        /// his setting allows filtering of addresses returned by the Find method in the latest Capture. Supported filters are described below.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="exclude"></param>
        /// <returns></returns>
        public FindApi AddFilter(FindFilterType type, string filter, bool exclude = false)
        {
            string x = exclude ? "!" : string.Empty;

            string t = type.ToString();
            if (type == FindFilterType.CommercialResidencial)
                t = "Attributes.CommercialResidential";

            _filters.Add($"{x}{t}:{filter}");
            return this;
        }

        /// <summary>
        /// This setting allows specifying coordinates for points in a geofence. Only the addresses within specified geofence will be returned. Please see example below.
        /// </summary>
        /// <param name="fence"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the coordinates supplied are invalid or insufficient</exception>
        public FindApi SetGeoFence(IEnumerable<GeoCoordinate> fence)
        {
            if (fence.Count() < 3)
                throw new ArgumentException("Parameter 'fence' must contain at least 3 coordinate values.");
            _geofence = fence.ToList();
            return this;
        }

    }
}
