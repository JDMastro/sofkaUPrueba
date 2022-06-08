using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, 
            IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            service.AddDbContext<AppDbContext>(options =>
               options.UseMySql(connection,ServerVersion.AutoDetect(connection))
            );

            return service;
        }
    }
}
