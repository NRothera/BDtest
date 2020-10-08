using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDApiTest.Models
{
    [JsonArray]
    public class TestFeeModel
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}
