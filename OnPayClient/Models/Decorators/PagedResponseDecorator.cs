using System.Collections.Generic;
using System.Net;

using OnPayClient.Exceptions;

using RestSharp;

namespace OnPayClient.Models.Decorators
{
    static class PagedResponseDecorator
    {
        internal static PagedResponse<T> DecorateResponse<T>(IRestResponse<PagedResponse<T>> response, RestClient client) where T:BaseModel
        {
            if (response.StatusCode == HttpStatusCode.NotFound || response.Data == null)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidServerResponseException { HttpStatus = response.StatusCode, Content = response.Content };

            var pagedResponse = response.Data;
            foreach (var baseModel in pagedResponse?.Data ?? new List<T>())
                baseModel.DecorateWithRestClient(client);

            return pagedResponse;
        }
    }
}
