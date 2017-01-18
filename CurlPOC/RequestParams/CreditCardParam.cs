using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlPOC
{
    [SerializeAs(Name = "credit_card")]
    public class CreditCardParam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
