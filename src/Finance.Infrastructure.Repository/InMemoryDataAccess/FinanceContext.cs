using Finance.Core.Domain.Models;
using System.Collections.ObjectModel;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess
{
    public sealed class FinanceContext
    {
        #region Locals

        private static FinanceContext _instance;

        #endregion

        #region Constructors

        private FinanceContext()
        {
            Accounts = new Collection<Account>();
            Customers = new Collection<Customer>();
        }

        #endregion

        #region Properties

        public static FinanceContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FinanceContext();

                return _instance;
            }
        }

        public Collection<Account> Accounts { get; set; }
        public Collection<Customer> Customers { get; set; }

        #endregion
    }
}
