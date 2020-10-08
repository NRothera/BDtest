using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BDApiTest.Interfaces;
using Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Configuration;
using RestSharp;
using BDApiTest.Models;
using System.Web;
using System.Reflection;

namespace BDApiTest.BaseTest
{
    [Binding]
    public class BaseTestCommon
    {
        #region Fields    

        protected static IKernel Kernel;

        public TestFeeModel testFeeModel;

        #endregion

        protected BaseTestCommon()
        {

        }

        public static ITestConfiguration testConfiguration;

        //[TestInitialize]
        public static void TestSetupInit()
        {
            Kernel = new StandardKernel(new BDApiTestModule());
            var config = Kernel.Get<ITestConfiguration>();
            testConfiguration = config;
        }

        //[TestCleanup]
        public static void TestSetupTearDown()
        {
            Kernel?.Dispose();
        }

        public static IRestRequest Request { get; set; }
        public static IRestResponse Response { get; set; }
        public static RestClient Client { get; set; }
        public string FeeServiceEndpont { get; set; }
        public RestRequest FeeServiceRequest { get; set; }
        public RestRequest PermitToFlyRequest { get; set; }

        [BeforeScenario]
        public void TestSetup()
        {
            testFeeModel = Kernel.Get<TestFeeModel>();
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
        public string PermitQueryBuild(string url, string consumerId, string consumerIp, string clientConsumerIp, string userID, string feeDate,
            string applicationType, string regulation, string weight, string applicantType)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["ConsumerId"] = consumerId;
            query["ConsumerIp"] = consumerIp;
            query["ClientConsumerIP"] = clientConsumerIp;
            query["UserID"] = userID;
            query["FeeDate"] = feeDate;
            query["ApplicationType"] = applicationType;
            query["Regulation"] = regulation;
            query["MaxTakeOffWeightActual"] = weight;
            query["ApplicantType"] = applicantType;
            uriBuilder.Query = query.ToString();

            var queryUrl = uriBuilder.ToString();
            return queryUrl;
        }

        public List<string[]> GetCsvData()
        {
            var column1 = new List<string[]>();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(path);
            using (var rd = new StreamReader(path + "/Utilities/PermitToFly.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    column1.Add(splits);
                }

                return column1;
            }
        }
    }
}
