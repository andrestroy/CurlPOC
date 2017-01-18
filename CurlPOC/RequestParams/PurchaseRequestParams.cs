using CurlPOC.RequestParams;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurlPOC
{
    
   
    [SerializeAs(Name = SerializeNamesConsts.transaction)]
    public class PurchaseRequestParams : RequestBody
    {
        [SerializeAs(Name = "payment_method_token")]
        public string PaymentMethodToken { get; set; }
        [SerializeAs(Name = "amount")]
        public int Amount { get; set; }
        [SerializeAs(Name = "currency_code")]
        public string CurrencyCode { get; set; }
        [SerializeAs(Name = "retain_on_success")]
        public bool RetainOnSuccess { get; set; }

        [SerializeAs(Name = "credit_card")]
        public CreditCardParam CreditCard { get; set; }
        public void DoSomething()
        {

        }
        //[XmlIgnore]
        public string DummyProperty { get; set; }
    }
}
