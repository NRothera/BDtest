using System.Collections.Generic;

namespace BDApiTest.Interfaces
{
    public interface IQueryParams
    {
        /// <summary>
        /// Dictionary of keyvalue pairs to be used in query string
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> getParameters();
    }
}