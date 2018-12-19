namespace Finance.Core.Domain.Exceptions
{
    public sealed class DepositActionException : DomainException
    {
        public DepositActionException(string message)
            : base(message)
        {
        }
    }
}
