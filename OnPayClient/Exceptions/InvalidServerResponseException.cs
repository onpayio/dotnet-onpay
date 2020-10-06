using System.Net;

namespace OnPayClient.Exceptions
{
    public class InvalidServerResponseException : BaseException
    {
        public HttpStatusCode HttpStatus { get; set; }
        public string Content { get; set; }
        public override string Message => $"Server responded with {HttpStatus}. Check the Content property for the details";
    }
}
