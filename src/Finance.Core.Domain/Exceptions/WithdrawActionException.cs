using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class WithdrawActionException : DomainException
    {
        public WithdrawActionException(string message)
            : base(message)
        {
        }

        public WithdrawActionException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
