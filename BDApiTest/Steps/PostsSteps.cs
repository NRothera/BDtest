using BDApiTest.BaseTest;
using BDApiTest.Enums;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDApiTest.Steps
{
    [Binding]
    public class PostsSteps : BaseTestCommon
    {
        [Given(@"I request a post with id (.*)")]
        public async Task GivenIRequestAPostWithId(int id)
        {
            Id = id;

            Url = $"{testConfiguration.BasePostUrl}/{id}";
            Response = await clientHelper.GetResponseForRequestType(RequestType.GET, Url);
        }
    }
}
