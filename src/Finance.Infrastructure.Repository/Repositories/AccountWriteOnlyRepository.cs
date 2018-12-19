using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Repository.Repositories
{
    public sealed class AccountWriteOnlyRepository : IAccountWriteOnlyRepository
    {
        public Task<OperationResult> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> InsertTransaction(Guid accountId, ITransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
