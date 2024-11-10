using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using OnPayClient.Models.Converters;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.Transactions.Enums;
using OnPayClient.Models.Transactions.Enums.Converters;

using RestSharp;

namespace OnPayClient.Models.Transactions
{
    public class DetailedTransaction : BaseModel
    {
        internal DetailedTransaction() { }

        [JsonProperty("3dsecure")]
        public bool _3dsecure { get; internal set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; internal set; }

        [JsonProperty("amount")]
        public int Amount { get; internal set; }

        [JsonProperty("card_bin")]
        public string CardBin { get; internal set; }

        [JsonProperty("card_type")]
        [JsonConverter(typeof(CardTypeConverter))]
        public CardType CardType { get; internal set; }

        [JsonProperty("card_country")]
        public int CardCountry { get; internal set; }

        [JsonProperty("charged")]
        public int Charged { get; internal set; }

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

        [JsonProperty("refunded")]
        public int Refunded { get; internal set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StatusConverter))]
        public Status Status { get; internal set; }

        [JsonProperty("subscription_number")]
        public int SubscriptionNumber { get; internal set; }

        [JsonProperty("subscription_uuid")]
        public string SubscriptionUuid { get; internal set; }

        [JsonProperty("transaction_number")]
        public int TransactionNumber { get; internal set; }

        [JsonProperty("uuid")]
        public string Uuid { get; internal set; }

        [JsonProperty("wallet")]
        public string Wallet { get; internal set; }

        [JsonProperty("has_cardholder_data")]
        public bool HasCardholderData { get; internal set; }

        [JsonProperty("cardholder_data")]
        public TransactionCardholderData CardholderData { get; internal set; }

        [JsonProperty("history")]
        public TransactionHistory[] History { get; internal set; }

        [JsonProperty("fee")]
        public int Fee { get; internal set; }

        public AtomicResponse<DetailedTransaction> Capture(int? amount = null)
        {
            var request = PrepareCaptureRequest(amount);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> CaptureAsync(int? amount = null)
        {
            var request = PrepareCaptureRequest(amount);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public AtomicResponse<DetailedTransaction> Refund(int? amount = null)
        {
            var request = PrepareRefundRequest(amount);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> RefundAsync(int? amount = null)
        {
            var request = PrepareRefundRequest(amount);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public AtomicResponse<DetailedTransaction> Cancel()
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}/cancel", Method.POST);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> CancelAsync()
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}/cancel", Method.POST);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request, Method.POST);
            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        private RestRequest PrepareCaptureRequest(int? amount)
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}/capture", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            if (amount != null)
            {
                request.AddJsonBody(
                    new
                    {
                        data = new
                        {
                            amount
                        }
                    });
            }

            return request;
        }

        private RestRequest PrepareRefundRequest(int? amount)
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}/refund", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            if (amount != null)
            {
                request.AddJsonBody(
                    new
                    {
                        data = new
                        {
                            amount
                        }
                    });
            }

            return request;
        }
    }
}
