using BDApiTest.BaseTest;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class CommentsSteps : BaseTestCommon
    {
        [Given(@"I request a comment with id (.*)")]
        public void GivenIRequestACommentWithId(int id)
        {
            Id = id;

            Url = $"{testConfiguration.BasePostUrl}/{id}/comments";
            GetResponseFrom(Url);
        }

    }
}
