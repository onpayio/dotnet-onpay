using System;
using Newtonsoft.Json;

namespace OnPayClient.Models.Converters
{
    class DateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("WriteJson is not implemented");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dateString = (string) reader.Value;
            return DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", null);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
