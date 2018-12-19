using Finance.Core.Domain.Exceptions;
using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using Finance.Core.Domain.Services;
using Finance.Core.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Core.Application.Services
{
    public sealed class AccountService : IAccountService
    {
        #region Locals

        IAccountReadOnlyRepository _accountReadOnlyRepository;
        IAccountWriteOnlyRepository _accountWriteOnlyRepository;

        #endregion

        #region Constructors

        public AccountService(IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            _accountReadOnlyRepository = accountReadOnlyRepository ?? throw new ArgumentNullException(nameof(accountReadOnlyRepository));
            _accountWriteOnlyRepository = accountWriteOnlyRepository ?? throw new ArgumentNullException(nameof(accountWriteOnlyRepository));
        }

        #endregion

        #region Public Methods

        public async Task<OperationResult> CreateAccount(Guid customerId, string accountDescription)
        {
            if (customerId == default(Guid))
                throw new ArgumentNullException(nameof(customerId));

            var account = new Account(customerId, accountDescription);
            var result = await _accountWriteOnlyRepository.CreateAccount(account);

            return result;
        }

        public async Task Deposit(DepositAction deposit)
        {
            var account = await _accountReadOnlyRepository.GetAccount(deposit.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {deposit.AccountId} does not exists.");

            account.Deposit(deposit.Value, deposit.Description);
            ITransaction depositTransaction = account.Transactions.GetLastTransactionClone();
            OperationResult result = await _accountWriteOnlyRepository.InsertTransaction(deposit.AccountId, depositTransaction);

            if (!result.Success)
                throw new DepositActionException(result.Message);
        }

        public async Task<Account> GetAccount(Guid accountId)
        {
            if (accountId == default(Guid))
                throw new ArgumentNullException(nameof(accountId));

            var account = await _accountReadOnlyRepository.GetAccount(accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists.");

            return account;
        }

        public async Task<IList<Account>> GetAccountsByCustomerId(Guid customerId)
        {
            if (customerId == default(Guid))
                throw new ArgumentNullException(nameof(customerId));

            var accounts = await _accountReadOnlyRepository.GetAccountsByCustomerId(customerId);

            if (accounts == null || accounts.Count == 0)
                throw new AccountNotFoundException($"The customer {customerId} has no active accounts.");

            return accounts;
        }

        public async Task<Amount> GetBalance(Guid accountId)
        {
            if (accountId == default(Guid))
                throw new ArgumentNullException(nameof(accountId));

            var account = await _accountReadOnlyRepository.GetAccount(accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists.");

            return account.Transactions.Balance;
        }

        public async Task Withdraw(WithdrawAction withdraw)
        {
            var account = await _accountReadOnlyRepository.GetAccount(withdraw.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {withdraw.AccountId} does not exists.");

            account.Withdraw(withdraw.Value, withdraw.Description);
            ITransaction withdrawTransaction = account.Transactions.GetLastTransactionClone();
            OperationResult result = await _accountWriteOnlyRepository.InsertTransaction(withdraw.AccountId, withdrawTransaction);

            if (!result.Success)
                throw new WithdrawActionException(result.Message);
        }

        #endregion
    }
}
