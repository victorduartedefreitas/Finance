using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Finance.Core.Application.Tests
{
    public class AccountTest
    {
        IServiceProvider serviceProvider;

        public AccountTest()
        {
            var services = new ServiceCollection();

            services.RegisterApplicationServices();

            serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
