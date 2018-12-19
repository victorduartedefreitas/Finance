namespace Finance.Core.Domain.Exceptions
{
    public sealed class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        {
        }
    }
}
