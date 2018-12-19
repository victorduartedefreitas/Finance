using Finance.Core.Domain.Models;
using Finance.Core.Domain.ValueTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Finance.Core.Domain.Collections
{
    public sealed class TransactionCollection
    {
        #region Locals

        private IList<ITransaction> _transactions;

        #endregion

        #region Constructors

        public TransactionCollection()
        {
            _transactions = new List<ITransaction>();
        }

        #endregion

        #region Properties

        public Amount Balance
        {
            get
            {
                Amount balance = 0;

                foreach (var item in _transactions)
                {
                    if (item is DebitTransaction)
                        balance -= item.Amount;
                    else if (item is CreditTransaction)
                        balance += item.Amount;
                }

                return balance;
            }
        }

        #endregion

        #region Public Methods

        public void Add(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void Add(params ITransaction[] transactions)
        {
            foreach (var t in transactions)
                Add(t);
        }

        public IReadOnlyCollection<ITransaction> ToReadOnlyCollection()
        {
            return new ReadOnlyCollection<ITransaction>(_transactions);
        }

        public ITransaction GetLastTransactionClone()
        {
            if (_transactions.Count == 0)
                return null;

            return _transactions.Last().Clone() as ITransaction;
        }

        #endregion
    }
}
