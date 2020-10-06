using System.Collections.Generic;
using Newtonsoft.Json;

using OnPayClient.Models.MetaData;

namespace OnPayClient.Models
{
    public class AtomicResponse<T> where T:class
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("links")]
        public Link Links { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
