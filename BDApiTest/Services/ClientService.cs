using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ninject;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using BDApiTest.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using IRequest = BDApiTest.Interfaces.IRequest;

namespace BDApiTest.services
{

    public abstract class ClientService : IService
    {
        protected readonly RestClient client;
        public IRequest request;
        protected RestResponse response;
        private bool successful;
        public string resource;
        private RestRequest restRequest;
        private CookieContainer _cookieJar = new CookieContainer();

        public ClientService(IRequest request, RestClient client, string resource, ITestConfiguration config)
        {
            this.request = request;
            this.client = client;
            if (client.CookieContainer == null)
            {
                this.client.CookieContainer = _cookieJar;
            }
            this.resource = resource;
        }

        /// <summary>
        /// Invokes the request object to be sent to the service with specified patyh, query params etc
        /// </summary>
        public void invoke(bool expectSuccess = true)
        {
            restRequest = new RestRequest(request.getHttpMethod());
            restRequest.Resource = resource;

            if (request.getQueryParameters() != null)
            {
                addQueryParams();
            }
            if (request.getPathParameters() != null)
            {
                addPathParams();
            }
            try
            {
                this.response = AddHeadersAndExecuteRequest();
            }
            catch (Exception pe)
            {

                Console.WriteLine(pe.Message, pe);
            }
            SetSuccessState();
            if (successful)
            {
                mapResponse();
                checkThatResponseBodyIsPopulated();
            }
           
        }

        protected abstract void mapResponse();

        /// <summary>
        /// Asserts errors returned, allows for fluent chaining
        /// </summary>
        /// <returns>IAssertion object</returns>
        public T assertThatErrors<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        /// <summary>
        /// Asserts that the service returned 200 OK
        /// </summary>
        protected void assertThatServiceCallWasSuccessful()
        {
            response.Should().NotBeNull();
            successful.Should().BeTrue("The service was not called successfully.  Response code was: " + response.StatusCode.ToString());
        }

        /// <summary>
        /// Checks the response was not empty
        /// </summary>
        protected abstract void checkThatResponseBodyIsPopulated();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedResponseContent"></param>
        protected void checkThatResponseBodyIsPopulated(Object expectedResponseContent)
        {
            expectedResponseContent.Should().NotBeNull("The message body was not populated but the service reported a 200 OK");
        }

        /// <summary>
        /// Adds the provided headers and executes the request against the service
        /// </summary>
        /// <returns>RestResponse</returns>
        private RestResponse AddHeadersAndExecuteRequest()
        {

            IRestResponse response = null;
            var stopWatch = new Stopwatch();

            foreach (var header in request.getHeaders().Headers)
            {
                restRequest.AddHeader(header.Name, header.Value);
            }

            switch (request.getHttpMethod())
            {
                case Method.GET:
                    break;
                case Method.POST:
                    restRequest.RequestFormat = DataFormat.Json;
                    restRequest.AddJsonBody(request.getRequestBody());
                    break;
                case Method.PUT:
                    try
                    {
                        restRequest.AddJsonBody(request.getRequestBody());
                    }
                    catch
                    {
                        restRequest.AddJsonBody(request.getRequestBody());
                    }
                    break;
                case Method.DELETE:
                    break;
            }

            try
            {
                stopWatch.Start();
                response = client.Execute(restRequest);
                stopWatch.Stop();

                return response as RestResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing request: " + ex);
            }
            finally
            {
                LogRequest(restRequest, response, stopWatch.ElapsedMilliseconds);
            }

            return null;

        }

        private void SetSuccessState()
        {
            this.successful = (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        private void assertThatServiceCallWasNotSuccessful()
        {
            successful.Should().BeFalse("The service returned a: " + response.StatusCode.ToString() + ":" + response.ErrorMessage);
        }

        /// <summary>
        /// Add the PathParams to the request
        /// </summary>
        private void addPathParams()
        {
            restRequest.Resource = restRequest.Resource.ToString() + request.getPathParameters().resource;
            if (request.getPathParameters().replaceableSegments.Count() > 0)
            {
                foreach (string segment in request.getPathParameters().replaceableSegments)
                {
                    //check that any specified as replacable are actually replaced
                    request.getPathParameters().urlSegments.Where(x => x.Key == segment).FirstOrDefault().Should().NotBeNull("URL Segement defined as pathParameter has not been replaced: " + segment);
                    KeyValuePair<string, string> pathParam = request.getPathParameters().urlSegments.Where(x => x.Key == segment).FirstOrDefault();
                    restRequest.AddParameter(pathParam.Key, pathParam.Value, ParameterType.UrlSegment);
                }
            }
        }

        /// <summary>
        /// Add the QueryParams to the request
        /// </summary>
        private void addQueryParams()
        {
            foreach (KeyValuePair<string, string> queryParam in request.getQueryParameters().getParameters())
            {
                restRequest.AddQueryParameter(queryParam.Key, queryParam.Value);
            }
        }

        private void LogRequest(IRestRequest request, IRestResponse response, long durationMs)
        {

            var requestToLog = new
            {
                resource = request.Resource,
                // Parameters are custom anonymous objects in order to have the parameter type as a nice string
                // otherwise it will just show the enum value
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                // ToString() here to have the method as a nice string otherwise it will just show the enum value
                method = request.Method.ToString(),
                // This will generate the actual Uri used in the request
                uri = client.BuildUri(request),
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                headers = response.Headers,
                responseUri = response.ResponseUri,
                content = JsonConvert.DeserializeObject<dynamic>(response.Content),
                errorMessage = response.ErrorMessage,
            };

            Console.WriteLine(string.Format("Request completed in {0} ms \r\n Request: \r\n {1} \r\n Response: \r\n {2}",
                    durationMs,
                    JsonConvert.SerializeObject(requestToLog, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() }),
                    JsonConvert.SerializeObject(responseToLog, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() })));

        }

        public virtual IResponse getResponse()
        {
            throw new NotImplementedException();
        }

        public virtual T assertThat<T>()
        {
            throw new NotImplementedException();
        }

        private static string Logo = @"+++++++++++++++++++
RESTSERVICE
+++++++++++++++++++";
    }
}
