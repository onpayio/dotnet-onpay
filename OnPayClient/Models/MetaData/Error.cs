using Newtonsoft.Json;

namespace OnPayClient.Models.MetaData
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
