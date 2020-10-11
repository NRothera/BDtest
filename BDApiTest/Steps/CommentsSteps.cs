using BDApiTest.BaseTest;
using BDApiTest.Enums;
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
            Response = await clientHelper.GetResponseForRequestType(RequestType.GET, Url);
        }

    }
}
