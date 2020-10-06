using System.Net;
using System.Threading.Tasks;

using OnPayClient.Models;
using OnPayClient.Models.Gateways;

using RestSharp;

namespace OnPayClient.Controllers
{
    public class Gateway
    {
        private readonly RestClient _client;

        internal Gateway(RestClient client)
        {
            _client = client;
        }

        public AtomicResponse<GatewayInformation> Information()
        {
            var request = new RestRequest($"{Routes.Gateways}/information", Method.GET);
            var response = _client.Execute<AtomicResponse<GatewayInformation>>(request);

            return HandleResponse(response);
        }

        public async Task<AtomicResponse<GatewayInformation>> InformationAsync()
        {
            var request = new RestRequest($"{Routes.Gateways}/information", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<GatewayInformation>>(request);

            return HandleResponse(response);
        }

        public AtomicResponse<GatewayWindowIntegration> WindowIntegrationSettings()
        {
            var request = new RestRequest($"{Routes.Gateways}/window/v3/integration", Method.GET);
            var response = _client.Execute<AtomicResponse<GatewayWindowIntegration>>(request);

            return HandleResponse(response);
        }

        public async Task<AtomicResponse<GatewayWindowIntegration>> WindowIntegrationSettingsAsync()
        {
            var request = new RestRequest($"{Routes.Gateways}/window/v3/integration", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<GatewayWindowIntegration>>(request);

            return HandleResponse(response);
        }

        public AtomicResponse<SimpleGatewayWindowDesign[]> WindowDesign()
        {
            var request = new RestRequest($"{Routes.Gateways}/window/v3/design/", Method.GET);
            var response = _client.Execute<AtomicResponse<SimpleGatewayWindowDesign[]>>(request);

            return HandleResponse(response);
        }

        public async Task<AtomicResponse<SimpleGatewayWindowDesign[]>> WindowDesignAsync()
        {
            var request = new RestRequest($"{Routes.Gateways}/window/v3/design/", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<SimpleGatewayWindowDesign[]>>(request);

            return HandleResponse(response);
        }

        private static AtomicResponse<T> HandleResponse<T>(IRestResponse<AtomicResponse<T>> response) where T: class
        {
            if (response.StatusCode == HttpStatusCode.NotFound || response.Data == null)
                return null;

            return response.Data;
        }
    }
}
