using Finance.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Repositories
{
    public interface IAccountWriteOnlyRepository
    {
        Task<OperationResult> CreateAccount(Account account);
        Task<OperationResult> InsertTransaction(Guid accountId, ITransaction transaction);
    }
}
