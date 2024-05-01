using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Loqate.EverythingLocation.Complete
{
    public class CompleteResponse
    {
        public string Status { get; set; }

        /// <summary>
        /// A list of full-text addresses
        /// </summary>
        [JsonPropertyName("output")]
        public IEnumerable<string> Output { get; set; }

        [JsonPropertyName("metadata")]
        public IEnumerable<AddressMetadata> Metadata { get; set; }

        public class AddressMetadata
        {
            /// <summary>
            /// How many records fall under this exact locality.  If a premise is specified
            /// then this shold be "1" for a correct address.
            /// </summary>
            public string TotalRecordCount { get; set; }
            public string AdministrativeArea { get; set; }
            public string Locality { get; set; }
            public string PostalCode { get; set; }
            public string Thoroughfare { get; set; }

            /// <summary>
            /// The house number.  If this doesn't exist, try using SubBuilding
            /// </summary>
            public string Premise { get; set; }
            public string SubBuilding { get; set; }
        }
    }
}
