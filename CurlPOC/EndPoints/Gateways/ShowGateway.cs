using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CurlPOC.EndPoints.Gateways
{
    public class ShowGateway : SpreedlyEndPoint
    {
        public ShowGateway(string gatewayToken) : base(gatewayToken)
        {
            
        }

        protected override void FormatResourceUrl(Method method)
        {
            this.resource = string.Format("/gateways/{0}.<format>", this.token);
        }

        protected override void SetMethodType(Method method)
        {
            throw new NotImplementedException();
        }
    }
}
