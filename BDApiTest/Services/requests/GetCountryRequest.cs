using  BDApiTest.services.headers;
using  BDApiTest.services.pathParams;
using BDApiTest.Services.Requests;

namespace  BDApiTest.services.requests
{
    public class GetCountryRequest : Request
    {
        public GetCountryRequest(RESTHeaders headers, PathParams pathParameters) 
            : base(headers, RestSharp.Method.GET, pathParameters, null, null)
        {
        }
    }
}
