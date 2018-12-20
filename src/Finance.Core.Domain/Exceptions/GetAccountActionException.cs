using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class GetAccountActionException : DomainException
    {
        public GetAccountActionException(string message) : base(message)
        {
        }

        public GetAccountActionException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
