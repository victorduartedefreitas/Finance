using Finance.Core.Domain.Models;
using Finance.Core.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Services
{
    public interface IAccountService
    {
        Task<OperationResult> CreateAccount(Guid customerId, string accountDescription);
        Task<Amount> GetBalance(Guid accountId);
        Task Deposit(DepositAction deposit);
        Task Withdraw(WithdrawAction withdraw);
        Task<Account> GetAccount(Guid accountId);
        Task<IList<Account>> GetAccountsByCustomerId(Guid customerId);
    }
}
