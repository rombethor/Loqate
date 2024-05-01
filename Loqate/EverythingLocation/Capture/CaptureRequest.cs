using Loqate.EverythingLocation.Complete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Loqate.EverythingLocation.Capture
{
    internal class CaptureRequest : CompleteRequest
    {
        public CaptureRequest(string apikey, string query, string country, int result)
            : base(apikey, query, country)
        {
            Result = result;
        }

        /// <summary>
        /// The index of the desired result from the /address/complete result, starting at zero.
        /// </summary>
        [JsonPropertyName("result")]
        public int Result { get; set; }

        /// <summary>
        /// Specifies whether to return geocode fields in the response. <b>This is an chargable add-on.</b>
        /// </summary>
        [JsonPropertyName("geocode")]
        public string? Geocode { get; set; }

        /// <summary>
        /// Specifies whether to return certified fields in the response. 
        /// <b>This is an chargeable add-on.</b>
        /// </summary>
        [JsonPropertyName("certify")]
        public string? Certify { get; set; }
    }
}
