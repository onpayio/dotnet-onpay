namespace OnPayClient.Exceptions
{
    public class PaymentWindowValidationException : BaseException
    {
        public string ParameterName { get; set; }
        public override string Message => $"Required window parameter is missing. Parameter name: {ParameterName}";
    }
}
