using BDApiTest.BaseTest;
using BDApiTest.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BDApiTest.Helpers
{
    public class ClientHelper : BaseTestCommon
    {
        private RestClient BuildClient(string url)
        {
            Client = new RestClient(url);
            Client.Timeout = -1;

            return Client;
        }

        public async Task<IRestResponse> GetResponseForRequestType(RequestType requestType, string url)
        {
            IRestResponse response; 

            var watch = new Stopwatch();

            BuildClient(url);

            try
            {
                switch (requestType)
                {
                    case RequestType.GET:
                        Request = new RestRequest(Method.GET);

                        // Keep track of how long it takes to get the response
                        watch.Start();
                        response = await Client.ExecuteAsync(Request);
                        watch.Stop();
                        ResponseTime = watch.ElapsedMilliseconds;
                        return response;
                    default:
                        return null;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
