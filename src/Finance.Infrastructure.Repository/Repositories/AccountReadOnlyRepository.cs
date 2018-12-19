using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Repository.Repositories
{
    public sealed class AccountReadOnlyRepository : IAccountReadOnlyRepository
    {
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
    }
}
