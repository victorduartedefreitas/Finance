using System;

namespace Finance.Core.Domain.Models
{
    public class OperationResult
    {
        public OperationResult(bool success, string message, Exception exception = null)
        {
            Success = success;
            Message = message;
            Exception = exception;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }

    public class OperationResult<TResultObject> : OperationResult
    {
        public OperationResult(bool success, string message, Exception exception = null)
            : base(success, message, exception)
        {
        }

        public OperationResult(bool success, string message, TResultObject resultObject, Exception exception = null)
            : this (success, message, exception)
        {
            ResultObject = resultObject;
        }

        public TResultObject ResultObject { get; set; }
    }
}
