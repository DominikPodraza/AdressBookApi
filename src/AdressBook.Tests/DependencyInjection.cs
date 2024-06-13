using AdressBook.Application;
using AdressBook.Application.Common.Interfaces;
using AdressBook.Infrastructure;
using AdressBook.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AdressBook.Tests
{
    internal static class DependencyInjection
    {
        //private static readonly Mock<IConfiguration> configurationMock = new Mock<IConfiguration>();

        public static IServiceCollection GetServices()
        {
            var services = new ServiceCollection();
            //configurationMock.Setup(x => x.GetConnectionString(It.IsAny<string>())).Returns(string.Empty);
            services.AddApplication();
            services.RegistryInfrastructureServices();
            //services.AddInfrastructure(configurationMock.Object);
            services.RegisterMemoryDbContext();

            return services;
        }

        private static IServiceCollection RegisterMemoryDbContext(this IServiceCollection services)
        {
            var dbContextOptions = new DbContextOptionsBuilder<DataContext>();
            dbContextOptions.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new DataContext(dbContextOptions.Options);
            dbContext.Database.EnsureDeleted();
            services.AddSingleton(dbContext);
            return services;
        }
    }
}
