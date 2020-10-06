namespace OnPayClient.Exceptions
{
    public class UnknownTransactionStatusException : BaseException
    {
        public string Status { get; set; }
        public override string Message => $"Unknown transaction status: {Status}";
    }
}
