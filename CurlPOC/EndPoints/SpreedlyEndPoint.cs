using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurlPOC.EndPoints
{
    public abstract class SpreedlyEndPoint
    {
        private readonly string format;
        protected string token;
        protected string baseUrl;
        protected string resource;
        public SpreedlyEndPoint()
        {
            // TODO get base url from Resources.resx
            this.baseUrl = "https://core.spreedly.com/v1/";
            this.format = "xml";
        }

        public SpreedlyEndPoint(string token) : this()
        {
            this.token = token;
            
        }



        private void AddResourceFormat()
        {
            this.resource = this.resource.Replace("<format>", this.format);
        }
        public XElement ExecuteRequest(RequestBody requestBody)
        {
            this.AddResourceFormat();
            return null;
        }
        public XElement ExecuteRequest()
        {
            return this.ExecuteRequest(null);
        }

        public virtual void AddUrlParams()
        {

        }
        //Abstract methods
        protected abstract void SetMethodType(Method method);
        protected abstract void FormatResourceUrl(Method method);
    }
}
