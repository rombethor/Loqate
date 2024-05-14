using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Geolocation
{
    public class GeolocationResponse
    {
        [JsonPropertyName("Items")]
        public GeolocationResponseItem[] Items { get; set; } = [];
    }
}
