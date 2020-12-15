using  BDApiTest.services.headers;
using  BDApiTest.services.pathParams;
using BDApiTest.Services.Requests;
using RestSharp;

namespace  BDApiTest.services.requests
{
    public class GetPaymentInitDetailsRequest : Request
    {
        public GetPaymentInitDetailsRequest(RESTHeaders headers, PathParams pathParameters)
        : base(headers, Method.POST, pathParameters, null, null)
        {            
        }     
    }
}
