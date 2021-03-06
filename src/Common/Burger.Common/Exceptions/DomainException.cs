using System;

namespace Burger.Common.Exceptions
{
    public class DomainException : Exception
    {
        public string ErrorCode { get; }

        public DomainException(string errorCode)
        {
            ErrorCode = errorCode;
        }

        public DomainException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public DomainException(string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
