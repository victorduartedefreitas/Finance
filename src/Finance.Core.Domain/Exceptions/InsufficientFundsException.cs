namespace Finance.Core.Domain.Exceptions
{
    public sealed class InsufficientFundsException : DomainException
    {
        public InsufficientFundsException(string message)
            : base(message)
        {
        }
    }
}
