using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Loqate.Retrieve
{
    internal class RetrieveRequest
    {
        public RetrieveRequest(string key, string id)
        {
            Key = key;
            Id = id;
        }

        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("Id")]
        public string Id { get; set; }


        [JsonPropertyName("Field1Format")]
        public string? Field1Format { get; set; }
        
        [JsonPropertyName("Field2Format")]
        public string? Field2Format { get; set; }

    }
}
