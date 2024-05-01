using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Loqate.EverythingLocation.Capture
{
    public class CaptureResponse
    {
        public string Status { get; set; }

        public Output output { get; set; }
        public class Output
        {
            public string Address { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Address1 { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Address2 { get; set; }

            /// <summary>
            /// The 
            /// </summary>
            public string Address3 { get; set; }
            public string Address4 { get; set; }
            public string Address5 { get; set; }


            /// <summary>
            /// Typically the County
            /// </summary>
            public string AdministrativeArea { get; set; }

            public decimal AutoCompleteFuzzyMatchScore { get; set; }
            public string CountryName { get; set; }
            public string DeliveryAddress { get; set; }
            public string DeliveryAddress1 { get; set; }

            [JsonPropertyName("ISO3166-2")]
            public string ISO3166_2 { get; set; }
            [JsonPropertyName("ISO3166-3")]
            public string ISO3166_3 { get; set; }
            [JsonPropertyName("ISO3166-N")]
            public string ISO3166_N { get; set; }

            /// <summary>
            /// A comma-separated list of fields in the response which were matched by the query
            /// </summary>
            public string MatchedFieldList { get; set; }

            /// <summary>
            /// The postal code
            /// </summary>
            public string PostalCode { get; set; }
            public string PostalCodePrimary { get; set; }
            public string Premise { get; set; }

            public string SubBuilding { get; set; } //for buildings, an alternative to premises

            /// <summary>
            /// External building number
            /// </summary>
            public string PremiseNumber { get; set; }

            /// <summary>
            /// The road name
            /// </summary>
            public string Thoroughfare { get; set; }

            /// <summary>
            /// Town name, typically
            /// </summary>
            public string Locality { get; set; }


            public string SearchMethod { get; set; }


            public string TotalRecordCount { get; set; }
        }
    }
}
