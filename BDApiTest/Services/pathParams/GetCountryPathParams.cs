using System;
using System.Collections.Generic;
using System.Text;

namespace  BDApiTest.services.pathParams
{
    public class GetCountryPathParams : PathParams
    {
        public GetCountryPathParams(countryPath path)
        {
            resource = path.resource;
        }
    }

    public static class countryPaths
    {
        /// <summary>
        /// <para>Resource used to get an existing country</para>
        /// <para>Method: GET</para>
        /// <para>URLSegements to be replaced: name</para>
        /// </summary>
        public static countryPath GET_COUNTRY_BY_NAME = new countryPath() { Method = "GET", resource = "/name/{name}" };

    }

    public class countryPath
    {
        public string Method { get; set; }
        public string resource { get; set; }
    }

}
