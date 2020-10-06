using Newtonsoft.Json;

namespace OnPayClient.Models.Transactions
{
    public class DeliveryAddress
    {
        [JsonProperty("first_name")]
        public string FirstName { get; internal set; }

        [JsonProperty("last_name")]
        public string LastName { get; internal set; }

        [JsonProperty("attention")]
        public string Attention { get; internal set; }

        [JsonProperty("company")]
        public string Company { get; internal set; }

        [JsonProperty("street")]
        public string Street { get; internal set; }

        [JsonProperty("number")]
        public string Number { get; internal set; }

        [JsonProperty("floor")]
        public string Floor { get; internal set; }

        [JsonProperty("door")]
        public string Door { get; internal set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; internal set; }

        [JsonProperty("country")]
        public int Country { get; internal set; }
    }
}
