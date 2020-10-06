namespace OnPayClient.Exceptions
{
    public class UnknownCardTypeException : BaseException
    {
        public string CardType { get; set; }
        public override string Message => $"Unknown card type: {CardType}";
    }
}
