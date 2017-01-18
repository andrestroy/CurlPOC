using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlPOC
{
    [SerializeAs(Name = "transaction")]
    public class RequestBody
    {
        [SerializeAs(Name ="gateway_specific_fields")]
        public GatewaySpecificFields SpecificFields { get; set; }
    }
}
