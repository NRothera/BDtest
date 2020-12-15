using Newtonsoft.Json;

namespace WireMockApi.Messages
{
    [JsonObject]
    public class WireMockSavedRequest
    {
        [JsonProperty(PropertyName = "clientIp")]
        public string ClientIp { get; set; }
        
        [JsonProperty(PropertyName = "loggedDate")]
        public string LoggedData { get; set; }
        
        [JsonProperty(PropertyName = "loggedDateString")]
        public string LoggedDateString { get; set; }
        
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}