using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class CustomerAlreadyExistsException : DomainException
    {
        public CustomerAlreadyExistsException(string message) : base(message)
        {
        }

        public CustomerAlreadyExistsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
