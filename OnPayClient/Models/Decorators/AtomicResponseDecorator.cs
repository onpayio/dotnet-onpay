using System.Net;

using OnPayClient.Exceptions;

using RestSharp;

namespace OnPayClient.Models.Decorators
{
    static class AtomicResponseDecorator
    {
        internal static AtomicResponse<T> DecorateResponse<T>(IRestResponse<AtomicResponse<T>> response, RestClient client) where T:BaseModel
        {
            if (response.StatusCode == HttpStatusCode.NotFound || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidServerResponseException { HttpStatus = response.StatusCode, Content = response.Content };

            var atomicResponse = response.Data;
            atomicResponse.Data?.DecorateWithRestClient(client);

            return atomicResponse;
        }
    }
}
