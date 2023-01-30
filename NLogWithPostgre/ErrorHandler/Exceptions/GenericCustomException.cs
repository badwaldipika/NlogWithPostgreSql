using System;

namespace ErrorHandler.Exceptions
{
    public class GenericCustomException : Exception
    {
        public string ErrorCode { get; set; }
        public GenericCustomException(string message) : base(message)
        { }

        public GenericCustomException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

    }
}
