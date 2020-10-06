using Newtonsoft.Json;

using RestSharp;

namespace OnPayClient.Models
{
    public abstract class BaseModel
    {
        [JsonIgnore]
        protected RestClient _client;

        internal virtual void DecorateWithRestClient(RestClient client)
        {
            _client = client;
        }
    }
}
