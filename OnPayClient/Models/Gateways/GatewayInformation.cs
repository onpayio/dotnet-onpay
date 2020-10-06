using Newtonsoft.Json;

namespace OnPayClient.Models.Gateways
{
    public class GatewayInformation
    {
        [JsonProperty("gateway_id")]
        public string GatewayID { get; set; }

        [JsonProperty("active_methods")]
        public string[] ActiveMethods { get; set; }
    }
}
