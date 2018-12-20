using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class DepositActionException : DomainException
    {
        public DepositActionException(string message)
            : base(message)
        {
        }

        public DepositActionException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
