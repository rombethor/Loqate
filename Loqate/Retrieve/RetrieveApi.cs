using Loqate.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loqate.Retrieve
{
    public class RetrieveApi
    {
        private readonly string _apiKey;
        private string _id { get; set; }

        HttpClient _client;

        internal RetrieveApi(HttpClient client, string apiKey, string id) 
        {
            ArgumentNullException.ThrowIfNull(apiKey, nameof(apiKey));
            ArgumentNullException.ThrowIfNull(id, nameof(id));

            _apiKey = apiKey;
            _id = id;

            _client = client;

            request = new(apiKey, id);
        }

        private readonly RetrieveRequest request;

        public async Task<RetrieveResponse> GetResponse()
        {
            HttpRequestMessage msg = new(HttpMethod.Post, $"https://api.addressy.com/Capture/Interactive/Retrieve/v1.2/json3.ws?Key={_apiKey}&Id={_id}");

            var response = await _client.SendAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                //Check for errors
                try
                {
                    return await response.Content.ReadFromJsonAsync<RetrieveResponse>();
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
