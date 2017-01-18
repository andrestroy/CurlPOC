using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using RestSharp.Serializers;
using RestSharp.Authenticators;

namespace CurlPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListCreatedGateways();
            //SimplePurchase();
            //Authorize();
            //Capture();
            //PurchaseWithRestSharp();
            //SerializeXmlAndPurchase();
            //ImportCreditCards();
            ImportSeveralCreditCards();
        }

       
        private static void ListCreatedGateways()
        {
            var spreedlyURL = "https://core.spreedly.com/v1/gateways.xml";
            WebRequest request = WebRequest.Create(spreedlyURL);
            request.ContentType = "application/xml";
            request.Method = "GET";

            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials = new NetworkCredential(envKey, secretKey);
            WebResponse response = request.GetResponse();
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {

                Console.WriteLine(reader.ReadToEnd());
            }
            response.Close();
        }

        private static void SerializeXmlAndPurchase()
        {
            var client = new RestClient("https://core.spreedly.com/v1/");
            var request = new RestRequest("gateways/MALJynmKZOxoNIV0F5gLEHkR9mp/purchase.xml", Method.POST);
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials =  new NetworkCredential(envKey, secretKey);

            CreditCardParam creditCard = new CreditCardParam { FirstName = "Andres", LastName = "Villarroel" };
            RequestBody bodyRequest = new PurchaseRequestParams { PaymentMethodToken = "GccmkUsxEUw02AjZBs4T2Dv4c4q",
                Amount = 100, RetainOnSuccess = true, CurrencyCode = "USD", CreditCard = creditCard
            };
            request.RequestFormat = DataFormat.Xml;
            var serializer = new RestSharp.Serializers.XmlSerializer();
            request.AddParameter("application/xml", serializer.Serialize(bodyRequest), ParameterType.RequestBody);
            
            //request.AddXmlBody(bodyRequest);

            IRestResponse response = client.Execute(request);
        }
        private static void PurchaseWithRestSharp()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var client = new RestClient("https://core.spreedly.com/v1/");
            var request = new RestRequest("gateways/MALJynmKZOxoNIV0F5gLEHkR9mp/purchase.xml", Method.POST);
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials =  new NetworkCredential(envKey, secretKey);
            
            XElement paymentMethodToken = new XElement("payment_method_token", "GccmkUsxEUw02AjZBs4T2Dv4c4q");
            XElement amount = new XElement("amount", "100");
            XElement currencyCode = new XElement("currency_code", "USD");
            XElement retainOnSuccess = new XElement("retain_on_success", "true");
            XElement transaction = new XElement("transaction", new object[] { paymentMethodToken, amount, currencyCode, retainOnSuccess });
            request.AddParameter("application/xml", transaction.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            sw.Stop();
            XDocument result = XDocument.Parse(response.Content);
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            
        }

        private static void SimplePurchase()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var spreedlyURL = "https://core.spreedly.com/v1/gateways/MALJynmKZOxoNIV0F5gLEHkR9mp/purchase.xml";
            WebRequest request = WebRequest.Create(spreedlyURL);
            request.ContentType = "application/xml";
            request.Method = "POST";
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials = new NetworkCredential(envKey, secretKey);
            XElement paymentMethodToken = new XElement("payment_method_token", "GccmkUsxEUw02AjZBs4T2Dv4c4q");
            XElement amount = new XElement("amount", "100");
            XElement currencyCode = new XElement("currency_code", "USD");
            XElement retainOnSuccess = new XElement("retain_on_success", "true");
            XElement transaction = new XElement("transaction", new object[] { paymentMethodToken, amount, currencyCode, retainOnSuccess });
            byte[] buffer = Encoding.UTF8.GetBytes(transaction.ToString());
            request.ContentLength = buffer.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, buffer.Length);
            }
            WebResponse response = request.GetResponse();
            sw.Stop();
            XmlDocument xmlDoc = new XmlDocument();
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                xmlDoc.LoadXml(reader.ReadToEnd());
            }
           
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        private static XmlDocument Authorize()
        {
            var spreedlyURL = "https://core.spreedly.com/v1/gateways/MALJynmKZOxoNIV0F5gLEHkR9mp/authorize.xml";
            WebRequest request = WebRequest.Create(spreedlyURL);
            request.ContentType = "application/xml";
            request.Method = "POST";
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials = new NetworkCredential(envKey, secretKey);
            XElement paymentMethodToken = new XElement("payment_method_token", "GccmkUsxEUw02AjZBs4T2Dv4c4q");
            XElement amount = new XElement("amount", "100");
            XElement currencyCode = new XElement("currency_code", "USD");
            XElement transaction = new XElement("transaction", new object[] { paymentMethodToken, amount, currencyCode });
            byte[] buffer = Encoding.UTF8.GetBytes(transaction.ToString());
            request.ContentLength = buffer.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, buffer.Length);
            }
            WebResponse response = request.GetResponse();
            XmlDocument xmlDoc = new XmlDocument();
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {

                xmlDoc.LoadXml(reader.ReadToEnd());
            }

            return xmlDoc;
        }

        private static XmlDocument Capture()
        {
            var spreedlyURL = "https://core.spreedly.com/v1/transactions/Z8hueMv3JOvr4PfQhZjASLFoU4b/capture.xml";
            WebRequest request = WebRequest.Create(spreedlyURL);
            request.ContentType = "application/xml";
            request.Method = "POST";
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";
            request.Credentials = new NetworkCredential(envKey, secretKey);
            XElement amount = new XElement("amount", "100");
            XElement currencyCode = new XElement("currency_code", "USD");
            XElement transaction = new XElement("transaction", new object[] { amount, currencyCode });
            byte[] buffer = Encoding.UTF8.GetBytes(transaction.ToString());
            request.ContentLength = buffer.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, buffer.Length);
            }
            WebResponse response = request.GetResponse();
            XmlDocument xmlDoc = new XmlDocument();
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {

                xmlDoc.LoadXml(reader.ReadToEnd());
            }

            return xmlDoc;
        }

        public static void ImportCreditCards()
        {
            var client = new RestClient("https://core.spreedly.com/v1/");
            var request = new RestRequest("payment_methods.xml", Method.POST);
            var envKey = "LgqmnvVR1opYcGRaRawuHpmPMdS";
            var secretKey = "hDsGCBb58l5MS1sfmx0iPtzC6k02YwtVWbbQN80O5wVqphAAPTtICiPklZ0cwOyv";

            XElement firstName = new XElement("first_name", "Mario");
            XElement lastName = new XElement("last_name", "Brow");
            XElement number = new XElement("number", "5555555555554444");
            XElement verificationNumber = new XElement("verification_value", 423);
            XElement month = new XElement("month", "3");
            XElement year = new XElement("year", "2021");

            XElement creditCard = new XElement("credit_card", new object[] { firstName, lastName, number, verificationNumber, month, year});
            XElement paymentMethod = new XElement("payment_method", new object[] { creditCard, new XElement("email", "mario.brow@jala.com") });
            request.AddParameter("application/xml", paymentMethod.ToString(), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Xml;

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(envKey + ":" + secretKey));
            request.AddHeader("Authorization", "Basic " + encoded);
            IRestResponse response = client.Execute(request);
            XDocument result = XDocument.Parse(response.Content);
        }

        public static void ImportSeveralCreditCards()
        {
            for (int i = 0; i < 1000; i++)
            {
                ImportCreditCards();
            }
            Console.ReadKey();
        }
    }
}
