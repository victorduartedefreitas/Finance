using Finance.Core.Application.Services;
using Finance.Core.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationExtensionsServicesCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
