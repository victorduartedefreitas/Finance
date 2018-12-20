using Finance.Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Finance.Core.Application.Tests
{
    public class AccountTest
    {
        readonly IServiceProvider serviceProvider;
        readonly IAccountService accountService;
        readonly ICustomerService customerService;

        public AccountTest()
        {
            var services = new ServiceCollection();

            TestsConfiguration.ConfigureAllServicesAndRepositories(services);
            serviceProvider = services.BuildServiceProvider();

            accountService = serviceProvider.GetService<IAccountService>();
            customerService = serviceProvider.GetService<ICustomerService>();
        }

        [Fact]
        public async void CreateAccountTest()
        {
            var createAccountResult = await accountService.CreateAccount(Guid.NewGuid(), "conta de teste");

            Assert.True(createAccountResult.Success);
            Assert.Null(createAccountResult.Exception);
        }

        [Fact]
        public async void DepositAccountTest()
        {
            await accountService.Deposit(new Domain.Models.DepositAction(new Guid("CFAC91BA-FF18-4CDB-A98B-1719B8759140"), 152.3m, "transfer"));
            Assert.True(true);
        }

        [Fact]
        public async void WithdrawAccountTest()
        {
            await accountService.Withdraw(new Domain.Models.WithdrawAction(new Guid("CFAC91BA-FF18-4CDB-A98B-1719B8759140"), 57.4m, "game"));
            Assert.True(true);
        }

        [Theory]
        [InlineData("CFAC91BA-FF18-4CDB-A98B-1719B8759140")]
        [InlineData("BE3D3DBF-0A19-46BF-AD1D-48D47A3FD5EF")]
        public async void GetAccountTest(string accountId)
        {
            if (!accountId.Equals("CFAC91BA-FF18-4CDB-A98B-1719B8759140")
                && !accountId.Equals("BE3D3DBF-0A19-46BF-AD1D-48D47A3FD5EF"))
            {
                throw new NotImplementedException($"Test not implemented for accountId {accountId}");
            }

            Guid id = Guid.Parse(accountId);
            var account = await accountService.GetAccount(id);

            Assert.NotNull(account);

            if (accountId.Equals("CFAC91BA-FF18-4CDB-A98B-1719B8759140"))
            {
                Assert.Equal("A1549B76-5EFE-446F-A755-BA78C447B791", account.CustomerId.ToString().ToUpper());
                Assert.Equal<decimal>(65m, account.Transactions.Balance);
            }
            else if (accountId.Equals("BE3D3DBF-0A19-46BF-AD1D-48D47A3FD5EF"))
            {
                Assert.Equal("C11172C9-7205-4F64-852E-44D54404103E", account.CustomerId.ToString().ToUpper());
                Assert.Equal<decimal>(3160m, account.Transactions.Balance);
            }
        }
    }
}
