using Finance.Core.Domain.Collections;
using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Core.Application.Tests
{
    public class TestsConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.RegisterApplicationServices();

            ConfigureAccountRepository(services);
            ConfigureCustomerRepository(services);
        }

        public static void ConfigureAccountRepository(IServiceCollection services)
        {
            var customerReadOnlyRepositoryMock = new Mock<ICustomerReadOnlyRepository>();

            //TODO: Mock Methods
            //-------------- Customer 1
            var transactionsAccount1 = new TransactionCollection();
            transactionsAccount1.Add(new CreditTransaction(100));
            transactionsAccount1.Add(new CreditTransaction(20));
            transactionsAccount1.Add(new DebitTransaction(70));
            transactionsAccount1.Add(new CreditTransaction(30));
            transactionsAccount1.Add(new DebitTransaction(15));
            var account1 = new Account(
                new Guid("A1549B76-5EFE-446F-A755-BA78C447B791"),
                new Guid("CFAC91BA-FF18-4CDB-A98B-1719B8759140"),
                transactionsAccount1);
            var customer1 = new Customer(
                new Guid("A1549B76-5EFE-446F-A755-BA78C447B791"));
            customer1.Accounts.Add(account1);

            customerReadOnlyRepositoryMock
                .Setup(f => f.GetCustomer(new Guid("A1549B76-5EFE-446F-A755-BA78C447B791")))
                .ReturnsAsync(new OperationResult<Customer>(true, string.Empty, customer1));
            //-------------- 
            //-------------- Customer 2
            var transactionsAccount2 = new TransactionCollection();
            transactionsAccount2.Add(new CreditTransaction(1050));
            transactionsAccount2.Add(new DebitTransaction(375));
            transactionsAccount2.Add(new CreditTransaction(4500));
            transactionsAccount2.Add(new DebitTransaction(1950));
            transactionsAccount2.Add(new DebitTransaction(65));
            var account2 = new Account(
                new Guid("C11172C9-7205-4F64-852E-44D54404103E"),
                new Guid("BE3D3DBF-0A19-46BF-AD1D-48D47A3FD5EF"),
                transactionsAccount2);
            var customer2 = new Customer(
                new Guid("C11172C9-7205-4F64-852E-44D54404103E"));
            customer2.Accounts.Add(account2);

            customerReadOnlyRepositoryMock
                .Setup(f => f.GetCustomer(new Guid("C11172C9-7205-4F64-852E-44D54404103E")))
                .ReturnsAsync(new OperationResult<Customer>(true, string.Empty, customer2));
            //-------------- 

            services.AddScoped(f => customerReadOnlyRepositoryMock.Object);
        }

        public static void ConfigureCustomerRepository(IServiceCollection services)
        {

        }
    }
}
