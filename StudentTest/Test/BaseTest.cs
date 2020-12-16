using AventStack.ExtentReports;
using CommonLibs.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApp.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace StudentTest.Test
{
    [TestClass]
    public class BaseTest
    {
        public StudentRequestFactory requestFactory;
        public string endpointUrl;
        public string studentGetAllResource;
        public string studentPOSTResource;
        public static string currentSolutionDirectory;
        public static string currentprojectDirectory;
       
        public static ExtentReportUtils reportUtils;

        [AssemblyInitialize]
        public static void PreSetup(TestContext context)
        {
            string currentworkingDirectory = Environment.CurrentDirectory;
            currentprojectDirectory = Directory.GetParent(currentworkingDirectory).Parent.FullName;
            Console.WriteLine(currentprojectDirectory);
            currentSolutionDirectory = Directory.GetParent(currentworkingDirectory).Parent.Parent.Parent.FullName;
            Console.WriteLine("Setup");           
             string reportFilename = $"{currentprojectDirectory}/Reports/restSharp-report.html";           
            reportUtils = new ExtentReportUtils(reportFilename);
            Console.WriteLine("PreSetup");
        }
        [TestInitialize]
        public void Setup()
        {
           
            requestFactory = new StudentRequestFactory();
            endpointUrl = ConfigurationManager.AppSettings["endpointUrl"].ToString();
           // endpointUrl = "http://thetestingworldapi.com";
            studentGetAllResource = "/api/studentsDetails";
            studentPOSTResource = "/api/studentsDetails";           
            reportUtils.CreatetestCase("Pre-requisite");
            reportUtils.AddLogs(Status.Info, $"Executing test case at environment");

        }
        

       

    }
}
