using Finance.Core.Domain.Models;
using System.Collections.ObjectModel;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess
{
    public sealed class FinanceContext
    {
        #region Constructors

        public FinanceContext()
        {
            Accounts = new Collection<Account>();
            Customers = new Collection<Customer>();
        }

        #endregion

        #region Properties

        public Collection<Account> Accounts { get; set; }
        public Collection<Customer> Customers { get; set; }

        #endregion
    }
}
