using Finance.Core.Domain.Repositories;
using Finance.Infrastructure.Repository.InMemoryDataAccess.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryExtensionsServicesCollection
    {
        public static IServiceCollection RegisterInMemoryDataAccessRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountReadOnlyRepository, AccountRepository>();
            services.AddScoped<IAccountWriteOnlyRepository, AccountRepository>();
            services.AddScoped<ICustomerReadOnlyRepository, CustomerRepository>();
            services.AddScoped<ICustomerWriteOnlyRepository, CustomerRepository>();

            return services;
        }

        public static IServiceCollection RegisterDBDataAccessRepositories(this IServiceCollection services)
        {
            //TODO: Add references to DB DataAccess Repositories
            return services;
        }
    }
}
