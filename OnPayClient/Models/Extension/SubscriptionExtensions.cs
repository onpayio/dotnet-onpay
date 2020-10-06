using System.Linq;
using System.Threading.Tasks;

using OnPayClient.Exceptions;
using OnPayClient.Models.Subscriptions;
using OnPayClient.Models.Transactions;

namespace OnPayClient.Models.Extension
{
    public static class SubscriptionExtensions
    {
        public static AtomicResponse<DetailedTransaction> Authorize(this AtomicResponse<DetailedSubscription> subscription, int amount, string orderId)
        {
            ValidateResponse(subscription);
            return subscription.Data.Authorize(amount, orderId);
        }

        public static async Task<AtomicResponse<DetailedTransaction>> AuthorizeAsync(this AtomicResponse<DetailedSubscription> subscription, int amount, string orderId)
        {
            ValidateResponse(subscription);
            return await subscription.Data.AuthorizeAsync(amount, orderId);
        }

        public static AtomicResponse<DetailedSubscription> Cancel(this AtomicResponse<DetailedSubscription> subscription)
        {
            ValidateResponse(subscription);
            return subscription.Data.Cancel();
        }

        public static async Task<AtomicResponse<DetailedSubscription>> CancelAsync(this AtomicResponse<DetailedSubscription> subscription)
        {
            ValidateResponse(subscription);
            return await subscription.Data.CancelAsync();
        }

        private static void ValidateResponse(AtomicResponse<DetailedSubscription> response)
        {
            if (response.Errors.Any())
                throw new SubscriptionResponseHasErrorsException("Subscription response has errors. Check the Errors property");
        }
    }
}
