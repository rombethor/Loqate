using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Loqate.Find
{
    public enum FindFilterType
    {
        /// <summary>
        /// Company Name
        /// </summary>
        OrganisationName,

        /// <summary>
        /// City
        /// </summary>
        Locality,

        /// <summary>
        /// Postal code / Postcode / Zip Code
        /// </summary>
        Postcode,

        /// <summary>
        /// Street
        /// </summary>
        Thoroughfare,

        /// <summary>
        /// Specified in ISO 639-2/B format
        /// </summary>
        Language,

        /// <summary>
        /// US Addresses Only: Address type (Commercial or residential)
        /// </summary>
        [EnumMember(Value = "Attributes.CommercialResidencial")]
        CommercialResidencial
    }
}
