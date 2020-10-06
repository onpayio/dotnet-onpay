using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using OnPayClient.Models.Converters;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.MetaData;
using OnPayClient.Models.Transactions.Enums;
using OnPayClient.Models.Transactions.Enums.Converters;

using RestSharp;

namespace OnPayClient.Models.Transactions
{
    public class SimpleTransaction : BaseModel
    {
        internal SimpleTransaction() { }

        [JsonProperty("3dsecure")]
        public bool Secure3D { get; internal set; }

        [JsonProperty("acquirer")]
        public string Acquirer { get; internal set; }

        [JsonProperty("amount")]
        public int Amount { get; internal set; }

        [JsonProperty("card_type")]
        [JsonConverter(typeof(CardTypeConverter))]
        public CardType CardType { get; internal set; }

        [JsonProperty("charged")]
        public int Charged { get; internal set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Created { get; internal set; }

        [JsonProperty("currency_code")]
        public int CurrencyCode { get; internal set; }

        [JsonProperty("order_id")]
        public string OrderID { get; internal set; }

        [JsonProperty("refunded")]
        public int Refunded { get; internal set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StatusConverter))]
        public Status Status { get; internal set; }

        [JsonProperty("transaction_number")]
        public int TransactionNumber { get; internal set; }

        [JsonProperty("uuid")]
        public string Uuid { get; internal set; }

        [JsonProperty("wallet")]
        public string Wallet { get; internal set; }

        [JsonProperty("links")]
        public Link Links { get; internal set; }

        public AtomicResponse<DetailedTransaction> Details()
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}", Method.GET);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> DetailsAsync()
        {
            var request = new RestRequest($"{Routes.Transactions}/{Uuid}", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }
    }
}
