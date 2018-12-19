namespace Finance.Core.Domain.Exceptions
{
    public sealed class WithdrawActionException : DomainException
    {
        public WithdrawActionException(string message)
            : base(message)
        {
        }
    }
}
