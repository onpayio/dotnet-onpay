using System;

namespace OnPayClient.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException() { }

        public BaseException(string message) : base(message) { }
    }
}
