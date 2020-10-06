using Newtonsoft.Json;

namespace OnPayClient.Models.Transactions
{
    public class Extra
    {
        [JsonProperty("mpo_email_validity")]
        public bool MpoEmailValidity { get; internal set; }

        [JsonProperty("mpo_phone_validity")]
        public bool MpoPhoneValidity { get; internal set; }

        [JsonProperty("mpo_address_validity")]
        public bool MpoAddressValidity { get; internal set; }

        [JsonProperty("mpo_address_customer_connected")]
        public bool MpoAddressCustomerConnected { get; internal set; }

        [JsonProperty("mpo_delivery_address_validity")]
        public bool MpoDeliveryAddressValidity { get; internal set; }

        [JsonProperty("mpo_delivery_address_customer_connected")]
        public bool MpoDeliveryAddressCustomerConnected { get; internal set; }
    }
}
