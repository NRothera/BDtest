using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"{path}/appsettings.json",
                             optional: true,
                             reloadOnChange: true);

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }
        public string BasePostUrl => Configuration["BasePostUrl"];
    }
}
