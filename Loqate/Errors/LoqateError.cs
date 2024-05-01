using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Errors
{
    /// <summary>
    /// This consistutes the common format for errors provided
    /// by Loqate.  These are provided in a 'table', see <see cref="LoqateErrorTable"/>
    /// </summary>
    public class LoqateError
    {
        [JsonPropertyName("Error")]
        public string? Error { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Cause")]
        public string? Cause { get; set; }

        [JsonPropertyName("Resolution")]
        public string? Resolution { get; set; }
    }
}
