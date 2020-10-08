using Newtonsoft.Json;

namespace OnPayClient.Models.Transactions
{
    public class TransactionCardholderData
    {
        [JsonProperty("first_name")]
        public string FirstName { get; internal set; }

        [JsonProperty("last_name")]
        public string LastName { get; internal set; }

        [JsonProperty("attention")]
        public string Attention { get; internal set; }

        [JsonProperty("company")]
        public string Company { get; internal set; }

        [JsonProperty("City")]
        public string City { get; internal set; }

        [JsonProperty("address1")]
        public string Address1 { get; internal set; }

        [JsonProperty("address2")]
        public string Address2 { get; internal set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; internal set; }

        [JsonProperty("country")]
        public int Country { get; internal set; }

        [JsonProperty("email")]
        public string Email { get; internal set; }

        [JsonProperty("phone")]
        public string Phone { get; internal set; }

        [JsonProperty("delivery_address")]
        public DeliveryAddress DeliveryAddress { get; internal set; }

        [JsonProperty("extra")]
        public Extra Extra { get; internal set; }

    }
}
