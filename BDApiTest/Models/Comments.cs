using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDApiTest.Models
{
    public class Comments
    {
        [JsonProperty("PostId")]
        public string PostId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
