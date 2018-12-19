using Finance.Core.Domain.Repositories;
using Finance.Infrastructure.Repository.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryExtensionsServicesCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountReadOnlyRepository, AccountReadOnlyRepository>();
            serviceCollection.AddScoped<IAccountWriteOnlyRepository, AccountWriteOnlyRepository>();
            serviceCollection.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            serviceCollection.AddScoped<ICustomerWriteOnlyRepository, CustomerWriteOnlyRepository>();

            return serviceCollection;
        }
    }
}
