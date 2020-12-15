using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using BDApiTest.Interfaces;
using BDApiTest.Services.requests;
using BDApiTest.Services.Responses.Models;

namespace BDApiTest.services
{
    public class RestCountriesService : ClientService
    {
        public GetCountryResponse getCountryResponse { get; set; }

        public RestCountriesService(IRequest request, RestClient client, ITestConfiguration config)
            : base(request, client, config.BasePostUrl, config)
        {
        }

        public override T assertThat<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), getCountryResponse);
        }

        public override IResponse getResponse()
        {
            assertThatServiceCallWasSuccessful();
            return getCountryResponse;
        }

        protected override void checkThatResponseBodyIsPopulated()
        {
            checkThatResponseBodyIsPopulated(getCountryResponse);
        }

        protected override void mapResponse()
        {
            getCountryResponse = new GetCountryResponse();
            getCountryResponse.Countries = JsonConvert.DeserializeObject<List<Country>>(response.Content);
        }
    }
}
