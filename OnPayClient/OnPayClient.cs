using System.Net;
using System.Threading.Tasks;

using OnPayClient.Controllers;
using OnPayClient.Exceptions;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace OnPayClient
{
    public sealed class OnPayClient
    {
        private readonly RestClient _restClient;

        public OnPayClient(string accessToken)
        {
            _restClient = new RestClient("https://api.onpay.io/");
            _restClient.UseNewtonsoftJson();
            _restClient.AddDefaultHeader("Authorization", $"Bearer {accessToken}");
        }

        public Transactions Transactions => new Transactions(_restClient);
        public Subscriptions Subscriptions => new Subscriptions(_restClient);
        public Gateway Gateway => new Gateway(_restClient);

        public void Ping()
        {
            var request = new RestRequest($"/v1/ping", Method.GET);
            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidServerResponseException { HttpStatus = response.StatusCode, Content = response.Content };
        }

        public async Task PingAsync()
        {
            var request = new RestRequest($"/v1/ping", Method.GET);
            var response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidServerResponseException { HttpStatus = response.StatusCode, Content = response.Content };
        }
    }
}
