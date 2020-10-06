using System.Collections.Generic;
using Newtonsoft.Json;

using OnPayClient.Models.MetaData;

namespace OnPayClient.Models
{
    public class PagedResponse<T> where T : class
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        [JsonProperty("meta")]
        public MetaData.MetaData Meta { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
