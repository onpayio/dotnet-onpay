using System;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using OnPayClient.Models.Converters;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.Subscriptions.Enums;
using OnPayClient.Models.Subscriptions.MetaData;
using OnPayClient.Models.Transactions;

using RestSharp;

namespace OnPayClient.Models.Subscriptions
{
    public class DetailedSubscription : BaseModel
    {
        [JsonProperty("3dsecure")]
        public bool Secure3d { get; internal set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; internal set; }

        [JsonProperty("card_bin")]
        public string CardBin { get; internal set; }

        [JsonProperty("card_type")]
        [JsonConverter(typeof(CardTypeConverter))]
        public CardType CardType { get; internal set; }

        [JsonProperty("card_country")]
        public int CardCountry { get; internal set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Created { get; internal set; }

        [JsonProperty("currency_code")]
        public int CurrencyCode { get; internal set; }

        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; internal set; }

        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; internal set; }

        [JsonProperty("ip")]
        public string IP { get; internal set; }

        [JsonProperty("ip_country")]
        public int IPCountry { get; internal set; }

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

        [JsonProperty("transactions")]
        public SimpleTransaction[] Transactions { get; internal set; }

        [JsonProperty("history")]
        public SubscriptionHistory[] History { get; internal set; }

        public AtomicResponse<DetailedTransaction> Authorize(int amount, string orderId, SurchargeSettings surcharge = null)
        {
            var request = PrepareAuthorizeRequest(amount, orderId, surcharge);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> AuthorizeAsync(int amount, string orderId, SurchargeSettings surcharge = null)
        {
            var request = PrepareAuthorizeRequest(amount, orderId, surcharge);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public AtomicResponse<DetailedSubscription> Cancel()
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{Uuid}/cancel", Method.POST);
            var response = _client.Execute<AtomicResponse<DetailedSubscription>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedSubscription>> CancelAsync()
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{Uuid}/cancel", Method.POST);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedSubscription>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        internal override void DecorateWithRestClient(RestClient client)
        {
            base.DecorateWithRestClient(client);

            foreach (var transaction in Transactions)
                transaction.DecorateWithRestClient(client);
        }

        private RestRequest PrepareAuthorizeRequest(int amount, string orderId, SurchargeSettings surcharge)
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{Uuid}/authorize", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddJsonBody(
                new
                {
                    data = new
                    {
                        amount,
                        order_id = orderId,
                        surcharge_enabled = surcharge?.Enabled,
                        surcharge_vat_rate = surcharge?.VatRate,
                    }
                });
            return request;
        }
    }
}
