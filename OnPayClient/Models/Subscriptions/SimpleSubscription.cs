using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using OnPayClient.Models.Converters;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.MetaData;
using OnPayClient.Models.Subscriptions.Enums;

using RestSharp;

namespace OnPayClient.Models.Subscriptions
{
    public class SimpleSubscription : BaseModel
    {
        [JsonProperty("3dsecure")]
        public bool Secure3d { get; internal set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; internal set; }

        [JsonProperty("card_type")]
        [JsonConverter(typeof(CardTypeConverter))]
        public CardType CardType { get; internal set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Created { get; internal set; }

        [JsonProperty("currency_code")]
        public int CurrencyCode { get; internal set; }

        [JsonProperty("order_id")]
        public string OrderID { get; internal set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; internal set; }

        [JsonProperty("subscription_number")]
        public string SubscriptionNumber { get; internal set; }

        [JsonProperty("uuid")]
        public string Uuid { get; internal set; }

        [JsonProperty("wallet")]
        public string Wallet { get; internal set; }

        public Link Links { get; internal set; }

        public AtomicResponse<DetailedSubscription> Details()
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{Uuid}", Method.GET);
            var response = _client.Execute<AtomicResponse<DetailedSubscription>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedSubscription>> DetailsAsync()
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{Uuid}", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedSubscription>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }
    }
}
