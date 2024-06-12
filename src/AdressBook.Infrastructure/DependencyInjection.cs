using AdressBook.Application.Common.Interfaces;
using AdressBook.Infrastructure.Persistence;
using AdressBook.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Middleware.Example;

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

        public static IApplicationBuilder AddMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

    }
}
