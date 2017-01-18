using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CurlPOC.EndPoints.Authorize
{
    public class Authorize : SpreedlyEndPoint
    {
        public Authorize(string gatewayToken)
        {

        }

        protected override void FormatResourceUrl(Method method)
        {
            throw new NotImplementedException();
        }

        protected override void SetMethodType(Method method)
        {
            throw new NotImplementedException();
        }
    }
}
