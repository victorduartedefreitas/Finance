using Finance.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Task<OperationResult<Customer>> GetCustomer(Guid customerId);
    }
}
