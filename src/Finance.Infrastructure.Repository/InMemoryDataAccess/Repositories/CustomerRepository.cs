using Finance.Core.Domain.Exceptions;
using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess.Repositories
{
    public sealed class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        #region Locals

        private FinanceContext context;
        private readonly string defaultExceptionMessage = $"An error occurred while processing. Verify the 'Exception' property for more details.";

        #endregion

        public Task<OperationResult> CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existentAccount = context.Accounts.FirstOrDefault(f => f.Id == customer.Id);
            if (existentAccount != null)
                throw new CustomerAlreadyExistsException($"This customer {customer.Id} already exists.");

            try
            {
                context.Customers.Add(customer);
                return Task.FromResult(new OperationResult(true, string.Empty));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult(false, defaultExceptionMessage, ex));
            }
        }

        public Task<OperationResult<Customer>> GetCustomer(Guid customerId)
        {
            if (customerId == default(Guid))
                throw new ArgumentNullException(nameof(customerId));

            var customer = context.Customers.FirstOrDefault(f => f.Id == customerId);
            if (customer == null)
                throw new CustomerNotFoundException($"The customer {customerId} does not exists.");

            return Task.FromResult(new OperationResult<Customer>(true, string.Empty, customer));
        }

        public Task<OperationResult> UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existentCustomer = context.Customers.FirstOrDefault(f => f.Id == customer.Id);
            if (existentCustomer == null)
                throw new CustomerNotFoundException($"The customer {customer.Id} does not exists.");

            try
            {
                existentCustomer.CopyFrom(customer);
                return Task.FromResult(new OperationResult(true, string.Empty));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult(false, defaultExceptionMessage, ex));
            }
        }
    }
}
