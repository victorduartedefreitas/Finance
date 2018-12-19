using Finance.Core.Domain.ValueTypes;
using System;

namespace Finance.Core.Domain.Models
{
    public sealed class WithdrawAction
    {
        public WithdrawAction(Guid customerId, Guid accountId, Amount value, string description)
        {
            AccountId = accountId != default(Guid) ? accountId : throw new ArgumentNullException(nameof(accountId));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public Guid AccountId { get; }
        public Amount Value { get; }
        public string Description { get; }
    }
}
