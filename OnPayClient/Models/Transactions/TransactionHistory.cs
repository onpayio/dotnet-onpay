using System;
using Newtonsoft.Json;

using OnPayClient.Models.Converters;

namespace OnPayClient.Models.Transactions
{
    public class TransactionHistory
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("date_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("result_code")]
        public string ResultCode { get; set; }

        [JsonProperty("result_text")]
        public string ResultText { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("successful")]
        public bool Successful { get; set; }
    }
}
