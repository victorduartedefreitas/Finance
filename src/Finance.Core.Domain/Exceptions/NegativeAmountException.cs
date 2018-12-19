namespace Finance.Core.Domain.Exceptions
{
    public sealed class NegativeAmountException : DomainException
    {
        public NegativeAmountException(string message)
            : base(message)
        {
        }
    }
}
