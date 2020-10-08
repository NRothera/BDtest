using BDApiTest.BaseTest;
using BDApiTest.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class PostsSteps : BaseTestCommon
    {
        [Given(@"I request a post with id (.*)")]
        public void GivenIRequestAPostWithId(int id)
        {
            var postUrl = $"{testConfiguration.BasePostUrl}/{id}";
            Client = new RestClient(postUrl);
            Client.Timeout = -1;
            Request = new RestRequest(Method.GET);
            Response = Client.Execute(Request);
        }
      
        [Then(@"I can validate the")]
        public void ThenICanValidateTheResponse()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
