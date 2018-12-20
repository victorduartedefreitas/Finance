using System;

namespace Finance.Core.Domain.Exceptions
{
    public sealed class CustomerNotFoundException : DomainException
    {
        public CustomerNotFoundException(string message)
            : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
