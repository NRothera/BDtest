using BDApiTest.services.pathParams;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDApiTest.Interfaces
{
    public interface IRequest
    {
        /// <summary>
        /// Get all headers for a request
        /// </summary>
        /// <returns></returns>
        IHeaders getHeaders();

        /// <summary>
        /// Gets all query parameters for a request
        /// </summary>
        /// <returns></returns>
        IQueryParams getQueryParameters();

        /// <summary>
        /// Gets the request body for a request
        /// </summary>
        /// <returns></returns>
        IRequestBody getRequestBody();

        /// <summary>
        /// Sets the HTTP method for the request, eg GET, POST
        /// </summary>
        /// <returns></returns>
        RestSharp.Method getHttpMethod();

        /// <summary>
        /// Gets the pathParameters for a request
        /// </summary>
        /// <returns></returns>
        PathParams getPathParameters();
    }
}
