using AdressBook.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace AdressBook.Tests
{
    public abstract class BaseTest
    {
        private IServiceCollection services = DependencyInjection.GetServices();
        private IServiceProvider? serviceProvider;

        protected IMediator mediator => ServiceProvider.GetRequiredService<IMediator>();
        protected IEntryRepository entryRepository => ServiceProvider.GetRequiredService<IEntryRepository>();

        protected IServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    serviceProvider = services.BuildServiceProvider();
                }
                return serviceProvider;
            }
            set => serviceProvider = value;
        }

        protected IServiceCollection Services { get => services; }

    }
}
