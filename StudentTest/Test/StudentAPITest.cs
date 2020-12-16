using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using StudentApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Test
{
    [TestClass]
    public class StudentAPITest : BaseTest
    {             
        [TestMethod]
        public void VerifyGetStudentAPIwithQueryparam()
        {
            Dictionary<string, object> queryparam = new Dictionary<string, object>();
            queryparam.Add("page", 5);
            IRestResponse restResponse = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}",queryparam);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
           
        }
        [TestMethod]
        public void VerifyGetStudentIdAPI()
        {
           reportUtils.CreatetestCase("Verify Get Product API-test");
            var id_input = 83416;
            var restResponse = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}/{id_input}");
            reportUtils.AddLogs(Status.Info,$"Response Status Code:{restResponse.StatusCode}");
            var id = restResponse.Data.data.id;
            Assert.AreEqual(id, id_input);
            Console.WriteLine(id);         
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);           
        }
        [TestMethod]
        public void VerifyPostStrudentWithStringRequestPayload()
        {
            string requestPayload = "{\r\n  \"id\": 1,\r\n  \"first_name\": \"Subha\",\r\n  \"middle_name\": \"Palanivel\",\r\n  \"last_name\": \"sample string 4\",\r\n  \"date_of_birth\": \"Jan-01\"\r\n}";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }
        [TestMethod]
        public void VerifyPOSTStudentAPIwithDictionary()
        {
            Dictionary<string, object> requestPayload = new Dictionary<string, object>();
            requestPayload.Add("id",1);
            requestPayload.Add("first_name", "Subha");
            requestPayload.Add("middle_name", "P");
            requestPayload.Add("last_name", "N");
            requestPayload.Add("date_of_birth", "Jan-01");
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
           Console.WriteLine(restResponse.Data.id);
        }
        [TestMethod]
        public void VerifyPOSTStudentAPIwithFileUpload()
        {
            string requestPayLoadJsonFile = $"{currentprojectDirectory}/TestData/student.json";
            string requestPayload = File.ReadAllText(requestPayLoadJsonFile);
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyPOSTStudentAPIwithDto()
        {
            RootPostStudentDto requestPayload = new RootPostStudentDto();
            requestPayload.id = 1234;
            requestPayload.first_name = "Subha";
            requestPayload.last_name = "Palanivel";
            requestPayload.middle_name = "N";
            requestPayload.date_of_birth = "Jan-01";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            Console.WriteLine(restResponse.Data.id);
        }

        [TestMethod]
        public void VerifyEditAndDeleteStudentAPIwithDto()
        {
            RootPostStudentDto requestPayload = new RootPostStudentDto();
            requestPayload.id = 1234;
            requestPayload.first_name = "Subha";
            requestPayload.last_name = "Palanivel";
            requestPayload.middle_name = "N";
            requestPayload.date_of_birth = "Jan-01";
            var restResponse = requestFactory.PostStudent($"{endpointUrl}{studentPOSTResource}", requestPayload);
            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);
            var id = restResponse.Data.id;
            RootPostStudentDto requestPayloadFrUpdate = new RootPostStudentDto();
            requestPayloadFrUpdate.id = id;
            requestPayloadFrUpdate.first_name = "Harish";
            requestPayloadFrUpdate.last_name = "Karthikeyan";
            requestPayloadFrUpdate.middle_name = "N";
            requestPayloadFrUpdate.date_of_birth = "Jan-01";
            var restResponse1 = requestFactory.EditStudent($"{endpointUrl}{studentPOSTResource}/{id}", requestPayloadFrUpdate);
            Assert.AreEqual(HttpStatusCode.OK, restResponse1.StatusCode);
            Console.WriteLine(restResponse1.Data.msg);
            Console.WriteLine(restResponse1.Data.status);

            var restResponse2 = requestFactory.DeleteStudent($"{endpointUrl}{studentPOSTResource}/{id}");
            Assert.AreEqual(HttpStatusCode.OK, restResponse1.StatusCode);           

            
            var restResponse3 = requestFactory.GetAllStudent($"{endpointUrl}{studentGetAllResource}/{id}");
            Assert.AreEqual(HttpStatusCode.OK, restResponse3.StatusCode);


        }

    }
}
