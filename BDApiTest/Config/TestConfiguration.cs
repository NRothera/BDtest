using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDApiTest.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BDApiTest.Config
{
    public class TestConfiguration : ITestConfiguration
    {
        public TestConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appConfig.json",
                             optional: true,
                             reloadOnChange: true)
                .AddEnvironmentVariables();

            //builder.AddUserSecrets<TestConfiguration>(true);
            builder.AddUserSecrets<TestConfiguration>(true);
            
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        public string BaseUrl => Configuration["BaseUrl"];
    }
}
