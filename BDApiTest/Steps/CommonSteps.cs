using BDApiTest.BaseTest;
using BDApiTest.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Linq;
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

        //Givens


        //Whens

        [Given(@"I get a (.*) response")]
        public void GivenIGetAResponse(int statusCode)
        {
            Response.StatusCode.Should().Be(statusCode);
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
                    CommentsList = JsonConvert.DeserializeObject<Comments[]>(Response.Content);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{model}: Type of model not found");
            }
        }

        [Then(@"the ""(.*)"" response contains all the required properties")]
        public void ThenTheResponseContainsAllTheRequiredProperties(string responseType)
        {
            switch (responseType)
            {
                case ("Post"):

                    PostContent.Id.Should().Equals(Id.ToString());
                    PostContent.Title.Should().BeOfType(typeof(string));
                    PostContent.Body.Should().BeOfType(typeof(string));
                    PostContent.UserId.Should().BeOfType(typeof(int));
                    break;

                case ("Comments"):

                    foreach (var comment in CommentsList)
                    {
                        comment.Name.Should().BeOfType(typeof(string));
                        IsValidEmail(comment.Email).Should().BeTrue();
                        comment.PostId.Should().BeOfType(typeof(string));
                    }
                    break;

                default:
                    break;
            }
        }
      
        [Then(@"I can validate that the ""(.*)"" response is empty")]
        public void ThenICanValidateThatTheResponseIsEmpty(string responseType)
        {
            switch (responseType)
            {
                case ("Post"):

                    PostContent.Id.Should().Be(0);
                    PostContent.Title.Should().BeNullOrEmpty();
                    PostContent.Body.Should().BeNullOrEmpty();
                    PostContent.UserId.Should().Be(0);
                    break;

                case ("Comments"):

                    CommentsList.Should().BeEmpty();
                    break;

                default:
                    break;
            }
        }

        [Then(@"I ensure the server set response headers are correct")]
        public void ThenIEnsureTheServerSetResponseHeadersAreCorrect()
        {
            var cacheControl = GetResponseHeader("Cache-Control");
            var xRateLimit = GetResponseHeader("X-Ratelimit-Limit");
            var contentType = GetResponseHeader("Content-Type").Split(";")[0];
            var accessControl = GetResponseHeader("Access-Control-Allow-Credentials");

            cacheControl.Should().BeEquivalentTo("max-age=43200");
            xRateLimit.Should().BeEquivalentTo("1000");
            contentType.Should().BeEquivalentTo("application/json");
            accessControl.Should().BeEquivalentTo("true");
        }

        [Then(@"I can check the response time is under (.*) milliseconds")]
        public void ThenICanCheckTheResponseTimeIsUnderMilliseconds(int maxResponseTime)
        {
            ResponseTime.Should().BeLessThan(maxResponseTime);
        }


        [AfterTestRun]
        public static void TestTearDown()
        {
            TearDown();
        }
    }
}
