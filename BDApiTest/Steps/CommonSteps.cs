using BDApiTest.BaseTest;
using BDApiTest.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class CommonSteps : BaseTestCommon
    {
        [BeforeTestRun]
        public static void TestInit()
        {
            TestSetupInit();
        }

        [When(@"I deserialise the ""(.*)"" response")]
        public void WhenIDeserialiseTheResponse(string model)
        {
            switch (model)
            {
                case "Post":
                    PostContent = JsonConvert.DeserializeObject<Posts>(Response.Content);
                    break;
                case "Comments":
                    CommentsContent = JsonConvert.DeserializeObject<Comments>(Response.Content);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{model}: Type of model not found");
            }
        }

        [AfterTestRun]
        public static void TestTearDown()
        {
            TestSetupTearDown();
        }
    }
}
