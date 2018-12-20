using Finance.Core.Domain.Exceptions;
using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess.Repositories
{
    public sealed class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        #region Locals

        private FinanceContext context;
        private readonly string defaultExceptionMessage = $"An error occurred while processing. Verify the 'Exception' property for more details.";

        #endregion

        #region Constructors

        public AccountRepository()
        {
            context = FinanceContext.Instance;
        }

        #endregion

        #region Public Methods

        public Task<OperationResult> CreateAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var existentAccount = context.Accounts.FirstOrDefault(f => f.Id == account.Id);
            if (existentAccount != null)
                throw new AccountAlreadyExistsException($"This account {account.Id} already exists.");

            try
            {
                context.Accounts.Add(account);
                return Task.FromResult(new OperationResult(true, string.Empty));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult(false, defaultExceptionMessage, ex));
            }
        }

        public Task<OperationResult<Account>> GetAccount(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentNullException(nameof(id));

            var account = context.Accounts.FirstOrDefault(f => f.Id == id);
            if (account == null)
                throw new AccountNotFoundException($"The account {id} does not exists.");

            return Task.FromResult(new OperationResult<Account>(true, string.Empty, account));
        }

        public Task<OperationResult<IList<Account>>> GetAccountsByCustomerId(Guid customerId)
        {
            if (customerId == default(Guid))
                throw new ArgumentNullException(nameof(customerId));

            IList<Account> accounts = context.Accounts.Where(f => f.CustomerId == customerId).ToList();

            return Task.FromResult(new OperationResult<IList<Account>>(true, string.Empty, accounts));
        }

        public Task<OperationResult<ITransaction>> GetLastTransaction(Guid accountId)
        {
            if (accountId == default(Guid))
                throw new ArgumentNullException(nameof(accountId));

            var account = context.Accounts.FirstOrDefault(f => f.Id == accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists.");

            ITransaction transaction = account.Transactions.GetLastTransactionClone();

            return Task.FromResult(new OperationResult<ITransaction>(true, string.Empty, transaction));
        }

        public Task<OperationResult> InsertTransaction(Guid accountId, ITransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));
            if (accountId == default(Guid))
                throw new ArgumentNullException(nameof(accountId));

            var account = context.Accounts.FirstOrDefault(f => f.Id == accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists.");

            try
            {
                account.Transactions.Add(transaction);
                return Task.FromResult(new OperationResult(true, string.Empty));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult(false, defaultExceptionMessage, ex));
            }
        }

        #endregion
    }
}
