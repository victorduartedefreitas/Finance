using Finance.Core.Domain.Models;
using System.Threading.Tasks;

namespace Finance.Core.Domain.Repositories
{
    public interface ICustomerWriteOnlyRepository
    {
        Task<OperationResult> CreateCustomer(Customer customer);
        Task<OperationResult> UpdateCustomer(Customer customer);
    }
}
