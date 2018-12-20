using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess.Repositories
{
    public sealed class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        public Task<OperationResult> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccount(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Account>> GetAccountsByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<ITransaction> GetLastTransaction(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> InsertTransaction(Guid accountId, ITransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
