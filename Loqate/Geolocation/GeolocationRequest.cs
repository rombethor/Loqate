using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Geolocation
{
    internal class GeolocationRequest
    {
        /// <summary>
        /// The key used to authenticate with the service.
        /// </summary>
        [JsonPropertyName("Key")]
        public required string Key { get; set; }

        /// <summary>
        /// The latitude of the current device
        /// </summary>
        [JsonPropertyName("Latitude")]
        public required string Latitude { get; set; }

        /// <summary>
        /// The longitude of the current device
        /// </summary>
        [JsonPropertyName("Longitude")]
        public required string Longitude { get; set; }

        /// <summary>
        /// Limit to return
        /// </summary>
        [JsonPropertyName("Items")]
        public int Items { get; set; }

        /// <summary>
        /// The maximum radius of the geo-location search in metres. 
        /// This can be set to a maximum of 200 metres.
        /// </summary>
        [JsonPropertyName("Radius")]
        public int Radius { get; set; }
    }
}
