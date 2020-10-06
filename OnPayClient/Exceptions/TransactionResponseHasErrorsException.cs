namespace OnPayClient.Exceptions
{
    public class TransactionResponseHasErrorsException : BaseException
    {
        public TransactionResponseHasErrorsException(string message) : base(message) { }
    }
}
