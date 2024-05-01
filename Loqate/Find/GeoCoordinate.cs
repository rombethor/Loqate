using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Find
{
    /// <summary>
    /// Represents a geographical coordiante with latitude and longitude
    /// </summary>
    public class GeoCoordinate
    {
        public GeoCoordinate() { }
        public GeoCoordinate(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}
