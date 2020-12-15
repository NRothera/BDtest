using System;
using System.Collections.Generic;
using System.Text;

namespace BDApiTest.Interfaces
{
    public interface IService
    {
        /// <summary>
        /// Invokes the service call
        /// </summary>
        //public abstract 
        void invoke(bool expectSuccess = true);

        /// <summary>
        /// Cast the response on return, eg "basket.getResponse().CastAs&ltBasketResponse&gt()"
        /// </summary>
        /// <returns>IResponse object</returns>
        //public abstract 
        IResponse getResponse();

        /// <summary>
        /// Chains the Errors Assertion for fluent syntax
        /// </summary>
        /// <returns></returns>
        //public abstract 
        T assertThatErrors<T>();

        /// <summary>
        /// Return the errors
        /// </summary>
        /// <returns></returns>
        //public abstract 
        /// <summary>
        /// Chains the Assertions for the service for fluent syntax
        /// </summary>
        /// <returns></returns>
        //public abstract 
        //IAssertion assertThat();
        T assertThat<T>();
    }
}
