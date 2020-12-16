using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace AzureDevOpsTest
{
    [TestClass]
    public class AzureDevOpsAPITest
    {
        [TestMethod]
        public void GetAllProjectUrl()
        {
            string endpointUrl = "devOpsUrl";
            IRestClient  restClinet = new RestClient();
            restClinet.Authenticator = new HttpBasicAuthenticator("username", "password");
            IRestRequest restRequest = new RestRequest(endpointUrl);
            IRestResponse restResponse = restClinet.Get(restRequest);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);



        }
    }
}
