using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDApiTest.Models
{
    [JsonArray]
    public class Comments
    {
        public string postId { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
