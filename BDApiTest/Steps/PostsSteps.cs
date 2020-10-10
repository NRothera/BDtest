using BDApiTest.BaseTest;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class PostsSteps : BaseTestCommon
    {
        [Given(@"I request a post with id (.*)")]
        public void GivenIRequestAPostWithId(int id)
        {
            Id = id;

            Url = $"{testConfiguration.BasePostUrl}/{id}";
            GetResponseFrom(Url);
        }
    }
}
