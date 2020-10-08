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
        protected BaseTestCommon()
        {

        }

        #region Fields    

        protected static IKernel Kernel;

        #endregion

        #region Restsharp Properties

        public static IRestRequest Request { get; set; }
        public static IRestResponse Response { get; set; }
        public static RestClient Client { get; set; }

        #endregion

        #region Model Properties

        public static Posts PostContent { get; set; }
        public static Comments CommentsContent { get; set; }

        #endregion

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

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
