using Loqate.Errors;
using Loqate.Find;
using Loqate.Retrieve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Loqate.Geolocation
{
    public class GeolocationApi
    {

        private readonly string _apiKey;
        private string _id { get; set; }

        HttpClient _client;

        readonly GeolocationRequest _request;

        internal GeolocationApi(string apiKey, HttpClient httpClient, double longitude, double latitude, int limit, int radius)
        {
            _apiKey = apiKey;
            _client = httpClient;
            
            _request = new()
            {
                Key = apiKey,
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
                Items = limit,
                Radius = radius
            };

        }

        public GeolocationApi Radius(int radius)
        {
            _request.Radius = radius;
            return this;
        }

        public GeolocationApi Limit(int limit)
        {
            _request.Items = limit;
            return this;
        }

        public GeolocationApi Centre(double longitude, double latitude)
        {
            _request.Longitude = longitude.ToString();
            _request.Latitude = latitude.ToString();
            return this;
        }

        public async Task<GeolocationResponse> GetResponse()
        {
            HttpRequestMessage msg = new(HttpMethod.Post, $"https://api.addressy.com/Capture/Interactive/GeoLocation/v1/json3.ws?Key={_apiKey}&Latitude={_request.Latitude}&Longitude={_request.Longitude}&Items={_request.Items}&Radius={_request.Radius}");

            var response = await _client.SendAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                //Check for errors
                try
                {
                    return await response.Content.ReadFromJsonAsync<GeolocationResponse>();
                }
                catch
                {
                    var errors = await response.Content.ReadFromJsonAsync<LoqateErrorTable>();
                    throw new LoqateException((int)response.StatusCode, errors?.Items ?? []);
                }
            }
            throw new LoqateException((int)response.StatusCode);

        }

    }
}
