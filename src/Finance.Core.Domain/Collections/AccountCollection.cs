using Finance.Core.Domain.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Finance.Core.Domain.Collections
{
    public sealed class AccountCollection
    {
        #region Locals

        private IList<Account> _accounts;

        #endregion

        #region Constructors

        public AccountCollection()
        {
            _accounts = new List<Account>();
        }

        #endregion

        #region Public Methods

        public void Add(Account account)
        {
            _accounts.Add(account);
        }

        public void Add(params Account[] accounts)
        {
            foreach (var account in accounts)
                Add(account);
        }

        public IReadOnlyCollection<Account> ToReadOnlyCollection()
        {
            return new ReadOnlyCollection<Account>(_accounts);
        }

        #endregion
    }
}
