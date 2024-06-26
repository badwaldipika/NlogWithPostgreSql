﻿using System;

namespace ErrorHandler.Exceptions
{
    public class BadRequestCustomException : Exception
    {
        public string ErrorCode { get; set; }
        public BadRequestCustomException(string message) : base(message)
        { }

        public BadRequestCustomException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
