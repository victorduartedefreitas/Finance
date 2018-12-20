using System;
using System.Threading.Tasks;
using Finance.Core.Domain.Models;
using Finance.Core.Domain.Repositories;

namespace Finance.Infrastructure.Repository.InMemoryDataAccess.Repositories
{
    public sealed class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        public Task<OperationResult> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
