using System;

using Newtonsoft.Json;

using OnPayClient.Exceptions;

namespace OnPayClient.Models.Transactions.Enums.Converters
{
    class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string) reader.Value;

            return enumString switch {
                "active" => Status.Active,
                "cancelled" => Status.Cancelled,
                "created" => Status.Created,
                "declined" => Status.Declined,
                "finished" => Status.Finished,
                "pre_auth" => Status.PreAuth,
                _ => throw new UnknownTransactionStatusException { Status = enumString }
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("WriteJson is not implemented");
        }
    }
}
