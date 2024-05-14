using Loqate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqate.Geolocation
{
    /// <summary>
    /// Response item for the Geolocation service
    /// </summary>
    public class GeolocationResponseItem
    {
        /// <summary>
        /// This will be a retrieve id to pass to the retrieve endpoint
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This will always be <see cref="RecordType.Address"/>
        /// </summary>
        public RecordType Type { get; set; }

        /// <summary>
        /// The name of the result
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Descriptive information about the result.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The latitude of the current device as a string
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude of the current device as a string
        /// </summary>
        public string Longitude { get; set; }
    }
}
