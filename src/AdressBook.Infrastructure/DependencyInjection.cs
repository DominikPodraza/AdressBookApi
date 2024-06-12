using AdressBook.Application.Common.Interfaces;
using AdressBook.Infrastructure.Persistance;
using AdressBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdressBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AdressBookDB"));
            });

            services.AddScoped<IEntryRepository, EntryRepository>();

            return services;
        }
    }
}
