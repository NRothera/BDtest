using BDApiTest.Services.Responses.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDApiTest.Services.requests
{
    public class GetCountryResponse : Response
    {
        public List<Country> Countries { get; set; }

        public GetCountryResponse()
        {
            Countries = new List<Country>();
        }
    }
}
