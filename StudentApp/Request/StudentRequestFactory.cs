using CommonLibs.RestRequest;
using RestSharp;
using StudentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Request
{
    public class StudentRequestFactory
    {
        RestClientCustom restClient;
        public StudentRequestFactory()
        {
            restClient = new RestClientCustom();
        }
       

        public IRestResponse GetAllStudent(string endpointUrl, Dictionary<string, object>queryparameter)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);
            IRestResponse restResponse = restClient.SendGetRequest(restRequest,queryparameter);
            return restResponse;
        }
        public IRestResponse<RootStudentDto> GetAllStudent(string endpointUrl)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);
            var restResponse = restClient.SendGetRequest<RootStudentDto>(restRequest);
            return restResponse;
        }
        public IRestResponse<RootPostStudentDto> PostStudent(string endpointUrl, object requestPayload)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);
            restRequest.AddJsonBody(requestPayload);
            var restResponse = restClient.SendPostRequest<RootPostStudentDto>(restRequest);
            return restResponse;
        }

        public IRestResponse<RootPutStudentResponseDto> EditStudent(string endpointUrl, object requestPayload)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);
            restRequest.AddJsonBody(requestPayload);
            var restResponse = restClient.SendPutRequest<RootPutStudentResponseDto>(restRequest);
            return restResponse;
        }

        public IRestResponse DeleteStudent(string endpointUrl)
        {
            RestRequest restRequest = new RestRequest(endpointUrl);
            var restResponse = restClient.SendDeleteRequest(restRequest);
            return restResponse;

        }
    }
}
