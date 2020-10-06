using System;
using System.Threading.Tasks;

using OnPayClient.Models;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.Subscriptions;
using OnPayClient.Models.Subscriptions.Enums;

using RestSharp;

namespace OnPayClient.Controllers
{
    public class Subscriptions
    {
        private readonly RestClient _client;

        internal Subscriptions(RestClient client)
        {
            _client = client;
        }

        public AtomicResponse<DetailedSubscription> Details(string id)
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{id}", Method.GET);
            var response = _client.Execute<AtomicResponse<DetailedSubscription>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedSubscription>> DetailsAsync(string id)
        {
            var request = new RestRequest($"{Routes.Subscriptions}/{id}", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedSubscription>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public PagedResponse<SimpleSubscription> Page(string query = "", int pageIndex = 1, int pageSize = 25, OrderBy orderBy = OrderBy.SubscriptionNumber,
            Direction direction = Direction.Desc, Status? status = null, DateTime? dateAfter = null, DateTime? dateBefore = null)
        {
            var request = CreatePageRequest(query, pageIndex, pageSize, orderBy, direction, status, dateAfter, dateBefore);

            var response = _client.Execute<PagedResponse<SimpleSubscription>>(request);

            return PagedResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<PagedResponse<SimpleSubscription>> PageAsync(string query = "", int pageIndex = 1, int pageSize = 25, OrderBy orderBy = OrderBy.SubscriptionNumber,
            Direction direction = Direction.Desc, Status? status = null, DateTime? dateAfter = null, DateTime? dateBefore = null)
        {
            var request = CreatePageRequest(query, pageIndex, pageSize, orderBy, direction, status, dateAfter, dateBefore);

            var response = await _client.ExecuteAsync<PagedResponse<SimpleSubscription>>(request);

            return PagedResponseDecorator.DecorateResponse(response, _client);
        }

        private RestRequest CreatePageRequest(string query, int pageIndex, int pageSize, OrderBy orderBy, Direction direction, 
            Status? status, DateTime? dateAfter, DateTime? dateBefore)
        {
            var request = new RestRequest($"{Routes.Subscriptions}/");
            request.AddParameter("query", query);
            request.AddParameter("page", pageIndex);
            request.AddParameter("page_size", pageSize);
            request.AddParameter("direction", direction == Direction.Asc ? "asc" : "desc");

            request.AddParameter(
                "order_by",
                orderBy switch {
                    OrderBy.Status => "status",
                    OrderBy.Created => "created",
                    OrderBy.OrderId => "order_id",
                    OrderBy.SubscriptionNumber => "subscription_number"
                });

            if (status.HasValue)
            {
                request.AddParameter(
                    "status",
                    status switch {
                        Status.Active => "active",
                        Status.Cancelled => "cancelled"
                    });
            }

            if (dateAfter.HasValue)
                request.AddParameter("date_after", dateAfter.Value.ToString("yyyy-MM-dd"));

            if (dateBefore.HasValue)
                request.AddParameter("date_before", dateBefore.Value.ToString("yyyy-MM-dd"));
            return request;
        }
    }
}
