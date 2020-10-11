using BDApiTest.BaseTest;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class CommentsSteps : BaseTestCommon
    {
        [Given(@"I request a comment with id (.*)")]
        public async Task GivenIRequestACommentWithId(int id)
        {
            Id = id;

            Url = $"{testConfiguration.BasePostUrl}/{id}/comments";
            Response = await GetResponseFrom(Url);
        }

    }
}
