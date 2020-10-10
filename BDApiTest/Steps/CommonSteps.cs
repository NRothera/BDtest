using BDApiTest.BaseTest;
using BDApiTest.Models;
using FluentAssertions;
using Newtonsoft.Json;
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

        // Thens
        [Then(@"I can validate the ""(.*)"" response")]
        public void ThenICanValidateTheResponse(string responseType)
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
        public void ThenICanValidateThatTheResponseIsEmpty(string responseType
            )
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


        [AfterTestRun]
        public static void TestTearDown()
        {
            TestSetupTearDown();
        }
    }
}
