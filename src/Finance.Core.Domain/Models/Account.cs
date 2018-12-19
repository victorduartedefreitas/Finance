using Finance.Core.Domain.Collections;
using Finance.Core.Domain.Exceptions;
using Finance.Core.Domain.ValueTypes;
using System;

namespace Finance.Core.Domain.Models
{
    public sealed class Account : IEntity
    {
        #region Constructors

        public Account(Guid customerId) : this(customerId, default(Guid), null) { }

        public Account(Guid customerId, Guid accountId) : this(customerId, accountId, null) { }

        public Account(Guid customerId, string description) : this(customerId, default(Guid), null, description) { }

        public Account(Guid customerId, Guid accountId, TransactionCollection transactions, string description = "Default")
        {
            Id = accountId == default(Guid) ? Guid.NewGuid() : accountId;
            CustomerId = customerId == default(Guid) ? Guid.NewGuid() : customerId;
            Transactions = transactions ?? new TransactionCollection();
            Description = description;
        }

        #endregion

        #region Properties

        public Guid Id { get; }
        public Guid CustomerId { get; set; }
        public TransactionCollection Transactions { get; set; }
        public string Description { get; }

        #endregion

        #region Public Methods

        public void Deposit(Amount amount)
        {
            Deposit(amount, string.Empty);
        }

        public void Deposit(Amount amount, string description)
        {
            var credit = new CreditTransaction(amount, description);
            Transactions.Add(credit);
        }

        public void Withdraw(Amount amount, string description)
        {
            var balance = Transactions.Balance;

            if (amount > balance)
                throw new InsufficientFundsException($"The account {Id} doesn't have enough funds to witdraw {amount}. Current balance is {balance}");

            var debit = new DebitTransaction(amount, description);
            Transactions.Add(debit);
        }

        public object Clone()
        {
            return new Account(CustomerId, Id, Transactions);
        }

        #endregion
    }
}
