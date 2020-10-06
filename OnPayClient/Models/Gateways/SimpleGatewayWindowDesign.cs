using Newtonsoft.Json;

namespace OnPayClient.Models.Gateways
{
    public class SimpleGatewayWindowDesign
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
