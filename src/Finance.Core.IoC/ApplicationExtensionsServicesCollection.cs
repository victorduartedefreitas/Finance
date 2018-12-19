using Finance.Core.Application.Services;
using Finance.Core.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationExtensionsServicesCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountService, AccountService>();

            return serviceCollection;
        }
    }
}
