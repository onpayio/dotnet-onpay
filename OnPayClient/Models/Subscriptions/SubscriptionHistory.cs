using System;
using Newtonsoft.Json;

using OnPayClient.Models.Converters;

namespace OnPayClient.Models.Subscriptions
{
    public class SubscriptionHistory
    {
        [JsonProperty("action")]
        public string Action { get; internal set; }

        [JsonProperty("author")]
        public string Author { get; internal set; }

        [JsonProperty("date_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateTime { get; internal set; }

        [JsonProperty("ip")]
        public string IP { get; internal set; }

        [JsonProperty("result_code")]
        public string ResultCode { get; internal set; }

        [JsonProperty("result_text")]
        public string ResultText { get; internal set; }

        [JsonProperty("successful")]
        public bool Successful { get; internal set; }

        [JsonProperty("uuid")]
        public string Uuid { get; internal set; }

    }
}
