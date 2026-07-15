using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinterStore.Application.Common.Errors
{
    //404
    public class NotFoundError : Error
    {
        public NotFoundError(string message) : base(message)
        {
            Metadata.Add("ErrorCode", "NOT_FOUND");
        }
    }
    //409
    public class ConflictError : Error
    {
        public ConflictError(string message) : base(message)
        {
            Metadata.Add("ErrorCode", "CONFLICT");
        }
    }
    //400
    public class ValidationError : Error
    {
        public ValidationError(string message) : base(message)
        {
            Metadata.Add("ErrorCode", "VALIDATION_ERROR");
        }
    }
}
