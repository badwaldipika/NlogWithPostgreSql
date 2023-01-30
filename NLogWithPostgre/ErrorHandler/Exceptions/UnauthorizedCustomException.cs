using System;

namespace ErrorHandler.Exceptions
{
    public class UnauthorizedCustomException : Exception
    {
        public string ErrorCode { get; set; }
        public UnauthorizedCustomException(string message) : base(message)
        { }

        public UnauthorizedCustomException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
