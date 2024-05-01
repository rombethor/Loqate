using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Loqate.Common;

namespace Loqate.Find
{
    /// <summary>
    /// Response to the Find v1.1 API
    /// </summary>
    public class FindItem
    {
        /// <summary>
        /// This can be an address Id or a container Id for further results.
        /// </summary>
        [JsonPropertyName("Id"), JsonRequired]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// If the Type is 'Address' then the Id can be passed to the Retrieve service. Any other Id should be passed as the Container to a further Find request to get more results.
        /// </summary>
        [JsonPropertyName("Type"), JsonRequired]
        public RecordType Type { get; set; }

        /// <summary>
        /// The name of the result.
        /// </summary>
        [JsonPropertyName("Text")]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// A list of number ranges identifying the matched characters in the Text and Description.
        /// </summary>
        [JsonPropertyName("Highlight")]
        public string Highlight { get; set; } = string.Empty;

        /// <summary>
        /// Descriptive information about the result.
        /// </summary>
        [JsonPropertyName("Description")]
        public string Description { get; set; } = string.Empty;
    }
}
