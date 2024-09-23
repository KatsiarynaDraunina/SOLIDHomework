using System;

namespace SOLIDHomework.Core.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
