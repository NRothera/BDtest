using BDApiTest.BaseTest;
using BDApiTest.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class CommentsSteps : BaseTestCommon
    {
        [Given(@"I request a comment with id (.*)")]
        public void GivenIRequestACommentWithId(int id)
        {
            var postUrl = $"{testConfiguration.BasePostUrl}/{id}/comments";
            Client = new RestClient(postUrl);
            Client.Timeout = -1;
            Request = new RestRequest(Method.GET);
            Response = Client.Execute(Request);
        }

        [Then(@"I can validate the response")]
        public void ThenICanValidateTheResponse()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
