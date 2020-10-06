using System.Linq;
using System.Threading.Tasks;

using OnPayClient.Exceptions;
using OnPayClient.Models.Transactions;

namespace OnPayClient.Models.Extension
{
    public static class TransactionExtensions
    {
        public static AtomicResponse<DetailedTransaction> Capture(this AtomicResponse<DetailedTransaction> response, int? amount)
        {
            ValidateResponse(response);
            return response.Data.Capture(amount);
        }

        public static AtomicResponse<DetailedTransaction> Refund(this AtomicResponse<DetailedTransaction> response, int? amount)
        {
            ValidateResponse(response);
            return response.Data.Refund(amount);
        }

        public static AtomicResponse<DetailedTransaction> Cancel(this AtomicResponse<DetailedTransaction> response)
        {
            ValidateResponse(response);
            return response.Data.Cancel();
        }

        public static async Task<AtomicResponse<DetailedTransaction>> CaptureAsync(this AtomicResponse<DetailedTransaction> response, int? amount)
        {
            ValidateResponse(response);
            return await response.Data.CaptureAsync(amount);
        }

        public static async Task<AtomicResponse<DetailedTransaction>> RefundAsync(this AtomicResponse<DetailedTransaction> response, int? amount)
        {
            ValidateResponse(response);
            return await response.Data.RefundAsync(amount);
        }

        public static async Task<AtomicResponse<DetailedTransaction>> CancelAsync(this AtomicResponse<DetailedTransaction> response, int? amount)
        {
            ValidateResponse(response);
            return await response.Data.CancelAsync();
        }

        private static void ValidateResponse(AtomicResponse<DetailedTransaction> response)
        {
            if (response.Errors.Any())
                throw new TransactionResponseHasErrorsException("Transaction response has errors. Check the Errors property");
        }
    }
}
