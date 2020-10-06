using System;

using Newtonsoft.Json;

using OnPayClient.Exceptions;
using OnPayClient.Models.Enums;

namespace OnPayClient.Models.Converters
{
    class CardTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string) reader.Value;

            return enumString switch {
                "dankort" => CardType.Dankort,
                "visa" => CardType.Visa,
                "amex" => CardType.Amex,
                "maestro" => CardType.Maestro,
                "mastercard" => CardType.Mastercard,
                "diners" => CardType.DinersClub,
                "jcb" => CardType.JCB,
                "unionpay" => CardType.UnionPay,
                "discover" => CardType.Discover,
                "fbf" => CardType.FBF,
                _ => throw new UnknownCardTypeException { CardType = enumString }
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("WriteJson is not implemented");
        }
    }
}
