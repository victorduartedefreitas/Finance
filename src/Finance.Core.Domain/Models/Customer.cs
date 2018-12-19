using Finance.Core.Domain.Collections;
using System;

namespace Finance.Core.Domain.Models
{
    public sealed class Customer : IEntity
    {
        #region Constructors

        public Customer()
            : this(default(Guid))
        {
        }

        public Customer(Guid id)
        {
            Id = id == default(Guid) ? Guid.NewGuid() : id;
            Accounts = new AccountCollection();
        }

        #endregion  

        #region Properties

        public Guid Id { get; }
        public AccountCollection Accounts { get; }

        #endregion

        #region Public Methods

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void AddAccounts(params Account[] accounts)
        {
            foreach (var acc in accounts)
                AddAccount(acc);
        }

        public object Clone()
        {
            var customer = new Customer(Id);
            foreach (var acc in Accounts.ToReadOnlyCollection())
                customer.AddAccount(acc);

            return customer;
        }

        #endregion
    }
}
