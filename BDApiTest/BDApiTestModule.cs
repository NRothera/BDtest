using BDApiTest.Interfaces;
using BDApiTest.Config;
using Ninject.Modules;
using RestSharp;

namespace BDApiTest
{

    public class BDApiTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRestClient>().To<RestClient>().InThreadScope();
            Bind<ITestConfiguration>().To<TestConfiguration>().InSingletonScope();
        }
    }

}
