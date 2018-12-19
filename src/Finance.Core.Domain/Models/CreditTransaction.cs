using Finance.Core.Domain.ValueTypes;
using System;

namespace Finance.Core.Domain.Models
{
    public sealed class CreditTransaction : IEntity, ITransaction
    {
        #region Constructors

        public CreditTransaction(Amount amount)
            : this(default(Guid), amount, "Credit")
        {
        }

        public CreditTransaction(Amount amount, string description)
            : this(default(Guid), amount, description)
        {
        }

        public CreditTransaction(Guid id, Amount amount, string description)
        {
            Id = id == default(Guid) ? Guid.NewGuid() : id;
            Amount = amount;
            Description = description ?? "Credit";
            TransactionDate = DateTimeOffset.UtcNow;
        }

        #endregion

        #region Properties

        public Guid Id { get; }

        public string Description { get; }

        public Amount Amount { get; }

        public DateTimeOffset TransactionDate { get; }

        #endregion

        #region Public Methods

        public object Clone()
        {
            return new DebitTransaction(Id, Amount, Description);
        }

        #endregion
    }
}
