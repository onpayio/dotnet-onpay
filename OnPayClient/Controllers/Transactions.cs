using System;
using System.Threading.Tasks;

using OnPayClient.Models;
using OnPayClient.Models.Decorators;
using OnPayClient.Models.Enums;
using OnPayClient.Models.Transactions;
using OnPayClient.Models.Transactions.Enums;

using RestSharp;

namespace OnPayClient.Controllers
{
    public class Transactions
    {
        private readonly RestClient _client;

        internal Transactions(RestClient client)
        {
            _client = client;
        }

        public AtomicResponse<DetailedTransaction> Details(string id)
        {
            var request = new RestRequest($"{Routes.Transactions}/{id}", Method.GET);
            var response = _client.Execute<AtomicResponse<DetailedTransaction>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<AtomicResponse<DetailedTransaction>> DetailsAsync(string id)
        {
            var request = new RestRequest($"{Routes.Transactions}/{id}", Method.GET);
            var response = await _client.ExecuteAsync<AtomicResponse<DetailedTransaction>>(request);

            return AtomicResponseDecorator.DecorateResponse(response, _client);
        }

        public PagedResponse<SimpleTransaction> Page(string query = "", int pageIndex = 1, int pageSize = 25, OrderBy orderBy = OrderBy.TransactionNumber, 
            Direction direction = Direction.Desc, Status? status = null, DateTime? dateAfter = null, DateTime? dateBefore = null)
        {
            var request = CreatePageRequest(query, pageIndex, pageSize, orderBy, direction, status, dateAfter, dateBefore);

            var response = _client.Execute<PagedResponse<SimpleTransaction>>(request);

            return PagedResponseDecorator.DecorateResponse(response, _client);
        }

        public async Task<PagedResponse<SimpleTransaction>> PageAsync(string query = "", int pageIndex = 1, int pageSize = 25, OrderBy orderBy = OrderBy.TransactionNumber, 
            Direction direction = Direction.Desc, Status? status = null, DateTime? dateAfter = null, DateTime? dateBefore = null)
        {
            var request = CreatePageRequest(query, pageIndex, pageSize, orderBy, direction, status, dateAfter, dateBefore);

            var response = await _client.ExecuteAsync<PagedResponse<SimpleTransaction>>(request);

            return PagedResponseDecorator.DecorateResponse(response, _client);
        }

        private RestRequest CreatePageRequest(string query, int pageIndex, int pageSize, OrderBy orderBy, Direction direction, 
            Status? status, DateTime? dateAfter, DateTime? dateBefore)
        {
            var request = new RestRequest($"{Routes.Transactions}/");
            request.AddParameter("query", query);
            request.AddParameter("page", pageIndex);
            request.AddParameter("page_size", pageSize);
            request.AddParameter("direction", direction == Direction.Asc ? "asc" : "desc");

            request.AddParameter(
                "order_by",
                orderBy switch {
                    OrderBy.Amount => "amount",
                    OrderBy.Created => "created",
                    OrderBy.OrderId => "order_id",
                    OrderBy.TransactionNumber => "transaction_number"
                });

            if (status.HasValue)
            {
                request.AddParameter(
                    "status",
                    status switch {
                        Status.Active => "active",
                        Status.Cancelled => "cancelled",
                        Status.Created => "created",
                        Status.Declined => "declined",
                        Status.Finished => "finished",
                        Status.PreAuth => "pre_auth",
                        Status.Refunded => "refunded"
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
