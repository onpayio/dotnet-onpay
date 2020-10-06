using Newtonsoft.Json;

namespace OnPayClient.Models.Gateways
{
    public class GatewayWindowIntegration
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
