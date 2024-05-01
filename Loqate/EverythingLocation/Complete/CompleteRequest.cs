using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Loqate.EverythingLocation.Complete
{
    internal class CompleteRequest
    {
        public CompleteRequest(string apiKey, string query, string country)
        {
            Lqtkey = apiKey;
            Query = query;
            Country = country;
        }

        [JsonPropertyName("lqtkey")]
        public string Lqtkey { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("filters")]
        public LoqateFilters? Filters { get; set; }
        public class LoqateFilters
        {
            public string? PostalCode { get; set; }
            public string? Thoroughfare { get; set; }
            public string? AdministrativeArea { get; set; }
            public string? Locality { get; set; }
            public string? Premise { get; set; }
            public string? SubBuilding { get; set; }
        }

    }
}
