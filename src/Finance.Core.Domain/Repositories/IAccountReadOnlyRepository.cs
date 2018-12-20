using Finance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<OperationResult<Account>> GetAccount(Guid id);
        Task<OperationResult<IList<Account>>> GetAccountsByCustomerId(Guid customerId);
        Task<OperationResult<ITransaction>> GetLastTransaction(Guid accountId);
    }
}
