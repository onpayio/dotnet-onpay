using Newtonsoft.Json;

namespace OnPayClient.Models.MetaData
{
    public class Link
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("subscription")]
        public string Subscription { get; set; }
    }
}
