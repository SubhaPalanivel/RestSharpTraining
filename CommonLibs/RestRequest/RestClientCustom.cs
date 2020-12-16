using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.RestRequest
{
    public class RestClientCustom
    {
        private IRestClient restClient;
       

        public IRestClient RestClientCust { get
            {
                return restClient;
            }
        }
        public RestClientCustom()
        {
            restClient = new RestClient();

        }

        //Get - 2 (Withou Type, with type)
        //POST -2, Put-2, Patch -2, Delete-2

        public IRestResponse SendGetRequest(IRestRequest restRequest)
        {
            return restClient.Get(restRequest);
        }
        public IRestResponse SendGetRequest(IRestRequest restRequest, Dictionary<string, object> queryParameter)
        {
            foreach(var param in queryParameter)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }

            return restClient.Get(restRequest);
        }
        public IRestResponse SendGetRequest(IRestRequest restRequest, Dictionary<string, object> queryParameter, Dictionary<string, string> headers)
        {
            if (queryParameter != null)
            {
                foreach (var param in queryParameter)
                {
                    restRequest.AddParameter(param.Key, param.Value);
                }
            }
            foreach (var param in headers)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }
            return restClient.Get(restRequest);
        }
        public IRestResponse<T> SendGetRequest<T>(IRestRequest restRequest)
        {
            return restClient.Get<T>(restRequest);
        }
        public IRestResponse SendPostRequest(IRestRequest restRequest)
        {
            return restClient.Post(restRequest);
        }
        public IRestResponse<T> SendPostRequest<T>(IRestRequest restRequest)
        {
            return restClient.Post<T>(restRequest);
        }
        public IRestResponse SendPutRequest(IRestRequest restRequest)
        {
            return restClient.Put(restRequest);
        }
        public IRestResponse<T> SendPutRequest<T>(IRestRequest restRequest)
        {
            return restClient.Put<T>(restRequest);
        }
        public IRestResponse SendDeleteRequest(IRestRequest restRequest)
        {
            return restClient.Delete(restRequest);
        }
        public IRestResponse<T> SendDeleteRequest<T>(IRestRequest restRequest, object requestPayload)
        {
            return restClient.Delete<T>(restRequest);
        }
    }
}
