using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AdressBook.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddMediatR(cfg => Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
