using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class AccountAlreadyExistsException : DomainException
    {
        public AccountAlreadyExistsException(string message) : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
