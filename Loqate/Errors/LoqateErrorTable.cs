using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Errors
{
    /// <summary>
    /// Errors are reported from loqate with a successful response: 200 OK.
    /// The body of the request provides for error diagnosis.
    /// </summary>
    public class LoqateErrorTable
    {
        [JsonPropertyName("Items")]
        public LoqateError[] Items { get; set; } 
            = Array.Empty<LoqateError>();
    }
}
