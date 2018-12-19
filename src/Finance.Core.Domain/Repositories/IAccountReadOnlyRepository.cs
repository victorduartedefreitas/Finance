using Finance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account> GetAccount(Guid id);
        Task<IList<Account>> GetAccountsByCustomerId(Guid customerId);
        Task<ITransaction> GetLastTransaction(Guid accountId);
    }
}
